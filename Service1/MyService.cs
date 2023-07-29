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
using AndroidX.LocalBroadcastManager.Content;
using Java.Util;
using Java.Util.Logging;
using Xamarin.Essentials;

namespace Service1
{
    [Service]
    public class MyService : Service
    {
        int counter = 3;
        MyHandler myHandler;
        int id = System.DateTime.Now.Millisecond;
        public override void OnCreate()
        {
            base.OnCreate();
            myHandler = new MyHandler(this);
        }

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            counter = intent.GetIntExtra("counter", 3);
            Toast.MakeText(this, "The demo service has started " + counter, ToastLength.Long).Show();
            ThreadStart threadStart = new ThreadStart(Run);
            Thread thread = new Thread(threadStart);
            thread.Start();

            return base.OnStartCommand(intent, flags, startId);
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override Android.OS.IBinder OnBind(Android.Content.Intent intent)
        {
            return null;
        }

        public void Run()
        {
            while (counter > 0)
            {
                //Toast.MakeText(this, "The demo service has started", ToastLength.Long).Show();
                Thread.Sleep(5000);
                Message message = new Message();
                message.Arg1 = counter;
                message.Arg2 = id;
                myHandler.SendMessage(message);
                counter--;
                //Toast.MakeText(this, "The demo service has competed", ToastLength.Long).Show();
            }
            StopSelf();
        }
    }

    [Service]
    public class MyIntentService : IntentService
    {
        int counter;
        int id = System.DateTime.Now.Millisecond;
        MyHandler myHandler;
        public MyIntentService() : base("DemoIntentService")
        {
            myHandler = new MyHandler(this);
            Console.WriteLine("service started, id = " + id);
        }
        protected override void OnHandleIntent(Android.Content.Intent intent)
        {
            counter = 10;
            while (counter > 0)
            {
                Thread.Sleep(1000);
                counter--;
                Message m = new Message();
                m.Arg1 = counter;
                m.Arg2 = id;
                myHandler.SendMessage(m);

            }
            StopSelf();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Console.WriteLine("Service stopped, id = " + id);
            counter = 0;
        }
    }
}