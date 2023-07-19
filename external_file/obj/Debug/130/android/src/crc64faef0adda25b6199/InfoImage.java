package crc64faef0adda25b6199;


public class InfoImage
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("external_file.InfoImage, external_file", InfoImage.class, __md_methods);
	}


	public InfoImage ()
	{
		super ();
		if (getClass () == InfoImage.class) {
			mono.android.TypeManager.Activate ("external_file.InfoImage, external_file", "", this, new java.lang.Object[] {  });
		}
	}

	public InfoImage (java.io.File p0, android.graphics.Bitmap p1)
	{
		super ();
		if (getClass () == InfoImage.class) {
			mono.android.TypeManager.Activate ("external_file.InfoImage, external_file", "Java.IO.File, Mono.Android:Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}

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
