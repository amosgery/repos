package crc64deac799334a64deb;


public class GetNameResultCallBack
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.activity.result.ActivityResultCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onActivityResult:(Ljava/lang/Object;)V:GetOnActivityResult_Ljava_lang_Object_Handler:AndroidX.Activity.Result.IActivityResultCallbackInvoker, Xamarin.AndroidX.Activity\n" +
			"";
		mono.android.Runtime.register ("NewActivityResult.GetNameResultCallBack, NewActivityResult", GetNameResultCallBack.class, __md_methods);
	}


	public GetNameResultCallBack ()
	{
		super ();
		if (getClass () == GetNameResultCallBack.class) {
			mono.android.TypeManager.Activate ("NewActivityResult.GetNameResultCallBack, NewActivityResult", "", this, new java.lang.Object[] {  });
		}
	}

	public GetNameResultCallBack (android.widget.TextView p0)
	{
		super ();
		if (getClass () == GetNameResultCallBack.class) {
			mono.android.TypeManager.Activate ("NewActivityResult.GetNameResultCallBack, NewActivityResult", "Android.Widget.TextView, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public void onActivityResult (java.lang.Object p0)
	{
		n_onActivityResult (p0);
	}

	private native void n_onActivityResult (java.lang.Object p0);

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
