﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yoti.Auth.Web;

namespace Yoti.Auth.Tests.Web
{
    [TestClass]
    public class HeadersFactoryTests
    {
        private const string _someDigest = "someDigest";

        [TestMethod]
        public void ShouldCreateHeadersWithDigestAndKey()
        {
            string SDKVersionHeader = typeof(YotiClientEngine).GetTypeInfo().Assembly.GetName().Version.ToString();

            HttpRequestMessage result = HeadersFactory.PutHeaders(new HttpRequestMessage(), _someDigest, SDKVersionHeader);

            Assert.AreEqual(
                _someDigest,
                result.Headers.GetValues(Constants.Web.DigestHeader).Single());
            Assert.AreEqual(
                Constants.Web.SdkIdentifier,
                result.Headers.GetValues(Constants.Web.YotiSdkHeader).Single());
            Assert.AreEqual(
                $"{Constants.Web.SdkIdentifier}-{SDKVersionHeader}",
                result.Headers.GetValues(Constants.Web.YotiSdkVersionHeader).Single());
        }
    }
}