using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;


namespace FirstApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {
        Button btnPlus, btnMinus, btnMul, btnDiv, btnCalc;
        EditText num1, num2;
        TextView tv, op;
        double result = 0.0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnPlus = FindViewById<Button>(Resource.Id.btnPlus);
            btnMinus = FindViewById<Button>(Resource.Id.btnMinus);
            btnMul = FindViewById<Button>(Resource.Id.btnMul);
            btnDiv = FindViewById<Button>(Resource.Id.btnDiv);
            btnCalc = FindViewById<Button>(Resource.Id.btnCalc);

            tv = FindViewById<TextView>(Resource.Id.tvDisplay);
            op = FindViewById<TextView>(Resource.Id.op);

            num1 = FindViewById<EditText>(Resource.Id.num1);
            num2 = FindViewById<EditText>(Resource.Id.num2);


            btnPlus.SetOnClickListener(this);
            btnMinus.SetOnClickListener(this);
            btnMul.SetOnClickListener(this);
            btnDiv.SetOnClickListener(this);
            btnCalc.SetOnClickListener(this);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void View.IOnClickListener.OnClick(View v)
        {
            //double num1Int, num2Int;
            // Convert EditText to int
            bool isNumerical1 = double.TryParse(num1.Text, out double num1Int);
            bool isNumerical2 = double.TryParse(num2.Text, out double num2Int);

            if (!isNumerical1 || !isNumerical2)
            {
                Toast.MakeText(this, "Enter 2 numbers and click an operator", ToastLength.Long).Show();

            }
            if (v == btnPlus)
            {
                op.Text = "+";
            }
            if (v == btnMinus) { 
                op.Text = "-";
            }
            if (v == btnMul) { 
                op.Text = "*";
            }
            if (v == btnDiv)
            {
                op.Text = "/";
            }
            if (v == btnCalc)
            {
                switch(op.Text)
                {
                    case "+":
                        result = num1Int + num2Int;
                        break;
                    case "-":
                        result = num1Int - num2Int;
                        break;
                    case "*":
                        result = num1Int * num2Int;
                        break;
                    case "/":
                        if (num2Int == 0)
                        {
                            Toast.MakeText(this, "Cannot divide by 0", ToastLength.Long).Show();
                            result = 0;
                        }
                        else
                            result = num1Int / num2Int;
                        break;
                    default:
                        op.Text = "op";
                        break;
                }
                if (op.Text == "op")
                    Toast.MakeText(this, "Enter an operator", ToastLength.Long).Show();

                tv.Text = result.ToString();
            }
        }
    }
}