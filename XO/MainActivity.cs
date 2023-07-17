using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android;


namespace XO

{

    [Activity(Label = "XO", MainLauncher = true)]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        Button[,] btns;
        Button btnResetGame;
        TextView tvWIn;
        int counter = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            tvWIn = FindViewById<TextView>(Resource.Id.tvWin);
            tvWIn.Visibility = Android.Views.ViewStates.Visible;
            btnResetGame = FindViewById<Button>(Resource.Id.btnResetGame);
            btnResetGame.SetOnClickListener(this);
            btnResetGame.Visibility = Android.Views.ViewStates.Invisible;
            btns = new Button[3, 3];
            btns[0, 0] = FindViewById<Button>(Resource.Id.btn0);
            btns[0, 1] = FindViewById<Button>(Resource.Id.btn1);
            btns[0, 2] = FindViewById<Button>(Resource.Id.btn2);
            btns[1, 0] = FindViewById<Button>(Resource.Id.btn3);
            btns[1, 1] = FindViewById<Button>(Resource.Id.btn4);
            btns[1, 2] = FindViewById<Button>(Resource.Id.btn5);
            btns[2, 0] = FindViewById<Button>(Resource.Id.btn6);
            btns[2, 1] = FindViewById<Button>(Resource.Id.btn7);
            btns[2, 2] = FindViewById<Button>(Resource.Id.btn8);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    btns[i, j].SetOnClickListener(this);
            }
        }

        public void OnClick(Android.Views.View v)
        {
            if (btnResetGame == v)
            {
                this.reset();
            }
            else
            {
                Button btn = (Button)v;
                if (counter % 2 == 0)
                {
                    btn.Text = "O";
                }
                else
                {
                    btn.Text = "X";
                }
                counter++;
                if (isWin() > 0)
                {
                    if (isWin() == 1)
                    {
                        tvWIn.Text = "O Wins";
                    }
                    else if (isWin() == 2)
                    {
                        tvWIn.Text = "X Wins";
                    }
                    btnResetGame.Visibility = Android.Views.ViewStates.Visible;
                    tvWIn.Visibility = Android.Views.ViewStates.Visible;
                }

                else if (counter > 8)
                {
                    tvWIn.Visibility = Android.Views.ViewStates.Visible;
                    tvWIn.Text = "No One Wins";
                    btnResetGame.Visibility = Android.Views.ViewStates.Visible;
                }
            }
        }

        public bool equals1(String str1, String str2)
        {
            if (str1.Length != str2.Length)
                return false;

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                    return false;
            }
            return true;
        }

        public int isWin()
        {
            if (counter > 4)
            {
                int j = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (btns[i, j].Text.Length > 0 && btns[i, j].Text.Equals(btns[i, j + 1]) && btns[i, j].Text.Equals(btns[i, j + 2].Text))
                    {
                        if (btns[i, j].Text.Equals("O"))
                            return 1;//0 win  - odd counting
                        return 2;//x win
                    }
                    else if (btns[j, i].Text.Length > 0 && btns[j, i].Text.Equals(btns[j + 1, i].Text) && btns[j, i].Text.Equals(btns[j + 2, i].Text))
                    {
                        if (btns[j, i].Text.Equals("O"))
                            return 1;//user win - even win
                        return 2;
                    }
                }//end of for

                //checking diagonal

                if (btns[0, 0].Text.Length > 0 && btns[0, 0].Text.Equals(btns[1, 1].Text) && btns[0, 0].Text.Equals(btns[2, 2].Text))
                {
                    if (btns[0, j].Text.Equals("O"))
                        return 1;//0 win  - odd counting
                    return 2;//x win
                }

                if (btns[0, 2].Text.Length > 0 && btns[0, 2].Text.Equals(btns[1, 1].Text) && btns[0, 2].Text.Equals(btns[2, 0].Text))
                {
                    if (btns[0, j].Text.Equals("O"))
                        return 1;//o win  - odd counting
                    return 2;
                }
            }
            return -1;//no one win
        }

        public void reset()
        {
            counter = 0;
            btnResetGame.Visibility = Android.Views.ViewStates.Invisible;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    btns[i, j].Text = "";
            }
            tvWIn.Visibility = Android.Views.ViewStates.Invisible;
        }
    }
}