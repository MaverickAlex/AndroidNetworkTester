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

    Button? button =  FindViewById<Button>(ResourceConstant.Id.btnRefresh);

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
    RecyclerView recycler = FindViewById<RecyclerView>(ResourceConstant.Id.recyler);

    recycler.SetAdapter(new InfoAdapter(list.ToArray()));
    recycler.SetLayoutManager(new LinearLayoutManager(ApplicationContext));


    if (networkCapabilities != null && networkCapabilities.HasTransport(TransportType.Wifi))
    {
      // Wi-Fi is active
      wifiName = networkCapabilities.SignalStrength.ToString();
    }
  }
  private List<string> LogProperties(Object? obj)
  {
    List<string> result = new List<string>();
    foreach (PropertyInfo property in obj.GetType().GetProperties())
    {
      Log.Debug("MainActivity", $"{obj.GetType().Name} {property.Name}: {property.GetValue(obj)}");
      result.Add($"{obj.GetType().Name} {property.Name}: {property.GetValue(obj)}");
    }
    return result;
  }
}