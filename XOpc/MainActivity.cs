using Android.App;

using Android.Widget;

using Android.OS;

using System;
using Android.Content;


namespace XOpc

{

    [Activity(Label = "XOpc", MainLauncher = true)]

    public class MainActivity : Activity, Android.Views.View.IOnClickListener

    {

        Button[,] btns;

        Button btnResetGame;

        TextView tvWIn, tvwinners;

        int counter = 0, user_count = 0, comp_count = 0;

        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,

            // and attach an event to it

            tvWIn = FindViewById<TextView>(Resource.Id.tvWin);
            tvwinners = FindViewById<TextView>(Resource.Id.tvwinners);

            tvWIn.Visibility = Android.Views.ViewStates.Invisible;

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
                userTurn(v);
            }
        }


        public int isWin()
        {
            if (counter > 4)
            {
                int j = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (btns[i, j].Text.Length > 0 && btns[i, j].Text == btns[i, j + 1].Text && btns[i, j].Text == btns[i, j + 2].Text)
                    {
                        if (btns[i, j].Text == ("O"))
                            return 1;//0 win  - odd counting
                        return 2;//x win
                    }
                    else if (btns[j, i].Text.Length > 0 && btns[j, i].Text == btns[j + 1, i].Text && btns[j, i].Text == btns[j + 2, i].Text)
                    {
                        if (btns[j, i].Text == ("O"))
                            return 1;//user win - even win
                        return 2;
                    }
                }//end of for

                //checking diagonal
                if (btns[0, 0].Text.Length > 0 && btns[0, 0].Text == btns[1, 1].Text && btns[0, 0].Text == btns[2, 2].Text)
                {
                    if (btns[0, 0].Text == ("O"))
                        return 1;//0 win  - odd counting
                    return 2;//x win
                }
                if (btns[0, 2].Text.Length > 0 && btns[0, 2].Text == btns[1, 1].Text && btns[0, 2].Text == btns[2, 0].Text)
                {
                    if (btns[0, 2].Text == ("O"))
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
            tvwinners.Visibility = Android.Views.ViewStates.Invisible;

        }



        public void userTurn(Android.Views.View v)

        {

            Button btn = (Button)v;

            btn.Text = "O";

            counter++;

            if (doweHaveAwinner() || counter > 8)

            {

                return;

            }

            else
            {

                computerTurn();
            }

        }

        public bool doweHaveAwinner()

        {
            int win = isWin();
            if (win > 0)

            {

                if (win == 1)

                {

                    tvWIn.Text = "O Win";

                }

                else if (win == 2)

                {

                    tvWIn.Text = "X Win";

                }

                btnResetGame.Visibility = Android.Views.ViewStates.Visible;

                tvWIn.Visibility = Android.Views.ViewStates.Visible;
                saveWin(win);
                return true;



            }

            else if (counter > 8)

            {

                tvWIn.Visibility = Android.Views.ViewStates.Visible;

                tvWIn.Text = "No One Wins";

                btnResetGame.Visibility = Android.Views.ViewStates.Visible;

                return false;

            }

            return false;



        }

        public void computerTurn()

        {
            counter++;
            Random random = new Random();
            bool find = false;
            while (!find)
            {
                int col = random.Next(10) % 3;
                int line = random.Next(10) % 3;
                if (btns[line, col].Text.Equals(""))
                {
                    btns[line, col].Text = "X";
                    find = true;
                }
            }//end of while
            doweHaveAwinner();
        }
        public void saveWin(int winner)// user 0 1 , computer x 2 , -1
        {
            if (winner > 0)
            {
                ISharedPreferences sp = GetSharedPreferences("winners", 0);
                var editor = sp.Edit();
                user_count = sp.GetInt("user_count", 0);
                comp_count = sp.GetInt("comp_count", 0);

                if (winner == 1)
                {
                    user_count++;
                    editor.PutInt("user_count", user_count);
                }
                else if (winner == 2)
                {
                    comp_count++;
                    editor.PutInt("comp_count", comp_count);
                }
                editor.Commit();
                refresh_winners();
            }

        }
        public void refresh_winners()
        {
            ISharedPreferences sp = GetSharedPreferences("winners", 0);
            user_count = sp.GetInt("user_count", 0);
            comp_count = sp.GetInt("comp_count", 0);
            tvwinners.Text = "comp : " + comp_count.ToString() + " user : " + user_count.ToString();
            tvwinners.Visibility = Android.Views.ViewStates.Visible; 
        }
    }

}
