using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StellaArdens.Core.Reference
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GunData
    {

        /// <summary>
        /// The gun name 
        /// </summary>
        [JsonProperty]
        public string Name { get; set; }


        /// <summary>
        /// The gun id
        /// </summary>
        [JsonProperty]
        public int GunId { get; set; }


        /// <summary>
        /// The caliber in inches
        /// </summary>
        [JsonProperty]
        public float CaliberInInches { get; set; }

        /// <summary>
        /// Caliber in mm (derived from inches)
        /// </summary>
        public float CaliberInMillimeters { 
            get 
            {
                return CaliberInInches * 25.4f;
            } 
        }

        /// <summary>
        /// described in terms of multiples of the bore diameter
        /// </summary>
        [JsonProperty] 
        public float BarrelLength { get; set; }

        /// <summary>
        /// Max range in yards
        /// </summary>
        [JsonProperty]
        public int MaxRangeInYards { get; set; }

        /// <summary>
        /// Muzzle velocity in feet per seconds
        /// </summary>
        [JsonProperty]
        public int MuzzleVelocityInFPS { get; set; }

        /// <summary>
        ///  Muzzle velocity in meters per seconds (derived from feet)
        /// </summary>
        public float MuzzleVelocityInMPS
        {
            get
            {
                return MuzzleVelocityInFPS * 0.3048f;
            }
        }

    }
}
