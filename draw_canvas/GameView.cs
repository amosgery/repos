using Android.Content;
using Android.Graphics;
using Android.Views;


namespace draw_canvas
{
    public class Boardgame : View
    {
        float x1, y1, x2, y2, r;
        float deltax1, deltay1, deltax2, deltay2;
        Paint p;
        Context context;
        public Boardgame(Context context) : base(context)
        {
            this.context = context;
            p = new Paint();
            p.Color = Color.Blue;
            p.StrokeWidth = 12;
            x1 = 100;
            y1 = 1500;
            deltax1 = 5;
            deltay1 = 5;
            deltax2 = 5;
            deltay2 = 5;
            x2 = 100;
            y2 = 200;
            r = 50;
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawColor(Color.Yellow);

            DrawBalls(canvas);
            DrawText(canvas);
            DrawRect(canvas);
            Invalidate();

        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            // control the ball when the screen is touched
            int x, y;
            if (MotionEventActions.Move == e.Action)
            {
                x = (int)e.GetX();
                y = (int)e.GetY();
                if (y > 1000)
                {
                    x1 = x;
                    y1 = y;
                }
                else
                {
                    x2 = x;
                    y2 = y;
                }
            }
            return true;
        }
        protected void DrawRect(Canvas canvas)
        {
            base.OnDraw(canvas);
            Rect r = new Rect();
            r.Set(0, canvas.Height/2 - 50, canvas.Width, canvas.Height/2 + 50);
            Paint p = new Paint();
            p.Color = Color.Red;
            canvas.DrawRect(r, p);

        }
        protected void DrawText(Canvas canvas)
        {
            Paint paintTitle = new Paint();
            paintTitle.SetARGB(50, 20, 50, 100);
            paintTitle.TextAlign = Paint.Align.Center;
            paintTitle.TextSize = 100;
            canvas.DrawText("Hello Amos", canvas.Width/2, 75, paintTitle);
        }
        protected void DrawBalls(Canvas canvas)
        {
            canvas.DrawCircle(x1, y1, r, p);
            canvas.DrawCircle(x2, y2, r, p);
            x1 = x1 + deltax1;
            y1 = y1 + deltay1;

            x2 = x2 + deltax2;
            y2 = y2 + deltay2;
            if (x2-r < 0 || x2 > canvas.Width - r)
                deltax2 = -deltax2;

            if (y2-r < 0 || y2 > canvas.Height/2-50 - r)
                deltay2 = -deltay2;

            if (x1-r < 0 || x1 > canvas.Width - r)
                deltax1 = -deltax1;

            if (y1+r > canvas.Height || y1 < canvas.Height/2+50 + r)
                deltay1 = -deltay1;
        }
    }
}
