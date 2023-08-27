; ModuleID = 'obj\Debug\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [164 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 16
	i64 210515253464952879, ; 1: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 36
	i64 232391251801502327, ; 2: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 57
	i64 295915112840604065, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 58
	i64 464346026994987652, ; 4: System.Reactive.dll => 0x671b04057e67284 => 24
	i64 634308326490598313, ; 5: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 49
	i64 702024105029695270, ; 6: System.Drawing.Common => 0x9be17343c0e7726 => 71
	i64 718159679911342543, ; 7: FirebaseAdmin.dll => 0x9f76a6c851fb1cf => 6
	i64 720058930071658100, ; 8: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 45
	i64 872800313462103108, ; 9: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 42
	i64 940822596282819491, ; 10: System.Transactions => 0xd0e792aa81923a3 => 69
	i64 1000557547492888992, ; 11: Mono.Security.dll => 0xde2b1c9cba651a0 => 81
	i64 1120440138749646132, ; 12: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 66
	i64 1315114680217950157, ; 13: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 31
	i64 1425944114962822056, ; 14: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 76
	i64 1624659445732251991, ; 15: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 29
	i64 1628611045998245443, ; 16: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 51
	i64 1636321030536304333, ; 17: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 46
	i64 1731380447121279447, ; 18: Newtonsoft.Json => 0x18071957e9b889d7 => 18
	i64 1743969030606105336, ; 19: System.Memory.dll => 0x1833d297e88f2af8 => 80
	i64 1795316252682057001, ; 20: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 30
	i64 1836611346387731153, ; 21: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 57
	i64 1865037103900624886, ; 22: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 15
	i64 1875917498431009007, ; 23: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 28
	i64 1981742497975770890, ; 24: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 50
	i64 2040001226662520565, ; 25: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 2
	i64 2133195048986300728, ; 26: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 18
	i64 2136356949452311481, ; 27: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 54
	i64 2165725771938924357, ; 28: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 34
	i64 2262844636196693701, ; 29: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 42
	i64 2284400282711631002, ; 30: System.Web.Services => 0x1fb3d1f42fd4249a => 78
	i64 2329709569556905518, ; 31: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 48
	i64 2470498323731680442, ; 32: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 37
	i64 2479423007379663237, ; 33: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 61
	i64 2497223385847772520, ; 34: System.Runtime => 0x22a7eb7046413568 => 25
	i64 2547086958574651984, ; 35: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 27
	i64 2592350477072141967, ; 36: System.Xml.dll => 0x23f9e10627330e8f => 26
	i64 2624866290265602282, ; 37: mscorlib.dll => 0x246d65fbde2db8ea => 17
	i64 2812926542227278819, ; 38: Google.Apis.Core.dll => 0x270985c960b98be3 => 11
	i64 3017704767998173186, ; 39: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 66
	i64 3289520064315143713, ; 40: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 47
	i64 3311221304742556517, ; 41: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 23
	i64 3522470458906976663, ; 42: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 59
	i64 3531994851595924923, ; 43: System.Numerics => 0x31042a9aade235bb => 22
	i64 3571415421602489686, ; 44: System.Runtime.dll => 0x319037675df7e556 => 25
	i64 3716579019761409177, ; 45: netstandard.dll => 0x3393f0ed5c8c5c99 => 1
	i64 3727469159507183293, ; 46: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 56
	i64 3966267475168208030, ; 47: System.Memory => 0x370b03412596249e => 80
	i64 4056584864658557221, ; 48: Google.Apis.Auth => 0x384be27113330925 => 9
	i64 4525561845656915374, ; 49: System.ServiceModel.Internals => 0x3ece06856b710dae => 77
	i64 4594317890085945673, ; 50: first_firebase_app => 0x3fc24bc77fcb8149 => 0
	i64 4636684751163556186, ; 51: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 63
	i64 4782108999019072045, ; 52: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 33
	i64 4794310189461587505, ; 53: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 27
	i64 4795410492532947900, ; 54: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 59
	i64 5203618020066742981, ; 55: Xamarin.Essentials => 0x4836f704f0e652c5 => 65
	i64 5205316157927637098, ; 56: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 53
	i64 5376510917114486089, ; 57: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 61
	i64 5408338804355907810, ; 58: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 60
	i64 5507995362134886206, ; 59: System.Core.dll => 0x4c705499688c873e => 20
	i64 5665389054145784248, ; 60: Google.Apis.Core => 0x4e9f815406bee9b8 => 11
	i64 6218967553231149354, ; 61: Firebase.Auth.dll => 0x564e360a4805d92a => 4
	i64 6319713645133255417, ; 62: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 49
	i64 6401687960814735282, ; 63: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 48
	i64 6504860066809920875, ; 64: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 34
	i64 6548213210057960872, ; 65: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 40
	i64 6591024623626361694, ; 66: System.Web.Services.dll => 0x5b7805f9751a1b5e => 78
	i64 6659513131007730089, ; 67: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 45
	i64 6876862101832370452, ; 68: System.Xml.Linq => 0x5f6f85a57d108914 => 79
	i64 6894844156784520562, ; 69: System.Numerics.Vectors => 0x5faf683aead1ad72 => 23
	i64 6934772601320367100, ; 70: Google.Api.Gax.Rest => 0x603d42f05bcfe3fc => 8
	i64 6941080589610463230, ; 71: Google.Apis.Auth.PlatformServices => 0x6053ac0555172ffe => 10
	i64 7103753931438454322, ; 72: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 44
	i64 7141577505875122296, ; 73: System.Runtime.InteropServices.WindowsRuntime.dll => 0x631bfae7659b5878 => 3
	i64 7488575175965059935, ; 74: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 79
	i64 7602111570124318452, ; 75: System.Reactive => 0x698020320025a6f4 => 24
	i64 7637365915383206639, ; 76: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 65
	i64 7654504624184590948, ; 77: System.Net.Http => 0x6a3a4366801b8264 => 75
	i64 7820441508502274321, ; 78: System.Data => 0x6c87ca1e14ff8111 => 68
	i64 7836164640616011524, ; 79: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 29
	i64 8044118961405839122, ; 80: System.ComponentModel.Composition => 0x6fa2739369944712 => 74
	i64 8083354569033831015, ; 81: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 47
	i64 8103644804370223335, ; 82: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 70
	i64 8167236081217502503, ; 83: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 13
	i64 8518412311883997971, ; 84: System.Collections.Immutable => 0x76377add7c28e313 => 19
	i64 8601935802264776013, ; 85: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 60
	i64 8626175481042262068, ; 86: Java.Interop => 0x77b654e585b55834 => 13
	i64 8684531736582871431, ; 87: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 73
	i64 8702320156596882678, ; 88: Firebase.dll => 0x78c4da1357adccf6 => 5
	i64 9057635389615298436, ; 89: LiteDB => 0x7db32f65bf06d784 => 14
	i64 9296667808972889535, ; 90: LiteDB.dll => 0x8104661dcca35dbf => 14
	i64 9324707631942237306, ; 91: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 30
	i64 9662334977499516867, ; 92: System.Numerics.dll => 0x8617827802b0cfc3 => 22
	i64 9678050649315576968, ; 93: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 37
	i64 9808709177481450983, ; 94: Mono.Android.dll => 0x881f890734e555e7 => 16
	i64 9834056768316610435, ; 95: System.Transactions.dll => 0x8879968718899783 => 69
	i64 9998632235833408227, ; 96: Mono.Security => 0x8ac2470b209ebae3 => 81
	i64 10038780035334861115, ; 97: System.Net.Http.dll => 0x8b50e941206af13b => 75
	i64 10144742755892837524, ; 98: Firebase => 0x8cc95dc98eb5bc94 => 5
	i64 10218821437939648382, ; 99: Google.Apis.Auth.PlatformServices.dll => 0x8dd08bf4c78a077e => 10
	i64 10220684565739810458, ; 100: FirebaseAdmin => 0x8dd72a76063d2e9a => 6
	i64 10229024438826829339, ; 101: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 40
	i64 10430153318873392755, ; 102: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 38
	i64 10447083246144586668, ; 103: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 15
	i64 10688576702998981507, ; 104: first_firebase_app.dll => 0x945573e180c52b83 => 0
	i64 10823124638835005028, ; 105: Google.Api.Gax.dll => 0x963376840189d664 => 7
	i64 10847732767863316357, ; 106: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 31
	i64 11023048688141570732, ; 107: System.Core => 0x98f9bc61168392ac => 20
	i64 11037814507248023548, ; 108: System.Xml => 0x992e31d0412bf7fc => 26
	i64 11162124722117608902, ; 109: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 64
	i64 11340910727871153756, ; 110: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 39
	i64 11392833485892708388, ; 111: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 55
	i64 11529969570048099689, ; 112: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 64
	i64 11580057168383206117, ; 113: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 28
	i64 11597940890313164233, ; 114: netstandard => 0xa0f429ca8d1805c9 => 1
	i64 11672361001936329215, ; 115: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 44
	i64 12137774235383566651, ; 116: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 62
	i64 12269460666702402136, ; 117: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 19
	i64 12437742355241350664, ; 118: Google.Apis.dll => 0xac9bbcc62bfdb608 => 12
	i64 12451044538927396471, ; 119: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 43
	i64 12466513435562512481, ; 120: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 52
	i64 12487638416075308985, ; 121: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 41
	i64 12528155905152483962, ; 122: Firebase.Auth => 0xaddcf36b3153827a => 4
	i64 12538491095302438457, ; 123: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 35
	i64 12550732019250633519, ; 124: System.IO.Compression => 0xae2d28465e8e1b2f => 72
	i64 12700543734426720211, ; 125: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 36
	i64 12722065664929968482, ; 126: Google.Api.Gax.Rest.dll => 0xb08ddb515f583162 => 8
	i64 12958614573187252691, ; 127: Google.Apis => 0xb3d63f4bf006c1d3 => 12
	i64 12963446364377008305, ; 128: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 71
	i64 13370592475155966277, ; 129: System.Runtime.Serialization => 0xb98de304062ea945 => 76
	i64 13401370062847626945, ; 130: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 62
	i64 13454009404024712428, ; 131: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 67
	i64 13491513212026656886, ; 132: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 32
	i64 13572454107664307259, ; 133: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 56
	i64 13647894001087880694, ; 134: System.Data.dll => 0xbd670f48cb071df6 => 68
	i64 13782512541859110153, ; 135: Google.Apis.Auth.dll => 0xbf45522249e0dd09 => 9
	i64 13959074834287824816, ; 136: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 43
	i64 14124974489674258913, ; 137: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 35
	i64 14172845254133543601, ; 138: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 54
	i64 14261073672896646636, ; 139: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 55
	i64 14644440854989303794, ; 140: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 53
	i64 14792063746108907174, ; 141: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 67
	i64 14852515768018889994, ; 142: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 39
	i64 14987728460634540364, ; 143: System.IO.Compression.dll => 0xcfff1ba06622494c => 72
	i64 14988210264188246988, ; 144: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 41
	i64 15370334346939861994, ; 145: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 38
	i64 15582737692548360875, ; 146: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 51
	i64 15609085926864131306, ; 147: System.dll => 0xd89e9cf3334914ea => 21
	i64 15777549416145007739, ; 148: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 58
	i64 15963349826457351533, ; 149: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 2
	i64 16154507427712707110, ; 150: System => 0xe03056ea4e39aa26 => 21
	i64 16565028646146589191, ; 151: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 74
	i64 16822611501064131242, ; 152: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 70
	i64 16833383113903931215, ; 153: mscorlib => 0xe99c30c1484d7f4f => 17
	i64 16866861824412579935, ; 154: System.Runtime.InteropServices.WindowsRuntime => 0xea132176ffb5785f => 3
	i64 16955525858597485057, ; 155: Google.Api.Gax => 0xeb4e20ef25a73a01 => 7
	i64 17037200463775726619, ; 156: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 46
	i64 17544493274320527064, ; 157: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 33
	i64 17704177640604968747, ; 158: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 52
	i64 17710060891934109755, ; 159: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 50
	i64 17928294245072900555, ; 160: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 73
	i64 18116111925905154859, ; 161: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 32
	i64 18129453464017766560, ; 162: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 77
	i64 18380184030268848184 ; 163: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 63
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [164 x i32] [
	i32 16, i32 36, i32 57, i32 58, i32 24, i32 49, i32 71, i32 6, ; 0..7
	i32 45, i32 42, i32 69, i32 81, i32 66, i32 31, i32 76, i32 29, ; 8..15
	i32 51, i32 46, i32 18, i32 80, i32 30, i32 57, i32 15, i32 28, ; 16..23
	i32 50, i32 2, i32 18, i32 54, i32 34, i32 42, i32 78, i32 48, ; 24..31
	i32 37, i32 61, i32 25, i32 27, i32 26, i32 17, i32 11, i32 66, ; 32..39
	i32 47, i32 23, i32 59, i32 22, i32 25, i32 1, i32 56, i32 80, ; 40..47
	i32 9, i32 77, i32 0, i32 63, i32 33, i32 27, i32 59, i32 65, ; 48..55
	i32 53, i32 61, i32 60, i32 20, i32 11, i32 4, i32 49, i32 48, ; 56..63
	i32 34, i32 40, i32 78, i32 45, i32 79, i32 23, i32 8, i32 10, ; 64..71
	i32 44, i32 3, i32 79, i32 24, i32 65, i32 75, i32 68, i32 29, ; 72..79
	i32 74, i32 47, i32 70, i32 13, i32 19, i32 60, i32 13, i32 73, ; 80..87
	i32 5, i32 14, i32 14, i32 30, i32 22, i32 37, i32 16, i32 69, ; 88..95
	i32 81, i32 75, i32 5, i32 10, i32 6, i32 40, i32 38, i32 15, ; 96..103
	i32 0, i32 7, i32 31, i32 20, i32 26, i32 64, i32 39, i32 55, ; 104..111
	i32 64, i32 28, i32 1, i32 44, i32 62, i32 19, i32 12, i32 43, ; 112..119
	i32 52, i32 41, i32 4, i32 35, i32 72, i32 36, i32 8, i32 12, ; 120..127
	i32 71, i32 76, i32 62, i32 67, i32 32, i32 56, i32 68, i32 9, ; 128..135
	i32 43, i32 35, i32 54, i32 55, i32 53, i32 67, i32 39, i32 72, ; 136..143
	i32 41, i32 38, i32 51, i32 21, i32 58, i32 2, i32 21, i32 74, ; 144..151
	i32 70, i32 17, i32 3, i32 7, i32 46, i32 33, i32 52, i32 50, ; 152..159
	i32 73, i32 32, i32 77, i32 63 ; 160..163
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
