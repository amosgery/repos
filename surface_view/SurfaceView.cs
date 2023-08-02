using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace surface_view
{
    public class DrawSurfaceView : SurfaceView
    {
        public bool threadRunning = true;
        public bool isRunning = true;

        int deltax = 10, deltay = 10;
        public Context context;
        // Bitmap pic;
        float coordx, coordy;
        Paint p;

        public Thread t;
        ThreadStart ts;
        public DrawSurfaceView(Context context) : base(context)
        {
            this.context = context;
            coordx = 0;
            coordy = 0;
            //pic = BitmapFactory.DecodeResource(Context.Resources, Resource.Drawable.a3);
            p = new Paint();
            p.Color = Color.Yellow;
            p.StrokeWidth = 20;
            ts = new ThreadStart(Run);
            t = new Thread(ts);
        }
        public void SurfaceCreated(ISurfaceHolder holder)
        {

        }
        public void SurfaceDestroyed(ISurfaceHolder holder)
        {

        }
        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {


        }

        public void destroy()
        {
            isRunning = false;
            ((GameActivity)context).Finish();
        }


        public void pause()
        {
            isRunning = false;
        }


        public void resume()
        {
            isRunning = true;
        }


        public void startGame()
        {
            isRunning = true;
        }
        public void Run()
        {
            while (threadRunning)
            {
                if (isRunning)
                {
                    if (!this.Holder.Surface.IsValid)
                        continue;
                    Canvas c = null;
                    try
                    {
                        c = this.Holder.LockCanvas();
                        c.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
                        coordx += deltax;
                        coordy += deltay;
                        if (coordx < 0 || coordx > c.Width - 30)
                            deltax = -1 * deltax;
                        if (coordy < 0 || coordy > c.Height - 30)
                            deltay = -1 * deltay;
                        c.DrawCircle(coordx, coordy, 30, p);
                    }
                    catch (Exception e)
                    {

                    }

                    finally
                    {
                        if (c != null)
                        {
                            this.Holder.UnlockCanvasAndPost(c);
                        }
                    }

                }
            }
        }//end of run
        public override bool OnTouchEvent(MotionEvent e)
        {
            if (MotionEventActions.Up == e.Action)
            {
                coordx = e.GetX();
                coordy = e.GetY();
                Toast.MakeText(context, "coord:(" + coordx + "," + coordy + ")", ToastLength.Long).Show();

            }
            return true;
        }
    }
}