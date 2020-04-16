﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Web.Mvc;
using _47Example.Models;
using Newtonsoft.Json.Linq;
using Yoti.Auth;
using Yoti.Auth.Attribute;
using Yoti.Auth.Document;
using Yoti.Auth.Images;

namespace _47Example.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }

        // GET: Account/Connect?token
        [HttpGet]
        public ActionResult Connect(string token)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            if (token == null)
            {
                logger.Error("token is null");
                return RedirectToAction("Index", "Home");
            }

            try
            {
                string sdkId = ConfigurationManager.AppSettings["YOTI_CLIENT_SDK_ID"];
                logger.Info(string.Format("sdkId='{0}'", sdkId));

                var privateKeyStream = System.IO.File.OpenText(ConfigurationManager.AppSettings["YOTI_KEY_FILE_PATH"]);
                var yotiClient = new YotiClient(sdkId, privateKeyStream);

                var activityDetails = yotiClient.GetActivityDetails(token);

                var profile = activityDetails.Profile;

                ViewBag.RememberMeID = activityDetails.RememberMeId;

                DisplayAttributes displayAttributes = CreateDisplayAttributes(profile.AttributeCollection);

                if (profile.FullName != null)
                {
                    displayAttributes.FullName = profile.FullName.GetValue();
                }

                YotiAttribute<Image> selfie = profile.Selfie;
                if (profile.Selfie != null)
                {
                    Image selfieValue = selfie.GetValue();
                    displayAttributes.Base64Selfie = selfieValue.GetBase64URI();
                }

                return View(displayAttributes);
            }
            catch (Exception e)
            {
                logger.Error(e);
                TempData["Error"] = e.Message;
                TempData["InnerException"] = e.InnerException?.Message;
                return RedirectToAction("Error");
            }
        }

        private static DisplayAttributes CreateDisplayAttributes(ReadOnlyCollection<BaseAttribute> attributes)
        {
            var displayAttributes = new DisplayAttributes();

            foreach (var yotiAttribute in attributes)
            {
                switch (yotiAttribute.GetName())
                {
                    case Yoti.Auth.Constants.UserProfile.FullNameAttribute:
                        // Do nothing - we are displaying this already
                        break;

                    case Yoti.Auth.Constants.UserProfile.GivenNamesAttribute:
                        AddDisplayAttribute<string>("Given name", "yoti-icon-profile", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.FamilyNameAttribute:
                        AddDisplayAttribute<string>("Family name", "yoti-icon-profile", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.NationalityAttribute:
                        AddDisplayAttribute<string>("Nationality", "yoti-icon-nationality", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.PostalAddressAttribute:
                        AddDisplayAttribute<string>("Postal Address", "yoti-icon-address", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.StructuredPostalAddressAttribute:
                        AddDisplayAttribute<Dictionary<string, JToken>>("Structured Postal Address", "yoti-icon-address", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.PhoneNumberAttribute:
                        AddDisplayAttribute<string>("Mobile number", "yoti-icon-phone", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.EmailAddressAttribute:
                        AddDisplayAttribute<string>("Email address", "yoti-icon-email", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute:
                        AddDisplayAttribute<DateTime>("Date of birth", "yoti-icon-calendar", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.SelfieAttribute:
                        // Do nothing - we already display the selfie
                        break;

                    case Yoti.Auth.Constants.UserProfile.GenderAttribute:
                        AddDisplayAttribute<string>("Gender", "yoti-icon-gender", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.DocumentDetailsAttribute:
                        AddDisplayAttribute<DocumentDetails>("Document Details", "yoti-icon-profile", yotiAttribute, displayAttributes);
                        break;

                    case Yoti.Auth.Constants.UserProfile.DocumentImagesAttribute:
                        AddDisplayAttribute<List<Image>>("Document Images", "yoti-icon-profile", yotiAttribute, displayAttributes);
                        break;

                    default:
                        if (yotiAttribute is YotiAttribute<string> stringAttribute)
                        {
                            if (stringAttribute.GetName().Contains(":"))
                            {
                                displayAttributes.Add(new DisplayAttribute("Age Verification/", "Age verified", "yoti-icon-verified", stringAttribute.GetAnchors(), stringAttribute.GetValue()));
                                break;
                            }

                            AddDisplayAttribute<string>(stringAttribute.GetName(), "yoti-icon-profile", yotiAttribute, displayAttributes);
                        }
                        break;
                }
            }

            return displayAttributes;
        }

        private static void AddDisplayAttribute<T>(string name, string icon, BaseAttribute baseAttribute, DisplayAttributes displayAttributes)
        {
            if (baseAttribute is YotiAttribute<T> yotiAttribute)
                displayAttributes.Add(name, icon, yotiAttribute.GetAnchors(), yotiAttribute.GetValue());
        }

        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}