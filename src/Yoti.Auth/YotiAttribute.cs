﻿using System;
using System.Collections.Generic;
using System.Reflection;
using static Yoti.Auth.YotiAttributeValue;

namespace Yoti.Auth
{
    public class YotiAttribute<T>
    {
        private readonly string _name;
        private readonly YotiAttributeValue _value;
        private readonly HashSet<string> _sources;
        private readonly HashSet<string> _verifiers;

        public YotiAttribute(string name, YotiAttributeValue value)
        {
            _name = name;
            _value = value;
        }

        public YotiAttribute(string name, YotiAttributeValue value, HashSet<string> sources)
        {
            _name = name;
            _value = value;
            _sources = sources;
        }

        public YotiAttribute(string name, YotiAttributeValue value, HashSet<string> sources, HashSet<string> verifiers)
        {
            _name = name;
            _value = value;
            _sources = sources;
            _verifiers = verifiers;
        }

        public string GetName()
        {
            return _name;
        }

        public object GetValue()
        {
            return _value;
        }

        public Image GetImageValue()
        {
            return new Image
            {
                Base64URI = Base64Uri(),
                Data = _value.ToBytes(),
                Type = _value.Type
            };
        }

        public string GetStringValue()
        {
            return _value.ToString();
        }

        public DateTime? GetDateTimeValue()
        {
            return _value.ToDate();
        }

        public object GetValueOrDefault(object defaultValue)
        {
            return GetValue() ?? defaultValue;
        }

        public HashSet<string> GetSources()
        {
            return _sources;
        }

        public HashSet<string> GetVerifiers()
        {
            return _verifiers;
        }

        public string Base64Uri()
        {
            switch (_value.Type)
            {
                case TypeEnum.Jpeg:
                    return "data:image/jpeg;base64," + Conversion.BytesToBase64(_value.ToBytes());
                case TypeEnum.Png:
                    return "data:image/png;base64," + Conversion.BytesToBase64(_value.ToBytes());
                default:
                    return null;
            }
        }
    }
}