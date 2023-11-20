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
@assembly_image_cache_hashes = local_unnamed_addr constant [148 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 38
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 59
	i32 101534019, ; 2: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 48
	i32 120558881, ; 3: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 48
	i32 134690465, ; 4: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 67
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 22
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 50
	i32 209399409, ; 7: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 20
	i32 230216969, ; 8: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 35
	i32 280482487, ; 9: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 33
	i32 318968648, ; 10: Xamarin.AndroidX.Activity.dll => 0x13031348 => 11
	i32 321597661, ; 11: System.Numerics => 0x132b30dd => 7
	i32 342366114, ; 12: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 36
	i32 442521989, ; 13: Xamarin.Essentials => 0x1a605985 => 57
	i32 450948140, ; 14: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 32
	i32 465846621, ; 15: mscorlib => 0x1bc4415d => 3
	i32 469710990, ; 16: System.dll => 0x1bff388e => 5
	i32 476646585, ; 17: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 33
	i32 486930444, ; 18: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 42
	i32 527452488, ; 19: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 67
	i32 627609679, ; 20: Xamarin.AndroidX.CustomView => 0x2568904f => 29
	i32 663517072, ; 21: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 55
	i32 666292255, ; 22: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 17
	i32 691348768, ; 23: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 69
	i32 700284507, ; 24: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 64
	i32 720511267, ; 25: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 68
	i32 809851609, ; 26: System.Drawing.Common.dll => 0x30455ad9 => 71
	i32 843511501, ; 27: Xamarin.AndroidX.Print => 0x3246f6cd => 44
	i32 928116545, ; 28: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 59
	i32 956575887, ; 29: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 68
	i32 967690846, ; 30: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 36
	i32 1012816738, ; 31: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 47
	i32 1035644815, ; 32: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 16
	i32 1052210849, ; 33: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 39
	i32 1084122840, ; 34: Xamarin.Kotlin.StdLib => 0x409e66d8 => 66
	i32 1098259244, ; 35: System => 0x41761b2c => 5
	i32 1175144683, ; 36: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 53
	i32 1204270330, ; 37: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 17
	i32 1246548578, ; 38: Xamarin.AndroidX.Collection.Jvm.dll => 0x4a4cd262 => 23
	i32 1264511973, ; 39: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 49
	i32 1267360935, ; 40: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 54
	i32 1275534314, ; 41: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 69
	i32 1278448581, ; 42: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 14
	i32 1293217323, ; 43: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 31
	i32 1376866003, ; 44: Xamarin.AndroidX.SavedState => 0x52114ed3 => 47
	i32 1406073936, ; 45: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 25
	i32 1469204771, ; 46: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 15
	i32 1582372066, ; 47: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 30
	i32 1622152042, ; 48: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 41
	i32 1636350590, ; 49: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 28
	i32 1639515021, ; 50: System.Net.Http.dll => 0x61b9038d => 6
	i32 1657153582, ; 51: System.Runtime => 0x62c6282e => 9
	i32 1658241508, ; 52: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 51
	i32 1658251792, ; 53: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 58
	i32 1698840827, ; 54: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 65
	i32 1729485958, ; 55: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 21
	i32 1766324549, ; 56: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 50
	i32 1776026572, ; 57: System.Core.dll => 0x69dc03cc => 4
	i32 1788241197, ; 58: Xamarin.AndroidX.Fragment => 0x6a96652d => 32
	i32 1808609942, ; 59: Xamarin.AndroidX.Loader => 0x6bcd3296 => 41
	i32 1813058853, ; 60: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 66
	i32 1813201214, ; 61: Xamarin.Google.Android.Material => 0x6c13413e => 58
	i32 1867746548, ; 62: Xamarin.Essentials.dll => 0x6f538cf4 => 57
	i32 1885316902, ; 63: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 18
	i32 1908813208, ; 64: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 61
	i32 1919157823, ; 65: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 43
	i32 1983156543, ; 66: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 65
	i32 2019465201, ; 67: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 39
	i32 2055257422, ; 68: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 37
	i32 2079903147, ; 69: System.Runtime.dll => 0x7bf8cdab => 9
	i32 2090596640, ; 70: System.Numerics.Vectors => 0x7c9bf920 => 8
	i32 2097448633, ; 71: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 34
	i32 2129483829, ; 72: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 60
	i32 2201107256, ; 73: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 70
	i32 2201231467, ; 74: System.Net.Http => 0x8334206b => 6
	i32 2217644978, ; 75: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 53
	i32 2244775296, ; 76: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 42
	i32 2256548716, ; 77: Xamarin.AndroidX.MultiDex => 0x8680336c => 43
	i32 2279755925, ; 78: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 46
	i32 2315684594, ; 79: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 12
	i32 2475788418, ; 80: Java.Interop.dll => 0x93918882 => 1
	i32 2505896520, ; 81: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 38
	i32 2581819634, ; 82: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 54
	i32 2605712449, ; 83: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 70
	i32 2620871830, ; 84: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 28
	i32 2653168035, ; 85: Map => 0x9e2421a3 => 0
	i32 2701096212, ; 86: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 51
	i32 2732626843, ; 87: Xamarin.AndroidX.Activity => 0xa2e0939b => 11
	i32 2737747696, ; 88: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 15
	i32 2770495804, ; 89: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 64
	i32 2778768386, ; 90: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 56
	i32 2810250172, ; 91: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 25
	i32 2819470561, ; 92: System.Xml.dll => 0xa80db4e1 => 10
	i32 2847418871, ; 93: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 60
	i32 2853208004, ; 94: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 56
	i32 2855708567, ; 95: Xamarin.AndroidX.Transition => 0xaa36a797 => 52
	i32 2903344695, ; 96: System.ComponentModel.Composition => 0xad0d8637 => 73
	i32 2905242038, ; 97: mscorlib.dll => 0xad2a79b6 => 3
	i32 2919462931, ; 98: System.Numerics.Vectors.dll => 0xae037813 => 8
	i32 2921128767, ; 99: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 13
	i32 2978675010, ; 100: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 31
	i32 3016983068, ; 101: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 49
	i32 3017076677, ; 102: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 62
	i32 3024354802, ; 103: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 35
	i32 3058099980, ; 104: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 63
	i32 3211777861, ; 105: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 30
	i32 3230466174, ; 106: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 61
	i32 3247949154, ; 107: Mono.Security => 0xc197c562 => 72
	i32 3258312781, ; 108: Xamarin.AndroidX.CardView => 0xc235e84d => 21
	i32 3267021929, ; 109: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 19
	i32 3317135071, ; 110: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 29
	i32 3340431453, ; 111: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 18
	i32 3345895724, ; 112: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 45
	i32 3353484488, ; 113: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 34
	i32 3362522851, ; 114: Xamarin.AndroidX.Core => 0xc86c06e3 => 27
	i32 3366347497, ; 115: Java.Interop => 0xc8a662e9 => 1
	i32 3374999561, ; 116: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 46
	i32 3429136800, ; 117: System.Xml => 0xcc6479a0 => 10
	i32 3476120550, ; 118: Mono.Android => 0xcf3163e6 => 2
	i32 3493954962, ; 119: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 24
	i32 3501239056, ; 120: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 19
	i32 3567349600, ; 121: System.ComponentModel.Composition.dll => 0xd4a16f60 => 73
	i32 3627220390, ; 122: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 44
	i32 3633644679, ; 123: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 13
	i32 3641597786, ; 124: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 37
	i32 3672681054, ; 125: Mono.Android.dll => 0xdae8aa5e => 2
	i32 3682565725, ; 126: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 20
	i32 3684561358, ; 127: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 24
	i32 3689375977, ; 128: System.Drawing.Common => 0xdbe768e9 => 71
	i32 3706696989, ; 129: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 26
	i32 3718780102, ; 130: Xamarin.AndroidX.Annotation => 0xdda814c6 => 12
	i32 3768926977, ; 131: Map.dll => 0xe0a54301 => 0
	i32 3786282454, ; 132: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 22
	i32 3829621856, ; 133: System.Numerics.dll => 0xe4436460 => 7
	i32 3885922214, ; 134: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 52
	i32 3888767677, ; 135: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 45
	i32 3896760992, ; 136: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 27
	i32 3910130544, ; 137: Xamarin.AndroidX.Collection.Jvm => 0xe90fdb70 => 23
	i32 3921031405, ; 138: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 55
	i32 3955647286, ; 139: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 16
	i32 3970018735, ; 140: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 63
	i32 4015948917, ; 141: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 14
	i32 4105002889, ; 142: Mono.Security.dll => 0xf4ad5f89 => 72
	i32 4151237749, ; 143: System.Core => 0xf76edc75 => 4
	i32 4182413190, ; 144: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 40
	i32 4256097574, ; 145: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 26
	i32 4278134329, ; 146: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 62
	i32 4292120959 ; 147: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 40
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [148 x i32] [
	i32 38, i32 59, i32 48, i32 48, i32 67, i32 22, i32 50, i32 20, ; 0..7
	i32 35, i32 33, i32 11, i32 7, i32 36, i32 57, i32 32, i32 3, ; 8..15
	i32 5, i32 33, i32 42, i32 67, i32 29, i32 55, i32 17, i32 69, ; 16..23
	i32 64, i32 68, i32 71, i32 44, i32 59, i32 68, i32 36, i32 47, ; 24..31
	i32 16, i32 39, i32 66, i32 5, i32 53, i32 17, i32 23, i32 49, ; 32..39
	i32 54, i32 69, i32 14, i32 31, i32 47, i32 25, i32 15, i32 30, ; 40..47
	i32 41, i32 28, i32 6, i32 9, i32 51, i32 58, i32 65, i32 21, ; 48..55
	i32 50, i32 4, i32 32, i32 41, i32 66, i32 58, i32 57, i32 18, ; 56..63
	i32 61, i32 43, i32 65, i32 39, i32 37, i32 9, i32 8, i32 34, ; 64..71
	i32 60, i32 70, i32 6, i32 53, i32 42, i32 43, i32 46, i32 12, ; 72..79
	i32 1, i32 38, i32 54, i32 70, i32 28, i32 0, i32 51, i32 11, ; 80..87
	i32 15, i32 64, i32 56, i32 25, i32 10, i32 60, i32 56, i32 52, ; 88..95
	i32 73, i32 3, i32 8, i32 13, i32 31, i32 49, i32 62, i32 35, ; 96..103
	i32 63, i32 30, i32 61, i32 72, i32 21, i32 19, i32 29, i32 18, ; 104..111
	i32 45, i32 34, i32 27, i32 1, i32 46, i32 10, i32 2, i32 24, ; 112..119
	i32 19, i32 73, i32 44, i32 13, i32 37, i32 2, i32 20, i32 24, ; 120..127
	i32 71, i32 26, i32 12, i32 0, i32 22, i32 7, i32 52, i32 45, ; 128..135
	i32 27, i32 23, i32 55, i32 16, i32 63, i32 14, i32 72, i32 4, ; 136..143
	i32 40, i32 26, i32 62, i32 40 ; 144..147
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
