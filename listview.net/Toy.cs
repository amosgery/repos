
using Android.Graphics;
using SQLite;

namespace listview.net
{
    [Table("Toys")]
    public class Toy
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int Price { get; set; }
        public String Title { get; set; }
        public String Subtitle { get; set; }
        public String Bitmap { get; set; }
        public Toy(int price, String title, String subTitle, Android.Graphics.Bitmap bitmap)
        {
            this.Price = price;
            this.Title = title;
            this.Subtitle = subTitle;
            setBitmap(bitmap);
        }
        public Toy()
        {
        }

        public Android.Graphics.Bitmap getBitmap()
        {
            return Helper.Base64ToBitmap(Bitmap);
        }

        public void setBitmap(Android.Graphics.Bitmap bitmap)
        {
            Bitmap = Helper.BitmapToBase64(bitmap);
        }

        internal void setToy(int id, int price, string title, string subtitle, Bitmap bitmap)
        {
            this.Price = price;
            this.Title = title;
            this.Subtitle = subtitle;
            setBitmap(bitmap);
        }
    }
}
