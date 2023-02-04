using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiApp1.Data;
using Microsoft.JSInterop;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}

	[JSInvokable]
	public static Task<long> GetLongType()
	{
		return Task.FromResult(long.MaxValue);
	}
	[JSInvokable]
	public static Task<LongObj> GetLongObject()
	{
		return Task.FromResult(new LongObj(){Id = long.MaxValue } );
	}
}

public class LongObj
{
	public long Id { get; set; }
}
