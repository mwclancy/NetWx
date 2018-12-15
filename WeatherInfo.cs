using System;
using System.Collections.Generic;
using System.Text;

namespace NetWx
{
    class WeatherInfo
    {
        /// <summary>
        /// The Current Weather Conditions.
        /// </summary>
        public string Conditions { get; set; }

        /// <summary>
        /// The Current Temperature in degrees C.
        /// </summary>
        public double TempC { get; set; }

        /// <summary>
        /// Get the current temperature in degrees F.
        /// </summary>
        /// <returns>The current temperature in degrees F.</returns>
        public double getDegreesF()
        {
            return TempC * 9 / 5 + 32;
        }
    }
}
