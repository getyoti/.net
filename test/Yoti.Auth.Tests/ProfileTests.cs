﻿using System;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Yoti.Auth.YotiAttributeValue;

namespace Yoti.Auth.Tests
{
    [TestClass]
    public class ProfileTests
    {
        [TestMethod]
        public void Profile_GetAttribute()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Text, Encoding.UTF8.GetBytes("value"));
            var initialAttribute = new YotiAttribute<string>(Constants.UserProfile.PhoneNumberAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<string> phoneNumberAttribute = applicationProfile.GetAttributeByName<string>(Constants.UserProfile.PhoneNumberAttribute);

            Assert.AreSame(initialAttribute, phoneNumberAttribute);
        }

        [TestMethod]
        public void Profile_GetAttribute_Datetime()
        {
            string value = "1980-01-13";
            var attributeValue = new YotiAttributeValue(TypeEnum.Date, Encoding.UTF8.GetBytes(value));
            var initialAttribute = new YotiAttribute<DateTime>(Constants.UserProfile.DateOfBirthAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<DateTime> dobAttribute = applicationProfile.GetAttributeByName<DateTime>(Constants.UserProfile.DateOfBirthAttribute);

            Assert.AreSame(initialAttribute, dobAttribute);
            DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob);
            Assert.AreEqual(dob, dobAttribute.GetValue());
        }

        [TestMethod]
        public void Profile_GetAttribute_Datetime_InvalidFormat()
        {
            string value = "1980/01/13";

            var attributeValue = new YotiAttributeValue(TypeEnum.Date, Encoding.UTF8.GetBytes(value));
            var initialAttribute = new YotiAttribute<DateTime>(Constants.UserProfile.DateOfBirthAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<DateTime> dobAttribute = applicationProfile.GetAttributeByName<DateTime>(Constants.UserProfile.DateOfBirthAttribute);

            Assert.ThrowsException<InvalidCastException>(() =>
            {
                dobAttribute.GetValue();
            });
        }

        [TestMethod]
        public void Profile_GetAttribute_Image()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Jpeg, Encoding.UTF8.GetBytes("selfie0123456789"));
            var initialAttribute = new YotiAttribute<Image>(Constants.UserProfile.SelfieAttribute, attributeValue);

            ApplicationProfile applicationProfile = TestTools.Profile.CreateApplicationProfileWithSingleAttribute(initialAttribute);

            YotiAttribute<Image> selfieAttribute = applicationProfile.GetAttributeByName<Image>(Constants.UserProfile.SelfieAttribute);

            Assert.AreSame(initialAttribute, selfieAttribute);
        }

        [TestMethod]
        public void Profile_GetAttribute_WithWrongType()
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
        public void Profile_AddAttribute()
        {
            var attributeValue = new YotiAttributeValue(TypeEnum.Jpeg, Encoding.UTF8.GetBytes("Nation"));
            var initialAttribute = new YotiAttribute<Image>(Constants.UserProfile.NationalityAttribute, attributeValue);

            ApplicationProfile applicationProfile = new ApplicationProfile();
            applicationProfile.Add(initialAttribute);

            YotiAttribute<Image> nationalityAttribute = applicationProfile.GetAttributeByName<Image>(Constants.UserProfile.NationalityAttribute);

            Assert.AreSame(initialAttribute, nationalityAttribute);
        }

        [TestMethod]
        public void Profile_GetAttributeNotPresent()
        {
            var applicationProfile = new ApplicationProfile();

            YotiAttribute<string> notPresentAttribute = applicationProfile.GetAttributeByName<string>("notPresent");

            Assert.IsNull(notPresentAttribute);
        }
    }
}