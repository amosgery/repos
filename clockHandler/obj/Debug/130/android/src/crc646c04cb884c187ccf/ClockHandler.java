package crc646c04cb884c187ccf;


public class ClockHandler
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("clockHandler.ClockHandler, clockHandler", ClockHandler.class, __md_methods);
	}


	public ClockHandler ()
	{
		super ();
		if (getClass () == ClockHandler.class) {
			mono.android.TypeManager.Activate ("clockHandler.ClockHandler, clockHandler", "", this, new java.lang.Object[] {  });
		}
	}


	public ClockHandler (android.os.Handler.Callback p0)
	{
		super (p0);
		if (getClass () == ClockHandler.class) {
			mono.android.TypeManager.Activate ("clockHandler.ClockHandler, clockHandler", "Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public ClockHandler (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == ClockHandler.class) {
			mono.android.TypeManager.Activate ("clockHandler.ClockHandler, clockHandler", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public ClockHandler (android.os.Looper p0, android.os.Handler.Callback p1)
	{
		super (p0, p1);
		if (getClass () == ClockHandler.class) {
			mono.android.TypeManager.Activate ("clockHandler.ClockHandler, clockHandler", "Android.OS.Looper, Mono.Android:Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

	public ClockHandler (android.content.Context p0, android.widget.Button p1)
	{
		super ();
		if (getClass () == ClockHandler.class) {
			mono.android.TypeManager.Activate ("clockHandler.ClockHandler, clockHandler", "Android.Content.Context, Mono.Android:Android.Widget.Button, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
