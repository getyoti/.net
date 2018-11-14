﻿using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Yoti.Auth.YotiAttributeValue;

namespace Yoti.Auth.Tests
{
    [TestClass]
    public class ApplicationProfileTests
    {
        private string _value = "value";

        [TestMethod]
        public void ApplicationProfile_NameAttribute()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Text, Encoding.UTF8.GetBytes(_value));
            var initialAttribute = new YotiAttribute<string>(Constants.ApplicationProfile.ApplicationNameAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<string> applicationNameAttribute = applicationProfile.Name;

            Assert.AreSame(initialAttribute, applicationNameAttribute);
        }

        [TestMethod]
        public void ApplicationProfile_URLAttribute()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Text, Encoding.UTF8.GetBytes(_value));
            var initialAttribute = new YotiAttribute<string>(Constants.ApplicationProfile.ApplicationURLAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<string> applicationURLAttribute = applicationProfile.URL;

            Assert.AreSame(initialAttribute, applicationURLAttribute);
        }

        [TestMethod]
        public void ApplicationProfile_LogoAttribute()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Png, Encoding.UTF8.GetBytes(_value));
            var initialAttribute = new YotiAttribute<Image>(Constants.ApplicationProfile.ApplicationLogoAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<Image> applicationLogoAttribute = applicationProfile.Logo;

            Assert.AreSame(initialAttribute, applicationLogoAttribute);
        }

        [TestMethod]
        public void ApplicationProfile_ReceiptBgColourAttribute()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Text, Encoding.UTF8.GetBytes(_value));
            var initialAttribute = new YotiAttribute<string>(Constants.ApplicationProfile.ApplicationReceiptBgColourAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<string> applicationReceiptBgColourAttribute = applicationProfile.ReceiptBackgroundColour;

            Assert.AreSame(initialAttribute, applicationReceiptBgColourAttribute);
        }

        [TestMethod]
        public void ApplicationProfile_GetAttribute_String()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Text, Encoding.UTF8.GetBytes(_value));
            var initialAttribute = new YotiAttribute<string>(Constants.ApplicationProfile.ApplicationNameAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<string> applicationNameAttribute = applicationProfile.GetAttributeByName<string>(Constants.ApplicationProfile.ApplicationNameAttribute);

            Assert.AreSame(initialAttribute, applicationNameAttribute);
        }

        [TestMethod]
        public void ApplicationProfile_GetAttribute_Image()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Jpeg, Encoding.UTF8.GetBytes(_value));
            var initialAttribute = new YotiAttribute<Image>(Constants.ApplicationProfile.ApplicationLogoAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<Image> logoAttribute = applicationProfile.GetAttributeByName<Image>(Constants.ApplicationProfile.ApplicationLogoAttribute);

            Assert.AreSame(initialAttribute, logoAttribute);
        }

        [TestMethod]
        public void ApplicationProfile_GetAttribute_WithWrongType()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Date, Encoding.UTF8.GetBytes("1980-01-13"));
            var initialAttribute = new YotiAttribute<DateTime>(Constants.UserProfile.DateOfBirthAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            Assert.ThrowsException<InvalidCastException>(() =>
            {
                YotiAttribute<Image> dobAttribute = applicationProfile.GetAttributeByName<Image>(Constants.UserProfile.DateOfBirthAttribute);
            });
        }

        [TestMethod]
        public void ApplicationProfile_GetAttributeNotPresent()
        {
            var applicationProfile = new ApplicationProfile();

            YotiAttribute<string> notPresentAttribute = applicationProfile.GetAttributeByName<string>("notPresent");

            Assert.IsNull(notPresentAttribute);
        }
    }
}