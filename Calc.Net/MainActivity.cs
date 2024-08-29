using Android.Service.Autofill;
using Android.Views;

namespace Calc.Net
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity, View.IOnClickListener
    {


        String lastSign = "";
        TextView tv;
        String num1 = "", num2 = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            tv = FindViewById<TextView>(Resource.Id.tvDisplay);

        }
        public void OnClick(View v)
        {
            // check if v is a button

            if (v is Button)
            {
                Button btn = (Button)v;
                String txt = btn.Text;
                if (txt == "+" || txt == "-" || txt == "*" || txt == "/")
                {
                    num1 = num2;
                    num2 = "";
                    lastSign = txt;
                }
                else if (txt == ".")
                {
                    if (num2.IndexOf(".") < 0)
                    {
                        num2 += txt;
                    }
                    tv.Text = num2;
                }
                else if (txt == "AC")
                {
                    num2 = "";
                    num1 = "";
                    tv.Text = "0";
                }
                else if (txt == ("SIN") || txt == ("COS") || txt == ("TAN"))
                {
                    float sol = 0;
                    if (num2 != "")
                        sol = float.Parse(num2);
                    else
                        if (num1 != "")
                        sol = float.Parse(num1);
                    float t = 0;
                    if (txt == ("TAN"))
                    {
                        t = (float)Math.Tan(sol * Math.PI / 180);
                    }
                    if (txt == ("COS"))
                    {
                        t = (float)Math.Cos(sol * Math.PI / 180);

                    }
                    if (txt == ("SIN"))
                    {
                        t = (float)Math.Sin(sol * Math.PI / 180);

                    }
                    tv.Text = t.ToString();
                    num2 = tv.Text;
                }
                else if (txt == ("="))
                {
                    float sol = 0;
                    if (lastSign == ("+"))
                    {
                        sol = float.Parse(num1) + float.Parse(num2);
                    }
                    else if (lastSign == ("-"))
                    {
                        sol = float.Parse(num1) - float.Parse(num2);

                    }
                    else if (lastSign == ("*"))
                    {
                        sol = float.Parse(num1) * float.Parse(num2);

                    }
                    else if (lastSign == ("/"))
                    {
                        sol = float.Parse(num1) / float.Parse(num2);

                    }
                    tv.Text = sol.ToString();
                    num2 = tv.Text;
                }

                else if (int.Parse(txt) >= 0 && int.Parse(txt) <= 9)
                {
                    num2 = num2 + txt;
                    tv.Text = num2;
                }
            }

        }

    }
}


