package crc6478e31cf64fdc3b32;


public class TicTacToeButton
	extends android.widget.Button
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TicTacToe_OOP.TicTacToeButton, TicTacToe_OOP", TicTacToeButton.class, __md_methods);
	}


	public TicTacToeButton (android.content.Context p0)
	{
		super (p0);
		if (getClass () == TicTacToeButton.class) {
			mono.android.TypeManager.Activate ("TicTacToe_OOP.TicTacToeButton, TicTacToe_OOP", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public TicTacToeButton (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == TicTacToeButton.class) {
			mono.android.TypeManager.Activate ("TicTacToe_OOP.TicTacToeButton, TicTacToe_OOP", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public TicTacToeButton (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == TicTacToeButton.class) {
			mono.android.TypeManager.Activate ("TicTacToe_OOP.TicTacToeButton, TicTacToe_OOP", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public TicTacToeButton (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == TicTacToeButton.class) {
			mono.android.TypeManager.Activate ("TicTacToe_OOP.TicTacToeButton, TicTacToe_OOP", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
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
