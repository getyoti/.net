﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Yoti.Auth.Attribute;

namespace Yoti.Auth.Verifications
{
    /// <summary>
    /// Wraps an 'Age Verify/Condition' attribute to provide behaviour specific to verifying
    /// someone's age.
    /// </summary>
    public class AgeVerification
    {
        private readonly YotiAttribute<string> _derivedAttribute;
        private readonly int _ageVerified;
        private readonly string _checkPerformed;
        private readonly bool _result;
        private const string expectedFormatRegex = "[^:]+:(?!.*:)[0-9]+";

        public AgeVerification(YotiAttribute<string> derivedAttribute)
        {
            if (derivedAttribute == null)
            {
                throw new ArgumentNullException(nameof(derivedAttribute));
            }

            string attributeName = derivedAttribute.GetName();

            if (!Regex.IsMatch(attributeName, expectedFormatRegex))
            {
                throw new InvalidOperationException(
                    $"{nameof(attributeName)} {Properties.Resources.FormatMismatch} '{expectedFormatRegex}'");
            }

            _derivedAttribute = derivedAttribute;

            string[] split = attributeName.Split(':');
            _checkPerformed = split[0];
            _ageVerified = int.Parse(split[1], new CultureInfo("en-GB"));
            _result = bool.Parse(derivedAttribute.GetValue());
        }

        /// <summary>
        /// The age that was that checked, as specified on Yoti Hub.
        /// </summary>
        /// <returns>The age that was that checked</returns>
        public int Age()
        {
            return _ageVerified;
        }

        /// <summary>
        /// The type of age check performed, as specified on Yoti Hub. Currently this might be
        /// 'age_over' or 'age_under'.
        /// </summary>
        /// <returns>The type of age check performed</returns>
        public string CheckType()
        {
            return _checkPerformed;
        }

        /// <summary>
        /// Whether or not the profile passed the age check.
        /// </summary>
        /// <returns>The result of the age check</returns>
        public bool Result()
        {
            return _result;
        }

        /// <summary>
        /// The wrapped profile attribute. Use this if you need access to the underlying List of <see cref="Anchor"/>.
        /// </summary>
        /// <returns>The wrapped profile attribute</returns>
        public YotiAttribute<string> Attribute()
        {
            return _derivedAttribute;
        }
    }
}