using Android.Content;
using Android.Graphics;
using Android.Views;


namespace FollowBall
{
    public class FollowBallView : View
    {
        private Paint ballPaint;
        private float ballX = 100;
        private float ballY = 100;
        private float ballRadius = 50;

        public FollowBallView(Context context) : base(context)
        {
            ballPaint = new Paint
            {
                Color = Color.Red,
                AntiAlias = true
            };
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            // Draw the ball at the current finger coordinates
            canvas.DrawCircle(ballX, ballY, ballRadius, ballPaint);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                case MotionEventActions.Move:
                    // Update coordinates to where the finger is
                    ballX = e.GetX();
                    ballY = e.GetY();

                    // Force the view to redraw (calls OnDraw)
                    Invalidate();
                    return true;
            }
            return base.OnTouchEvent(e);
        }
    }
}
