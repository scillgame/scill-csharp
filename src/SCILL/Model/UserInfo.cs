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
    /// Can be any object that is attached to the user. You can set these values in the user service. For example you can provide a user name and an avatar image url.
    /// </summary>
    [DataContract]
        public partial class UserInfo :  IEquatable<UserInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo" /> class.
        /// </summary>
        /// <param name="username">The user name of the user.</param>
        /// <param name="avatarImage">The name or URL of an avatar image for a user..</param>
        public UserInfo(string username = default(string), string avatarImage = default(string))
        {
            this.username = username;
            this.avatarImage = avatarImage;
        }
        
        /// <summary>
        /// The user name of the user
        /// </summary>
        /// <value>The user name of the user</value>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string username { get; set; }

        /// <summary>
        /// The name or URL of an avatar image for a user.
        /// </summary>
        /// <value>The name or URL of an avatar image for a user.</value>
        [DataMember(Name="avatarImage", EmitDefaultValue=false)]
        public string avatarImage { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserInfo {\n");
            sb.Append("  username: ").Append(username).Append("\n");
            sb.Append("  avatarImage: ").Append(avatarImage).Append("\n");
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
            return this.Equals(input as UserInfo);
        }

        /// <summary>
        /// Returns true if UserInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of UserInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.username == input.username ||
                    (this.username != null &&
                    this.username.Equals(input.username))
                ) && 
                (
                    this.avatarImage == input.avatarImage ||
                    (this.avatarImage != null &&
                    this.avatarImage.Equals(input.avatarImage))
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
                if (this.username != null)
                    hashCode = hashCode * 59 + this.username.GetHashCode();
                if (this.avatarImage != null)
                    hashCode = hashCode * 59 + this.avatarImage.GetHashCode();
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