using System;
using System.Collections.Generic;
using System.Linq;

namespace list_view
{
    public class Toy
    {
        private int price;
        private String title;
        private String subTitle;
        private Android.Graphics.Bitmap bitmap;
        public Toy(int price, String title, String subTitle, Android.Graphics.Bitmap bitmap)
        {
            this.price = price;
            this.title = title;
            this.subTitle = subTitle;
            this.bitmap = bitmap;
        }
        public int getPrice()
        {
            return price;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public String getTitle()
        {
            return title;
        }
        public void setTitle(String title)
        {
            this.title = title;
        }
        public String getSubTitle()
        {
            return subTitle;
        }

        public void setSubTitle(String subTitle)
        {
            this.subTitle = subTitle;
        }

        public Android.Graphics.Bitmap getBitmap()
        {
            return bitmap;
        }

        public void setBitmap(Android.Graphics.Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }
    }
}