; ModuleID = 'obj\Release\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
@assembly_image_cache_hashes = local_unnamed_addr constant [62 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 25
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 7
	i32 318968648, ; 2: Xamarin.AndroidX.Activity.dll => 0x13031348 => 13
	i32 321597661, ; 3: System.Numerics => 0x132b30dd => 10
	i32 342366114, ; 4: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 19
	i32 393699800, ; 5: Firebase => 0x177761d8 => 2
	i32 442521989, ; 6: Xamarin.Essentials => 0x1a605985 => 24
	i32 450948140, ; 7: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 18
	i32 465846621, ; 8: mscorlib => 0x1bc4415d => 6
	i32 469710990, ; 9: System.dll => 0x1bff388e => 9
	i32 610194910, ; 10: System.Reactive.dll => 0x245ed5de => 11
	i32 627609679, ; 11: Xamarin.AndroidX.CustomView => 0x2568904f => 16
	i32 690569205, ; 12: System.Xml.Linq.dll => 0x29293ff5 => 29
	i32 928116545, ; 13: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 25
	i32 955402788, ; 14: Newtonsoft.Json => 0x38f24a24 => 7
	i32 967690846, ; 15: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 19
	i32 1012816738, ; 16: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 23
	i32 1035644815, ; 17: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 14
	i32 1052210849, ; 18: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 21
	i32 1098259244, ; 19: System => 0x41761b2c => 9
	i32 1293217323, ; 20: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 17
	i32 1376866003, ; 21: Xamarin.AndroidX.SavedState => 0x52114ed3 => 23
	i32 1592978981, ; 22: System.Runtime.Serialization.dll => 0x5ef2ee25 => 28
	i32 1622152042, ; 23: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 22
	i32 1639515021, ; 24: System.Net.Http.dll => 0x61b9038d => 27
	i32 1776026572, ; 25: System.Core.dll => 0x69dc03cc => 8
	i32 1788241197, ; 26: Xamarin.AndroidX.Fragment => 0x6a96652d => 18
	i32 1808609942, ; 27: Xamarin.AndroidX.Loader => 0x6bcd3296 => 22
	i32 1867746548, ; 28: Xamarin.Essentials.dll => 0x6f538cf4 => 24
	i32 2019465201, ; 29: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 21
	i32 2055257422, ; 30: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 20
	i32 2201231467, ; 31: System.Net.Http => 0x8334206b => 27
	i32 2216717168, ; 32: Firebase.Auth.dll => 0x84206b70 => 1
	i32 2475788418, ; 33: Java.Interop.dll => 0x93918882 => 3
	i32 2732626843, ; 34: Xamarin.AndroidX.Activity => 0xa2e0939b => 13
	i32 2819470561, ; 35: System.Xml.dll => 0xa80db4e1 => 12
	i32 2905242038, ; 36: mscorlib.dll => 0xad2a79b6 => 6
	i32 2978675010, ; 37: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 17
	i32 3059955318, ; 38: epicisrael => 0xb6633676 => 0
	i32 3111772706, ; 39: System.Runtime.Serialization => 0xb979e222 => 28
	i32 3204380047, ; 40: System.Data.dll => 0xbefef58f => 26
	i32 3247949154, ; 41: Mono.Security => 0xc197c562 => 30
	i32 3317135071, ; 42: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 16
	i32 3317144872, ; 43: System.Data => 0xc5b79d28 => 26
	i32 3322403133, ; 44: Firebase.dll => 0xc607d93d => 2
	i32 3362522851, ; 45: Xamarin.AndroidX.Core => 0xc86c06e3 => 15
	i32 3366347497, ; 46: Java.Interop => 0xc8a662e9 => 3
	i32 3429136800, ; 47: System.Xml => 0xcc6479a0 => 12
	i32 3476120550, ; 48: Mono.Android => 0xcf3163e6 => 5
	i32 3509114376, ; 49: System.Xml.Linq => 0xd128d608 => 29
	i32 3596207933, ; 50: LiteDB.dll => 0xd659c73d => 4
	i32 3629588173, ; 51: LiteDB => 0xd8571ecd => 4
	i32 3641597786, ; 52: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 20
	i32 3672681054, ; 53: Mono.Android.dll => 0xdae8aa5e => 5
	i32 3731644420, ; 54: System.Reactive => 0xde6c6004 => 11
	i32 3829621856, ; 55: System.Numerics.dll => 0xe4436460 => 10
	i32 3863679347, ; 56: epicisrael.dll => 0xe64b1173 => 0
	i32 3896760992, ; 57: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 15
	i32 3955647286, ; 58: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 14
	i32 4024013275, ; 59: Firebase.Auth => 0xefd991db => 1
	i32 4105002889, ; 60: Mono.Security.dll => 0xf4ad5f89 => 30
	i32 4151237749 ; 61: System.Core => 0xf76edc75 => 8
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [62 x i32] [
	i32 25, i32 7, i32 13, i32 10, i32 19, i32 2, i32 24, i32 18, ; 0..7
	i32 6, i32 9, i32 11, i32 16, i32 29, i32 25, i32 7, i32 19, ; 8..15
	i32 23, i32 14, i32 21, i32 9, i32 17, i32 23, i32 28, i32 22, ; 16..23
	i32 27, i32 8, i32 18, i32 22, i32 24, i32 21, i32 20, i32 27, ; 24..31
	i32 1, i32 3, i32 13, i32 12, i32 6, i32 17, i32 0, i32 28, ; 32..39
	i32 26, i32 30, i32 16, i32 26, i32 2, i32 15, i32 3, i32 12, ; 40..47
	i32 5, i32 29, i32 4, i32 4, i32 20, i32 5, i32 11, i32 10, ; 48..55
	i32 0, i32 15, i32 14, i32 1, i32 30, i32 8 ; 56..61
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
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


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
