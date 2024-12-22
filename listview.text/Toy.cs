using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Toy(int price, String title, String subTitle)
        {
            this.Price = price;
            this.Title = title;
            this.Subtitle = subTitle;

        }
        public Toy()
        {
        }

        internal void setToy(int id, int price, string title, string subtitle)
        {
            this.Price = price;
            this.Title = title;
            this.Subtitle = subtitle;

        }
    }
}
