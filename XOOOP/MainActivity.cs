using Android.Views;
using Android.Graphics;
using Android.Content;
namespace XOOOP
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private XOGame game;
        private Button resetButton;
        private GridLayout gridLayout;
        private TextView resultText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Initialize game and UI components
            game = new XOGame();
            resetButton = FindViewById<Button>(Resource.Id.resetButton);
            gridLayout = FindViewById<GridLayout>(Resource.Id.grid);
            resultText = FindViewById<TextView>(Resource.Id.tv);
            resetButton.Click += (sender, e) => ResetGame();
            Display display = WindowManager.DefaultDisplay;
            Point size = new Point();
            display.GetSize(size);
            int screenWidth = size.X;

            // Calculate the width of each button (1/3 of the screen width)
            int buttonWidth = screenWidth / 3;

            // Create and populate the game board with buttons
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    XOButton button = new XOButton(this, row, col);
                    button.TextSize = 76;
                    button.LayoutParameters = new ViewGroup.LayoutParams(buttonWidth, ViewGroup.LayoutParams.WrapContent);
                    button.Click += (sender, e) => OnButtonClick((XOButton)sender);
                    gridLayout.AddView(button);
                    game.AddButton(button, row, col);
                }
            }
        }

        private void OnButtonClick(XOButton button)
        {
            if (!game.IsGameOver())
            {
                // Handle the button click and update the game
                int row = button.Row;
                int col = button.Column;
                game.MakeMove(row, col);

            }
            if (game.IsGameOver())
            {
                // Check for a win or draw
                ShowGameResult();
            }

        }

        private void ResetGame()
        {
            game.ResetBoard();
            resetButton.Visibility = Android.Views.ViewStates.Invisible;
            resultText.Text = string.Empty;
            // Implement logic to reset the game
        }

        private void ShowGameResult()
        {
            // Implement logic to display the winner
            resultText.Text = "The winner is: " + game.GetWinner();
            resetButton.Visibility = Android.Views.ViewStates.Visible;
        }

        public override void OnBackPressed()
        {
            createAlertDialog();
        }


        private void createAlertDialog()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("התרעה");
            builder.SetMessage(" ? לסיים את האפליקציה");
            builder.SetCancelable(true);
            builder.SetPositiveButton("כן", OkAction);
            builder.SetNegativeButton("לא", CancelAction);
            AlertDialog dialog = builder.Create();
            dialog.Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "OK clicked", ToastLength.Long).Show();
            Finish();
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "Cancel clicked", ToastLength.Long).Show();
        }

    }
}