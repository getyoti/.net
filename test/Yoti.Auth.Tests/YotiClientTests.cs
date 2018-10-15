﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Yoti.Auth.Aml;
using Yoti.Auth.Tests.TestTools;

namespace Yoti.Auth.Tests
{
    [TestClass]
    public class YotiClientTests
    {
        private const string EncryptedToken = "b6H19bUCJhwh6WqQX/sEHWX9RP+A/ANr1fkApwA4Dp2nJQFAjrF9e6YCXhNBpAIhfHnN0iXubyXxXZMNwNMSQ5VOxkqiytrvPykfKQWHC6ypSbfy0ex8ihndaAXG5FUF+qcU8QaFPMy6iF3x0cxnY0Ij0kZj0Ng2t6oiNafb7AhT+VGXxbFbtZu1QF744PpWMuH0LVyBsAa5N5GJw2AyBrnOh67fWMFDKTJRziP5qCW2k4h5vJfiYr/EOiWKCB1d/zINmUm94ZffGXxcDAkq+KxhN1ZuNhGlJ2fKcFh7KxV0BqlUWPsIEiwS0r9CJ2o1VLbEs2U/hCEXaqseEV7L29EnNIinEPVbL4WR7vkF6zQCbK/cehlk2Qwda+VIATqupRO5grKZN78R9lBitvgilDaoE7JB/VFcPoljGQ48kX0wje1mviX4oJHhuO8GdFITS5LTbojGVQWT7LUNgAUe0W0j+FLHYYck3v84OhWTqads5/jmnnLkp9bdJSRuJF0e8pNdePnn2lgF+GIcyW/0kyGVqeXZrIoxnObLpF+YeUteRBKTkSGFcy7a/V/DLiJMPmH8UXDLOyv8TVt3ppzqpyUrLN2JVMbL5wZ4oriL2INEQKvw/boDJjZDGeRlu5m1y7vGDNBRDo64+uQM9fRUULPw+YkABNwC0DeShswzT00=";

        private static StreamReader GetValidKeyStream()
        {
            return File.OpenText("test-key.pem");
        }

        private static StreamReader GetInvalidFormatKeyStream()
        {
            return File.OpenText("test-key-invalid-format.pem");
        }

        [TestMethod]
        public void YotiClient_ValidParameters_DoesntThrowException()
        {
            YotiClient client = CreateYotiClient();
        }

        [TestMethod]
        public void YotiClient_NullSdkId_ThrowsException()
        {
            StreamReader keystream = GetValidKeyStream();
            string sdkId = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                YotiClient client = new YotiClient(sdkId, keystream);
            });
        }

        [TestMethod]
        public void YotiClient_EmptySdkId_ThrowsException()
        {
            StreamReader keystream = GetValidKeyStream();
            string sdkId = string.Empty;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                YotiClient client = new YotiClient(sdkId, keystream);
            });
        }

        [TestMethod]
        public void YotiClient_NoKeyStream_ThrowsException()
        {
            StreamReader keystream = null;
            string sdkId = "fake-sdk-id";
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                YotiClient client = new YotiClient(sdkId, keystream);
            });
        }

        [TestMethod]
        public void YotiClient_InvalidKeyStream_ThrowsException()
        {
            StreamReader keystream = GetInvalidFormatKeyStream();
            string sdkId = "fake-sdk-id";
            Assert.ThrowsException<ArgumentException>(() =>
            {
                YotiClient client = new YotiClient(sdkId, keystream);
            });
        }

        [TestMethod]
        public void YotiClient_GetActivityDetails()
        {
            YotiClient client = CreateYotiClient();

            ActivityDetails activityDetails = client.GetActivityDetails(EncryptedToken);

            Assert.IsNotNull(activityDetails.Outcome);
        }

        [TestMethod]
        public async Task YotiClient_GetActivityDetailsAsync()
        {
            YotiClient client = CreateYotiClient();

            ActivityDetails activityDetails = await client.GetActivityDetailsAsync(EncryptedToken);

            Assert.IsNotNull(activityDetails.Outcome);
        }

        [TestMethod]
        public void YotiClient_PerformAmlCheck_NullAmlProfile_ThrowsException()
        {
            YotiClient client = CreateYotiClient();

            AggregateException aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                AmlResult amlResult = client.PerformAmlCheck(amlProfile: null);
            });

            Assert.IsTrue(Exceptions.IsExceptionInAggregateException<ArgumentNullException>(aggregateException));
        }

        [TestMethod]
        public void YotiClient_PerformAmlCheck_NullAmlAddress_ThrowsException()
        {
            YotiClient client = CreateYotiClient();

            AmlProfile amlProfile = new AmlProfile(
                           givenNames: "Edward Richard George",
                           familyName: "Heath",
                           amlAddress: null);

            AggregateException aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                AmlResult amlResult = client.PerformAmlCheck(amlProfile: amlProfile);
            });

            Assert.IsTrue(Exceptions.IsExceptionInAggregateException<JsonSerializationException>(aggregateException));
        }

        [TestMethod]
        public void YotiClient_PerformAmlCheck_NullGivenName_ThrowsException()
        {
            YotiClient client = CreateYotiClient();

            AmlProfile amlProfile = new AmlProfile(
                givenNames: null,
                familyName: "Heath",
                amlAddress: TestTools.Aml.CreateStandardAmlAddress());

            AggregateException aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                AmlResult amlResult = client.PerformAmlCheck(amlProfile: amlProfile);
            });

            Assert.IsTrue(Exceptions.IsExceptionInAggregateException<JsonSerializationException>(aggregateException));
        }

        [TestMethod]
        public void YotiClient_PerformAmlCheck_NullFamilyName_ThrowsException()
        {
            YotiClient client = CreateYotiClient();

            AmlProfile amlProfile = new AmlProfile(
                givenNames: "Edward Richard George",
                familyName: null,
                amlAddress: TestTools.Aml.CreateStandardAmlAddress());

            AggregateException aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                AmlResult amlResult = client.PerformAmlCheck(amlProfile: amlProfile);
            });

            Assert.IsTrue(Exceptions.IsExceptionInAggregateException<JsonSerializationException>(aggregateException));
        }

        [TestMethod]
        public void YotiClient_PerformAmlCheck_NullCountry_ThrowsException()
        {
            YotiClient client = CreateYotiClient();

            AmlAddress amlAddress = new AmlAddress(
               country: null);

            AmlProfile amlProfile = new AmlProfile(
                givenNames: "Edward Richard George",
                familyName: "Heath",
                amlAddress: amlAddress);

            AggregateException aggregateException = Assert.ThrowsException<AggregateException>(() =>
            {
                AmlResult amlResult = client.PerformAmlCheck(amlProfile: amlProfile);
            });

            Assert.IsTrue(Exceptions.IsExceptionInAggregateException<JsonSerializationException>(aggregateException));
        }

        private static YotiClient CreateYotiClient()
        {
            const string sdkId = "fake-sdk-id";
            StreamReader privateStreamKey = GetValidKeyStream();

            return new YotiClient(sdkId, privateStreamKey);
        }
    }
}