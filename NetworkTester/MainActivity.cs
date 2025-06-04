using _Microsoft.Android.Resource.Designer;
using Android.Net;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using System.Reflection;

namespace NetworkTester;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
  private int count = 0;
  private string? wifiName;

  protected override void OnCreate(Bundle? savedInstanceState)
  {
    base.OnCreate(savedInstanceState);

    // Set our view from the "main" layout resource
    SetContentView(Resource.Layout.activity_main);

    Button? button =  FindViewById<Button>(ResourceConstant.Id.button2);

    button.Click += delegate
    {
      CheckWifiNetwork();
    };
    CheckWifiNetwork();

  }
  private void CheckWifiNetwork()
  {
    ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
    LogProperties(connectivityManager);
    Network activeNetwork = connectivityManager.ActiveNetwork;
    NetworkCapabilities networkCapabilities = connectivityManager.GetNetworkCapabilities(activeNetwork);

    var list = LogProperties(networkCapabilities);
    RecyclerView recycler = new RecyclerView(ApplicationContext);

    recycler.SetAdapter(new InfoAdapter(list.ToArray()));
    recycler.SetLayoutManager(new LinearLayoutManager(ApplicationContext));
    FindViewById<LinearLayout>(ResourceConstant.Id.container).AddView(recycler);


    if (networkCapabilities != null && networkCapabilities.HasTransport(TransportType.Wifi))
    {
      // Wi-Fi is active
      wifiName = networkCapabilities.SignalStrength.ToString();
    }
  }
  private List<string> LogProperties(Object? obj)
  {
    List<string> result = new List<string>();
    LinearLayout rootView = FindViewById<LinearLayout>(ResourceConstant.Id.container);
    foreach (PropertyInfo property in obj.GetType().GetProperties())
    {
      Log.Debug("MainActivity", $"{obj.GetType().Name} {property.Name}: {property.GetValue(obj)}");
      result.Add($"{obj.GetType().Name} {property.Name}: {property.GetValue(obj)}");
    }
    return result;
  }
}