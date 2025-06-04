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
    Name = new TextView(itemView.Context);
    Value = new TextView(itemView.Context);
    Name.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
    Value.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
    Name.Text = "Name";
    Value.Text = "Value";


  }
}