package crc646d4583e60b3ec986;


public class MyCountdownTimer
	extends android.os.CountDownTimer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTick:(J)V:GetOnTick_JHandler\n" +
			"n_onFinish:()V:GetOnFinishHandler\n" +
			"";
		mono.android.Runtime.register ("CountDownTimer.MyCountdownTimer, CountDownTimer", MyCountdownTimer.class, __md_methods);
	}


	public MyCountdownTimer (long p0, long p1)
	{
		super (p0, p1);
		if (getClass () == MyCountdownTimer.class) {
			mono.android.TypeManager.Activate ("CountDownTimer.MyCountdownTimer, CountDownTimer", "System.Int64, mscorlib:System.Int64, mscorlib", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void onTick (long p0)
	{
		n_onTick (p0);
	}

	private native void n_onTick (long p0);


	public void onFinish ()
	{
		n_onFinish ();
	}

	private native void n_onFinish ();

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
