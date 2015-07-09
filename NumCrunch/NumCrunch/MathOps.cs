namespace NumCrunch
{
    //http://interactive-matter.eu/blog/2009/12/18/filtering-sensor-data-with-a-kalman-filter/
    class ScalarKalman
    {
        /// <summary>
        ///  x
        /// </summary>
        public double Value { get; set; }                       //x
        /// <summary>
        ///  q
        /// </summary>
        public double ProcessNoiseCovar { get; set; }           //q
        /// <summary>
        ///  r
        /// </summary>
        public double MeasureNoiseCovar { get; set; }           //r
        /// <summary>
        ///  p
        /// </summary>
        public double EstimationErrorCovar { get; set; }        //p
        /// <summary>
        ///  k
        /// </summary>
        private double Gain { get; set; }                        //k

        public void Update(double reading)
        {
            //Prediction Update
            EstimationErrorCovar = EstimationErrorCovar + ProcessNoiseCovar;

            //Measurement Update
            Gain = EstimationErrorCovar / (EstimationErrorCovar + MeasureNoiseCovar);
            Value = Value + (Gain * (reading - Value));
            EstimationErrorCovar = (1 - Gain)*EstimationErrorCovar;
        }
    }
}
