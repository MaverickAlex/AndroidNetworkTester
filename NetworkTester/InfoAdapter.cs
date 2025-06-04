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
  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
  {
    //Setup your layout here
    View itemView = null;
    var id = Resource.Layout.item;
    itemView = LayoutInflater.From(parent.Context).
      Inflate(id, parent, false);

    var vh = new InfoItem(itemView);
    return vh;
  }

  public override int ItemCount => Items.Length;
}
