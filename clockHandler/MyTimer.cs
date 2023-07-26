using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace clockHandler
{
    public class MyTimer
    {
        int c;
        Handler handler;
        public bool stop { get; set; }
        public MyTimer(Handler handler, int c)
        {
            this.handler = handler;
            this.c = c;
        }
        public void Start()
        {
            ThreadStart threadStart = new ThreadStart(Run);
            Thread t = new Thread(threadStart);
            this.stop = false;
            t.Start();
        }

        void Run()
        {
            while (c > 0)
            {
                 if (!stop)
                 {
                    c--;
                    Thread.Sleep(1000);
                    Message msg = new Message();
                    msg.Arg1 = c;
                    handler.SendMessage(msg);
                 }
            }
        }
    }
}