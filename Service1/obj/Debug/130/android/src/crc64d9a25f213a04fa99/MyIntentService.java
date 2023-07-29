package crc64d9a25f213a04fa99;


public class MyIntentService
	extends mono.android.app.IntentService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onHandleIntent:(Landroid/content/Intent;)V:GetOnHandleIntent_Landroid_content_Intent_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("Service1.MyIntentService, Service1", MyIntentService.class, __md_methods);
	}


	public MyIntentService (java.lang.String p0)
	{
		super (p0);
		if (getClass () == MyIntentService.class) {
			mono.android.TypeManager.Activate ("Service1.MyIntentService, Service1", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
		}
	}


	public MyIntentService ()
	{
		super ();
		if (getClass () == MyIntentService.class) {
			mono.android.TypeManager.Activate ("Service1.MyIntentService, Service1", "", this, new java.lang.Object[] {  });
		}
	}


	public void onHandleIntent (android.content.Intent p0)
	{
		n_onHandleIntent (p0);
	}

	private native void n_onHandleIntent (android.content.Intent p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

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
