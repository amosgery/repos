package crc64d08b0d92c0bc1521;


public class PlayQuoteActivity
	extends androidx.fragment.app.FragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Fragments.PlayQuoteActivity, Fragments", PlayQuoteActivity.class, __md_methods);
	}


	public PlayQuoteActivity ()
	{
		super ();
		if (getClass () == PlayQuoteActivity.class) {
			mono.android.TypeManager.Activate ("Fragments.PlayQuoteActivity, Fragments", "", this, new java.lang.Object[] {  });
		}
	}


	public PlayQuoteActivity (int p0)
	{
		super (p0);
		if (getClass () == PlayQuoteActivity.class) {
			mono.android.TypeManager.Activate ("Fragments.PlayQuoteActivity, Fragments", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
