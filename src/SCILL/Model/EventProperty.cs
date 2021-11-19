/* 
 * SCILL API
 *
 * SCILL gives you the tools to activate, retain and grow your user base in your app or game by bringing you features well known in the gaming industry: Gamification. We take care of the services and technology involved so you can focus on your game and content.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: support@scillgame.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = SCILL.Client.SwaggerDateConverter;

namespace SCILL.Model
{
    /// <summary>
    /// This object holds information about a proporty of an event. Events have required and optional properties.
    /// </summary>
    [DataContract]
        public partial class EventProperty :  IEquatable<EventProperty>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventProperty" /> class.
        /// </summary>
        /// <param name="propertyName">The name of the property. Is the field value in the event payloads meta_data..</param>
        /// <param name="propertyType">The type of the property. Can be number or string..</param>
        public EventProperty(string propertyName = default(string), string propertyType = default(string))
        {
            this.property_name = propertyName;
            this.property_type = propertyType;
        }
        
        /// <summary>
        /// The name of the property. Is the field value in the event payloads meta_data.
        /// </summary>
        /// <value>The name of the property. Is the field value in the event payloads meta_data.</value>
        [DataMember(Name="property_name", EmitDefaultValue=false)]
        public string property_name { get; set; }

        /// <summary>
        /// The type of the property. Can be number or string.
        /// </summary>
        /// <value>The type of the property. Can be number or string.</value>
        [DataMember(Name="property_type", EmitDefaultValue=false)]
        public string property_type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EventProperty {\n");
            sb.Append("  property_name: ").Append(property_name).Append("\n");
            sb.Append("  property_type: ").Append(property_type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as EventProperty);
        }

        /// <summary>
        /// Returns true if EventProperty instances are equal
        /// </summary>
        /// <param name="input">Instance of EventProperty to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EventProperty input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.property_name == input.property_name ||
                    (this.property_name != null &&
                    this.property_name.Equals(input.property_name))
                ) && 
                (
                    this.property_type == input.property_type ||
                    (this.property_type != null &&
                    this.property_type.Equals(input.property_type))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.property_name != null)
                    hashCode = hashCode * 59 + this.property_name.GetHashCode();
                if (this.property_type != null)
                    hashCode = hashCode * 59 + this.property_type.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}