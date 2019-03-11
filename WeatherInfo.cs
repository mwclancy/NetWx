namespace NetWx
{
    class WeatherInfo
    {
        /// <summary>
        /// The Current Weather Conditions.
        /// </summary>
        public string Conditions { get; set; }

        /// <summary>
        /// The current temperature in degrees C.
        /// </summary>
        public double? TempC { get; set; }

        /// <summary>
        /// The current temperature in degrees F.
        /// </summary>
        public double? TempF => TempC * 9 / 5 + 32 ?? null;
    }
}
