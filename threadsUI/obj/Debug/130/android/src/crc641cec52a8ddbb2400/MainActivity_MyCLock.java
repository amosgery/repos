package crc641cec52a8ddbb2400;


public class MainActivity_MyCLock
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onProgressUpdate:([Ljava/lang/Object;)V:GetOnProgressUpdate_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("threadsUI.MainActivity+MyCLock, threadsUI", MainActivity_MyCLock.class, __md_methods);
	}


	public MainActivity_MyCLock ()
	{
		super ();
		if (getClass () == MainActivity_MyCLock.class) {
			mono.android.TypeManager.Activate ("threadsUI.MainActivity+MyCLock, threadsUI", "", this, new java.lang.Object[] {  });
		}
	}

	public MainActivity_MyCLock (int p0, android.widget.Button p1)
	{
		super ();
		if (getClass () == MainActivity_MyCLock.class) {
			mono.android.TypeManager.Activate ("threadsUI.MainActivity+MyCLock, threadsUI", "System.Int32, mscorlib:Android.Widget.Button, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onProgressUpdate (java.lang.Object[] p0)
	{
		n_onProgressUpdate (p0);
	}

	private native void n_onProgressUpdate (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

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
