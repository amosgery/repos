; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [140 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 37
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 55
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 7
	i32 63404453, ; 3: firebase_client.dll => 0x3c779a5 => 0
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 46
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 46
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 24
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 47
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 22
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 34
	i32 232815796, ; 10: System.Web.Services => 0xde07cb4 => 67
	i32 280482487, ; 11: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 32
	i32 318968648, ; 12: Xamarin.AndroidX.Activity.dll => 0x13031348 => 15
	i32 321597661, ; 13: System.Numerics => 0x132b30dd => 10
	i32 342366114, ; 14: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 35
	i32 360750165, ; 15: firebase_client => 0x15809c55 => 0
	i32 393699800, ; 16: Firebase => 0x177761d8 => 2
	i32 442521989, ; 17: Xamarin.Essentials => 0x1a605985 => 53
	i32 450948140, ; 18: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 31
	i32 465846621, ; 19: mscorlib => 0x1bc4415d => 6
	i32 469710990, ; 20: System.dll => 0x1bff388e => 9
	i32 476646585, ; 21: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 32
	i32 486930444, ; 22: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 41
	i32 526420162, ; 23: System.Transactions.dll => 0x1f6088c2 => 58
	i32 605376203, ; 24: System.IO.Compression.FileSystem => 0x24154ecb => 62
	i32 610194910, ; 25: System.Reactive.dll => 0x245ed5de => 12
	i32 627609679, ; 26: Xamarin.AndroidX.CustomView => 0x2568904f => 28
	i32 663517072, ; 27: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 51
	i32 666292255, ; 28: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 19
	i32 690569205, ; 29: System.Xml.Linq.dll => 0x29293ff5 => 68
	i32 775507847, ; 30: System.IO.Compression => 0x2e394f87 => 61
	i32 809851609, ; 31: System.Drawing.Common.dll => 0x30455ad9 => 60
	i32 843511501, ; 32: Xamarin.AndroidX.Print => 0x3246f6cd => 43
	i32 928116545, ; 33: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 55
	i32 955402788, ; 34: Newtonsoft.Json => 0x38f24a24 => 7
	i32 967690846, ; 35: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 35
	i32 1012816738, ; 36: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 45
	i32 1035644815, ; 37: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 18
	i32 1052210849, ; 38: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 38
	i32 1098259244, ; 39: System => 0x41761b2c => 9
	i32 1175144683, ; 40: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 49
	i32 1204270330, ; 41: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 19
	i32 1267360935, ; 42: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 50
	i32 1293217323, ; 43: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 30
	i32 1365406463, ; 44: System.ServiceModel.Internals.dll => 0x516272ff => 66
	i32 1376866003, ; 45: Xamarin.AndroidX.SavedState => 0x52114ed3 => 45
	i32 1406073936, ; 46: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 25
	i32 1462112819, ; 47: System.IO.Compression.dll => 0x57261233 => 61
	i32 1469204771, ; 48: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 17
	i32 1582372066, ; 49: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 29
	i32 1592978981, ; 50: System.Runtime.Serialization.dll => 0x5ef2ee25 => 65
	i32 1622152042, ; 51: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 40
	i32 1636350590, ; 52: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 27
	i32 1639515021, ; 53: System.Net.Http.dll => 0x61b9038d => 64
	i32 1657153582, ; 54: System.Runtime => 0x62c6282e => 13
	i32 1658251792, ; 55: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 54
	i32 1729485958, ; 56: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 23
	i32 1766324549, ; 57: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 47
	i32 1776026572, ; 58: System.Core.dll => 0x69dc03cc => 8
	i32 1788241197, ; 59: Xamarin.AndroidX.Fragment => 0x6a96652d => 31
	i32 1808609942, ; 60: Xamarin.AndroidX.Loader => 0x6bcd3296 => 40
	i32 1813201214, ; 61: Xamarin.Google.Android.Material => 0x6c13413e => 54
	i32 1867746548, ; 62: Xamarin.Essentials.dll => 0x6f538cf4 => 53
	i32 1885316902, ; 63: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 20
	i32 1904755420, ; 64: System.Runtime.InteropServices.WindowsRuntime.dll => 0x718842dc => 1
	i32 1919157823, ; 65: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 42
	i32 2019465201, ; 66: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 38
	i32 2055257422, ; 67: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 36
	i32 2079903147, ; 68: System.Runtime.dll => 0x7bf8cdab => 13
	i32 2090596640, ; 69: System.Numerics.Vectors => 0x7c9bf920 => 11
	i32 2097448633, ; 70: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 33
	i32 2201231467, ; 71: System.Net.Http => 0x8334206b => 64
	i32 2217644978, ; 72: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 49
	i32 2244775296, ; 73: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 41
	i32 2256548716, ; 74: Xamarin.AndroidX.MultiDex => 0x8680336c => 42
	i32 2279755925, ; 75: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 44
	i32 2315684594, ; 76: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 16
	i32 2471841756, ; 77: netstandard.dll => 0x93554fdc => 56
	i32 2475788418, ; 78: Java.Interop.dll => 0x93918882 => 3
	i32 2501346920, ; 79: System.Data.DataSetExtensions => 0x95178668 => 59
	i32 2505896520, ; 80: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 37
	i32 2581819634, ; 81: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 50
	i32 2620871830, ; 82: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 27
	i32 2732626843, ; 83: Xamarin.AndroidX.Activity => 0xa2e0939b => 15
	i32 2737747696, ; 84: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 17
	i32 2778768386, ; 85: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 52
	i32 2810250172, ; 86: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 25
	i32 2819470561, ; 87: System.Xml.dll => 0xa80db4e1 => 14
	i32 2853208004, ; 88: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 52
	i32 2855708567, ; 89: Xamarin.AndroidX.Transition => 0xaa36a797 => 48
	i32 2903344695, ; 90: System.ComponentModel.Composition => 0xad0d8637 => 63
	i32 2905242038, ; 91: mscorlib.dll => 0xad2a79b6 => 6
	i32 2919462931, ; 92: System.Numerics.Vectors.dll => 0xae037813 => 11
	i32 2978675010, ; 93: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 30
	i32 3024354802, ; 94: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 34
	i32 3111772706, ; 95: System.Runtime.Serialization => 0xb979e222 => 65
	i32 3204380047, ; 96: System.Data.dll => 0xbefef58f => 57
	i32 3211777861, ; 97: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 29
	i32 3247949154, ; 98: Mono.Security => 0xc197c562 => 69
	i32 3258312781, ; 99: Xamarin.AndroidX.CardView => 0xc235e84d => 23
	i32 3267021929, ; 100: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 21
	i32 3317135071, ; 101: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 28
	i32 3317144872, ; 102: System.Data => 0xc5b79d28 => 57
	i32 3322403133, ; 103: Firebase.dll => 0xc607d93d => 2
	i32 3340431453, ; 104: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 20
	i32 3353484488, ; 105: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 33
	i32 3362522851, ; 106: Xamarin.AndroidX.Core => 0xc86c06e3 => 26
	i32 3366347497, ; 107: Java.Interop => 0xc8a662e9 => 3
	i32 3374999561, ; 108: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 44
	i32 3404865022, ; 109: System.ServiceModel.Internals => 0xcaf21dfe => 66
	i32 3429136800, ; 110: System.Xml => 0xcc6479a0 => 14
	i32 3430777524, ; 111: netstandard => 0xcc7d82b4 => 56
	i32 3476120550, ; 112: Mono.Android => 0xcf3163e6 => 5
	i32 3486566296, ; 113: System.Transactions => 0xcfd0c798 => 58
	i32 3501239056, ; 114: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 21
	i32 3509114376, ; 115: System.Xml.Linq => 0xd128d608 => 68
	i32 3567349600, ; 116: System.ComponentModel.Composition.dll => 0xd4a16f60 => 63
	i32 3596207933, ; 117: LiteDB.dll => 0xd659c73d => 4
	i32 3627220390, ; 118: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 43
	i32 3629588173, ; 119: LiteDB => 0xd8571ecd => 4
	i32 3641597786, ; 120: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 36
	i32 3672681054, ; 121: Mono.Android.dll => 0xdae8aa5e => 5
	i32 3676310014, ; 122: System.Web.Services.dll => 0xdb2009fe => 67
	i32 3682565725, ; 123: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 22
	i32 3684933406, ; 124: System.Runtime.InteropServices.WindowsRuntime => 0xdba39f1e => 1
	i32 3689375977, ; 125: System.Drawing.Common => 0xdbe768e9 => 60
	i32 3718780102, ; 126: Xamarin.AndroidX.Annotation => 0xdda814c6 => 16
	i32 3731644420, ; 127: System.Reactive => 0xde6c6004 => 12
	i32 3786282454, ; 128: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 24
	i32 3829621856, ; 129: System.Numerics.dll => 0xe4436460 => 10
	i32 3885922214, ; 130: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 48
	i32 3896760992, ; 131: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 26
	i32 3920810846, ; 132: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 62
	i32 3921031405, ; 133: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 51
	i32 3945713374, ; 134: System.Data.DataSetExtensions.dll => 0xeb2ecede => 59
	i32 3955647286, ; 135: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 18
	i32 4105002889, ; 136: Mono.Security.dll => 0xf4ad5f89 => 69
	i32 4151237749, ; 137: System.Core => 0xf76edc75 => 8
	i32 4182413190, ; 138: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 39
	i32 4292120959 ; 139: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 39
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [140 x i32] [
	i32 37, i32 55, i32 7, i32 0, i32 46, i32 46, i32 24, i32 47, ; 0..7
	i32 22, i32 34, i32 67, i32 32, i32 15, i32 10, i32 35, i32 0, ; 8..15
	i32 2, i32 53, i32 31, i32 6, i32 9, i32 32, i32 41, i32 58, ; 16..23
	i32 62, i32 12, i32 28, i32 51, i32 19, i32 68, i32 61, i32 60, ; 24..31
	i32 43, i32 55, i32 7, i32 35, i32 45, i32 18, i32 38, i32 9, ; 32..39
	i32 49, i32 19, i32 50, i32 30, i32 66, i32 45, i32 25, i32 61, ; 40..47
	i32 17, i32 29, i32 65, i32 40, i32 27, i32 64, i32 13, i32 54, ; 48..55
	i32 23, i32 47, i32 8, i32 31, i32 40, i32 54, i32 53, i32 20, ; 56..63
	i32 1, i32 42, i32 38, i32 36, i32 13, i32 11, i32 33, i32 64, ; 64..71
	i32 49, i32 41, i32 42, i32 44, i32 16, i32 56, i32 3, i32 59, ; 72..79
	i32 37, i32 50, i32 27, i32 15, i32 17, i32 52, i32 25, i32 14, ; 80..87
	i32 52, i32 48, i32 63, i32 6, i32 11, i32 30, i32 34, i32 65, ; 88..95
	i32 57, i32 29, i32 69, i32 23, i32 21, i32 28, i32 57, i32 2, ; 96..103
	i32 20, i32 33, i32 26, i32 3, i32 44, i32 66, i32 14, i32 56, ; 104..111
	i32 5, i32 58, i32 21, i32 68, i32 63, i32 4, i32 43, i32 4, ; 112..119
	i32 36, i32 5, i32 67, i32 22, i32 1, i32 60, i32 16, i32 12, ; 120..127
	i32 24, i32 10, i32 48, i32 26, i32 62, i32 51, i32 59, i32 18, ; 128..135
	i32 69, i32 8, i32 39, i32 39 ; 136..139
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}