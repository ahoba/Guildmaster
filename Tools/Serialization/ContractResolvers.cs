using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Serialization
{
    /// <summary>
    /// Serializes only Guids of nested objects
    /// </summary>
    public class NestedObjectIdOnlyContractSerializer : DefaultContractResolver
    {
        private IEnumerable<Type> _types;

        private IEnumerable<string> _allowedProperties;

        public NestedObjectIdOnlyContractSerializer(IEnumerable<Type> types, IEnumerable<string> allowedProperties = null)
        {
            _types = types;

            _allowedProperties = allowedProperties == null ? new string[] { } : allowedProperties;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            if (_types != null && _types.Contains(type))
            {
                properties = 
                    properties.Where(
                        x => x.PropertyType == typeof(Guid) ||
                        _allowedProperties.Contains(x.PropertyName)).ToList();
            }

            return properties;
        }
    }
}
