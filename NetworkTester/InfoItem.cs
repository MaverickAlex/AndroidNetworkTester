using _Microsoft.Android.Resource.Designer;
using Android.Runtime;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace NetworkTester;

public class InfoItem: RecyclerView.ViewHolder
{
  public TextView? Name { get; set; }
  public TextView? Value { get; set; }
  public InfoItem(View itemView) : base(itemView)
  {
    Name = itemView.FindViewById<TextView>(ResourceConstant.Id.name);
    Value = itemView.FindViewById<TextView>(ResourceConstant.Id.value);
    Name.Text = "Name";
    Value.Text = "Value";


  }
}