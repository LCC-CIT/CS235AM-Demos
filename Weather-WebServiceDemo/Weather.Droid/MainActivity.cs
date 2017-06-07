using Android.App;
using Android.Widget;
using Android.OS;
using Weather.Rest;
using Android.Text;
using Android.Text.Method;

namespace Weather.Droid
{
	[Activity (Label = "Weather.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var wuTextView = FindViewById<TextView>(Resource.Id.wuTextView);
            wuTextView.TextFormatted = Html.FromHtml(
            "<a href=\"https://www.wunderground.com/?apiref=5cdccc9428586099\">Data from Weather Underground</a> ");
            wuTextView.MovementMethod = LinkMovementMethod.Instance;

            WeatherService weatherService = new WeatherService();
            // string response = weatherService.Get3DayForecast("Eugene", "OR", ForecastFormat.xml);
            // var forecasts = weatherService.ParseForecastXML(response);
            string response = weatherService.Get3DayForecast("Eugene", "OR", ForecastFormat.json);
            var forecasts = weatherService.ParseForecastJson(response);

            var forecastListView = FindViewById<ListView>(Resource.Id.forecastListView);
            forecastListView.Adapter = new ArrayAdapter<ShortForecast>(this,
                             Android.Resource.Layout.SimpleListItem1,
                             forecasts);
        }
	}
}


