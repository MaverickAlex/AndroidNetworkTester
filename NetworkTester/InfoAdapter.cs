using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace NetworkTester;

public class InfoAdapter:RecyclerView.Adapter
{
  public InfoAdapter(string[] items)
  {
    Items = items;
  }

  public string[] Items { get; set; }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
  {
    var item = Items[position];
    var infoItem = (InfoItem)holder;
    infoItem.Name.Text = item;
    infoItem.Value.Text = item;
  }
  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) =>
    new InfoItem(parent);

  public override int ItemCount => Items.Length;
}
