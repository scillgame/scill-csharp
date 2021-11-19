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
    /// This object is sent via Webhook or notifications of type leaderboard-changed.
    /// </summary>
    [DataContract]
        public partial class LeaderboardV2Changed :  IEquatable<LeaderboardV2Changed>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaderboardV2Changed" /> class.
        /// </summary>
        /// <param name="webhookType">The type of the notification. If you receive this payload, it&#x27;s most likely leaderboard-changed..</param>
        /// <param name="oldLeaderboard">oldLeaderboard.</param>
        /// <param name="newLeaderboard">newLeaderboard.</param>
        public LeaderboardV2Changed(string webhookType = default(string), LeaderboardV2Info oldLeaderboard = default(LeaderboardV2Info), LeaderboardV2Info newLeaderboard = default(LeaderboardV2Info))
        {
            this.webhook_type = webhookType;
            this.old_leaderboard = oldLeaderboard;
            this.new_leaderboard = newLeaderboard;
        }
        
        /// <summary>
        /// The type of the notification. If you receive this payload, it&#x27;s most likely leaderboard-changed.
        /// </summary>
        /// <value>The type of the notification. If you receive this payload, it&#x27;s most likely leaderboard-changed.</value>
        [DataMember(Name="webhook_type", EmitDefaultValue=false)]
        public string webhook_type { get; set; }

        /// <summary>
        /// Gets or Sets old_leaderboard
        /// </summary>
        [DataMember(Name="old_leaderboard", EmitDefaultValue=false)]
        public LeaderboardV2Info old_leaderboard { get; set; }

        /// <summary>
        /// Gets or Sets new_leaderboard
        /// </summary>
        [DataMember(Name="new_leaderboard", EmitDefaultValue=false)]
        public LeaderboardV2Info new_leaderboard { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LeaderboardV2Changed {\n");
            sb.Append("  webhook_type: ").Append(webhook_type).Append("\n");
            sb.Append("  old_leaderboard: ").Append(old_leaderboard).Append("\n");
            sb.Append("  new_leaderboard: ").Append(new_leaderboard).Append("\n");
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
            return this.Equals(input as LeaderboardV2Changed);
        }

        /// <summary>
        /// Returns true if LeaderboardV2Changed instances are equal
        /// </summary>
        /// <param name="input">Instance of LeaderboardV2Changed to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LeaderboardV2Changed input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.webhook_type == input.webhook_type ||
                    (this.webhook_type != null &&
                    this.webhook_type.Equals(input.webhook_type))
                ) && 
                (
                    this.old_leaderboard == input.old_leaderboard ||
                    (this.old_leaderboard != null &&
                    this.old_leaderboard.Equals(input.old_leaderboard))
                ) && 
                (
                    this.new_leaderboard == input.new_leaderboard ||
                    (this.new_leaderboard != null &&
                    this.new_leaderboard.Equals(input.new_leaderboard))
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
                if (this.webhook_type != null)
                    hashCode = hashCode * 59 + this.webhook_type.GetHashCode();
                if (this.old_leaderboard != null)
                    hashCode = hashCode * 59 + this.old_leaderboard.GetHashCode();
                if (this.new_leaderboard != null)
                    hashCode = hashCode * 59 + this.new_leaderboard.GetHashCode();
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