namespace Weather.Rest
{
    public class Forecast
    {
        public string Title { get; set; }
        public string ForecastText { get; set; }
    }

    public enum ForecastFormat { json, xml};
}
