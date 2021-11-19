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
    /// This object uses two keys - \&quot;user\&quot; and \&quot;team\&quot;, both of which contain ranking info
    /// </summary>
    [DataContract]
        public partial class LeaderboardV2ResultsLeaderboardResultsByMemberType :  IEquatable<LeaderboardV2ResultsLeaderboardResultsByMemberType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaderboardV2ResultsLeaderboardResultsByMemberType" /> class.
        /// </summary>
        /// <param name="team">team.</param>
        /// <param name="user">user.</param>
        public LeaderboardV2ResultsLeaderboardResultsByMemberType(LeaderboardV2MemberTypeRanking team = default(LeaderboardV2MemberTypeRanking), LeaderboardV2MemberTypeRanking user = default(LeaderboardV2MemberTypeRanking))
        {
            this.team = team;
            this.user = user;
        }
        
        /// <summary>
        /// Gets or Sets team
        /// </summary>
        [DataMember(Name="team", EmitDefaultValue=false)]
        public LeaderboardV2MemberTypeRanking team { get; set; }

        /// <summary>
        /// Gets or Sets user
        /// </summary>
        [DataMember(Name="user", EmitDefaultValue=false)]
        public LeaderboardV2MemberTypeRanking user { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LeaderboardV2ResultsLeaderboardResultsByMemberType {\n");
            sb.Append("  team: ").Append(team).Append("\n");
            sb.Append("  user: ").Append(user).Append("\n");
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
            return this.Equals(input as LeaderboardV2ResultsLeaderboardResultsByMemberType);
        }

        /// <summary>
        /// Returns true if LeaderboardV2ResultsLeaderboardResultsByMemberType instances are equal
        /// </summary>
        /// <param name="input">Instance of LeaderboardV2ResultsLeaderboardResultsByMemberType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LeaderboardV2ResultsLeaderboardResultsByMemberType input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.team == input.team ||
                    (this.team != null &&
                    this.team.Equals(input.team))
                ) && 
                (
                    this.user == input.user ||
                    (this.user != null &&
                    this.user.Equals(input.user))
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
                if (this.team != null)
                    hashCode = hashCode * 59 + this.team.GetHashCode();
                if (this.user != null)
                    hashCode = hashCode * 59 + this.user.GetHashCode();
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