; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [178 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [356 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 34839235, ; 3: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39109920, ; 4: Newtonsoft.Json.dll => 0x254c520 => 175
	i32 39485524, ; 5: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 6: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 7: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 68219467, ; 8: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 82292897, ; 9: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 117431740, ; 10: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 122350210, ; 11: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 142721839, ; 12: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 13: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 14: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 176265551, ; 15: System.ServiceProcess => 0xa81994f => 132
	i32 184328833, ; 16: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 17: System.ComponentModel => 0xc38ff48 => 18
	i32 209893705, ; 18: firebase.net.dll => 0xc82b949 => 0
	i32 220171995, ; 19: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230752869, ; 20: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 21: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 22: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 23: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 276479776, ; 24: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 291076382, ; 25: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 26: System.Net.Ping.dll => 0x11d123fd => 69
	i32 321597661, ; 27: System.Numerics => 0x132b30dd => 83
	i32 360082299, ; 28: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 29: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 30: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 31: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 32: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 33: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 34: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 393699800, ; 35: Firebase => 0x177761d8 => 173
	i32 395744057, ; 36: _Microsoft.Android.Resource.Designer => 0x17969339 => 177
	i32 403441872, ; 37: WindowsBase => 0x180c08d0 => 165
	i32 442565967, ; 38: System.Collections => 0x1a61054f => 12
	i32 451504562, ; 39: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 40: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 41: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 42: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 43: System.dll => 0x1bff388e => 164
	i32 498788369, ; 44: System.ObjectModel => 0x1dbae811 => 84
	i32 526420162, ; 45: System.Transactions.dll => 0x1f6088c2 => 150
	i32 530272170, ; 46: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 540030774, ; 47: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 48: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 49: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 50: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 577335427, ; 51: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 601371474, ; 52: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 53: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 610194910, ; 54: System.Reactive.dll => 0x245ed5de => 176
	i32 613668793, ; 55: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 643868501, ; 56: System.Net => 0x2660a755 => 81
	i32 662205335, ; 57: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 672442732, ; 58: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 59: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 60: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 693804605, ; 61: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 62: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700358131, ; 63: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 722857257, ; 64: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 65: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 66: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 759454413, ; 67: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 68: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 69: System.IO.Compression => 0x2e394f87 => 46
	i32 804715423, ; 70: System.Data.Common => 0x2ff6fb9f => 22
	i32 823281589, ; 71: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 72: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 73: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 74: System.Net.Quic => 0x31b69d60 => 71
	i32 873119928, ; 75: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 76: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 77: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 78: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 79: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 952186615, ; 80: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 81: Newtonsoft.Json => 0x38f24a24 => 175
	i32 975236339, ; 82: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 83: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 84: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 85: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 86: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 87: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 88: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1019214401, ; 89: System.Drawing => 0x3cbffa41 => 36
	i32 1036536393, ; 90: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 91: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1082857460, ; 92: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1098259244, ; 93: System => 0x41761b2c => 164
	i32 1170634674, ; 94: System.Web.dll => 0x45c677b2 => 153
	i32 1208641965, ; 95: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 96: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1253011324, ; 97: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1309188875, ; 98: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1324164729, ; 99: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 100: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 101: System.IO => 0x514d38cd => 57
	i32 1379779777, ; 102: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 103: System.Configuration.dll => 0x53936ab4 => 19
	i32 1408764838, ; 104: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 105: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 106: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1434145427, ; 107: System.Runtime.Handles => 0x557b5293 => 104
	i32 1439761251, ; 108: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 109: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 110: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 111: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 112: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461234159, ; 113: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 114: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 115: System.IO.Compression.dll => 0x57261233 => 46
	i32 1479771757, ; 116: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 117: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 118: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1536373174, ; 119: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 120: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 121: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 122: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 123: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 124: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 125: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 126: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1592978981, ; 127: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1601112923, ; 128: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 129: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 130: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622358360, ; 131: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1639515021, ; 132: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 133: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 134: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 135: System.Runtime => 0x62c6282e => 116
	i32 1675553242, ; 136: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 137: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 138: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 139: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 140: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 141: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1701541528, ; 142: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1726116996, ; 143: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 144: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1744735666, ; 145: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 146: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 147: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 148: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 149: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 150: System.Reflection.Extensions => 0x6942234e => 93
	i32 1776026572, ; 151: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 152: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 153: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1818787751, ; 154: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 155: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 156: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1858542181, ; 157: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 158: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1879696579, ; 159: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1888955245, ; 160: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 161: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 162: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 163: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 164: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 165: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 166: System.Resources.Writer => 0x74a1c5bb => 100
	i32 2011961780, ; 167: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2045470958, ; 168: System.Private.Xml => 0x79eb68ee => 88
	i32 2060060697, ; 169: System.Windows.dll => 0x7aca0819 => 154
	i32 2070888862, ; 170: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 171: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 172: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 173: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 174: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 175: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 176: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2193016926, ; 177: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201231467, ; 178: System.Net.Http => 0x8334206b => 64
	i32 2222056684, ; 179: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2252106437, ; 180: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 181: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 182: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2293034957, ; 183: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 184: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 185: System.Net.Mail => 0x88ffe49e => 66
	i32 2305521784, ; 186: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2320631194, ; 187: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 188: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 189: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 190: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 191: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2378619854, ; 192: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 193: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2401565422, ; 194: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2421380589, ; 195: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2435356389, ; 196: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 197: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 198: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 199: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 200: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2471841756, ; 201: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 202: Java.Interop.dll => 0x93918882 => 168
	i32 2483903535, ; 203: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 204: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 205: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 206: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2521656939, ; 207: firebase.net => 0x964d6e6b => 0
	i32 2538310050, ; 208: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2562349572, ; 209: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 210: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2585220780, ; 211: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 212: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 213: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2617129537, ; 214: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 215: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2627185994, ; 216: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 217: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2663698177, ; 218: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 219: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 220: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 221: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 222: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 223: System.IO.dll => 0xa090e36a => 57
	i32 2715334215, ; 224: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 225: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 226: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 227: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2735172069, ; 228: System.Threading.Channels => 0xa30769e5 => 139
	i32 2740948882, ; 229: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 230: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2765824710, ; 231: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2803228030, ; 232: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2819470561, ; 233: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 234: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2824502124, ; 235: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2849599387, ; 236: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2861098320, ; 237: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2875220617, ; 238: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2887636118, ; 239: System.Net.dll => 0xac1dd496 => 81
	i32 2899753641, ; 240: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 241: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 242: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 243: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 244: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2919462931, ; 245: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2936416060, ; 246: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 247: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 248: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 249: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 250: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 251: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 3023353419, ; 252: WindowsBase.dll => 0xb434b64b => 165
	i32 3038032645, ; 253: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 177
	i32 3059408633, ; 254: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 255: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 256: System.Threading.Tasks => 0xb755818f => 144
	i32 3090735792, ; 257: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 258: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 259: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 260: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 261: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 262: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 263: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 264: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3159123045, ; 265: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 266: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3192346100, ; 267: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 268: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 269: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 270: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3220365878, ; 271: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 272: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 273: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3265493905, ; 274: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 275: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 276: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 277: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 278: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 279: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 280: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 281: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3316684772, ; 282: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317144872, ; 283: System.Data => 0xc5b79d28 => 24
	i32 3322403133, ; 284: Firebase.dll => 0xc607d93d => 173
	i32 3358260929, ; 285: System.Text.Json => 0xc82afec1 => 137
	i32 3366347497, ; 286: Java.Interop => 0xc8a662e9 => 168
	i32 3395150330, ; 287: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 288: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3429136800, ; 289: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 290: netstandard => 0xcc7d82b4 => 167
	i32 3445260447, ; 291: System.Formats.Tar => 0xcd5a809f => 39
	i32 3471940407, ; 292: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 293: Mono.Android => 0xcf3163e6 => 171
	i32 3485117614, ; 294: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 295: System.Transactions => 0xcfd0c798 => 150
	i32 3509114376, ; 296: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 297: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 298: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 299: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 300: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 301: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3596207933, ; 302: LiteDB.dll => 0xd659c73d => 174
	i32 3598340787, ; 303: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 304: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 305: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3629588173, ; 306: LiteDB => 0xd8571ecd => 174
	i32 3638274909, ; 307: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3645089577, ; 308: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3660523487, ; 309: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 310: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3700866549, ; 311: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3716563718, ; 312: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3731644420, ; 313: System.Reactive => 0xde6c6004 => 176
	i32 3732100267, ; 314: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 315: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 316: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 317: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3792276235, ; 318: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3802395368, ; 319: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 320: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 321: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 322: System.Numerics.dll => 0xe4436460 => 83
	i32 3844307129, ; 323: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 324: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 325: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 326: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 327: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 328: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3896106733, ; 329: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3901907137, ; 330: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 331: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3928044579, ; 332: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 333: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3945713374, ; 334: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 335: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 4003436829, ; 336: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4025784931, ; 337: System.Memory => 0xeff49a63 => 62
	i32 4054681211, ; 338: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 339: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 340: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4099507663, ; 341: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 342: System.Private.Uri => 0xf462c30d => 86
	i32 4127667938, ; 343: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 344: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 345: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4151237749, ; 346: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 347: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 348: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 349: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 350: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4185676441, ; 351: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 352: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 353: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4260525087, ; 354: System.Buffers => 0xfdf2741f => 7
	i32 4274976490 ; 355: System.Runtime.Numerics => 0xfecef6ea => 110
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [356 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 48, ; 3
	i32 175, ; 4
	i32 80, ; 5
	i32 145, ; 6
	i32 30, ; 7
	i32 124, ; 8
	i32 102, ; 9
	i32 107, ; 10
	i32 139, ; 11
	i32 77, ; 12
	i32 124, ; 13
	i32 13, ; 14
	i32 132, ; 15
	i32 151, ; 16
	i32 18, ; 17
	i32 0, ; 18
	i32 26, ; 19
	i32 1, ; 20
	i32 59, ; 21
	i32 42, ; 22
	i32 91, ; 23
	i32 147, ; 24
	i32 54, ; 25
	i32 69, ; 26
	i32 83, ; 27
	i32 131, ; 28
	i32 55, ; 29
	i32 149, ; 30
	i32 74, ; 31
	i32 145, ; 32
	i32 62, ; 33
	i32 146, ; 34
	i32 173, ; 35
	i32 177, ; 36
	i32 165, ; 37
	i32 12, ; 38
	i32 125, ; 39
	i32 152, ; 40
	i32 113, ; 41
	i32 166, ; 42
	i32 164, ; 43
	i32 84, ; 44
	i32 150, ; 45
	i32 60, ; 46
	i32 51, ; 47
	i32 103, ; 48
	i32 114, ; 49
	i32 40, ; 50
	i32 120, ; 51
	i32 52, ; 52
	i32 44, ; 53
	i32 176, ; 54
	i32 119, ; 55
	i32 81, ; 56
	i32 136, ; 57
	i32 8, ; 58
	i32 73, ; 59
	i32 155, ; 60
	i32 154, ; 61
	i32 92, ; 62
	i32 45, ; 63
	i32 109, ; 64
	i32 129, ; 65
	i32 25, ; 66
	i32 72, ; 67
	i32 55, ; 68
	i32 46, ; 69
	i32 22, ; 70
	i32 86, ; 71
	i32 43, ; 72
	i32 160, ; 73
	i32 71, ; 74
	i32 3, ; 75
	i32 42, ; 76
	i32 63, ; 77
	i32 16, ; 78
	i32 53, ; 79
	i32 105, ; 80
	i32 175, ; 81
	i32 34, ; 82
	i32 158, ; 83
	i32 85, ; 84
	i32 32, ; 85
	i32 12, ; 86
	i32 51, ; 87
	i32 56, ; 88
	i32 36, ; 89
	i32 35, ; 90
	i32 58, ; 91
	i32 17, ; 92
	i32 164, ; 93
	i32 153, ; 94
	i32 29, ; 95
	i32 52, ; 96
	i32 5, ; 97
	i32 85, ; 98
	i32 61, ; 99
	i32 112, ; 100
	i32 57, ; 101
	i32 99, ; 102
	i32 19, ; 103
	i32 111, ; 104
	i32 101, ; 105
	i32 102, ; 106
	i32 104, ; 107
	i32 71, ; 108
	i32 38, ; 109
	i32 32, ; 110
	i32 103, ; 111
	i32 73, ; 112
	i32 9, ; 113
	i32 123, ; 114
	i32 46, ; 115
	i32 9, ; 116
	i32 43, ; 117
	i32 4, ; 118
	i32 31, ; 119
	i32 138, ; 120
	i32 92, ; 121
	i32 93, ; 122
	i32 49, ; 123
	i32 141, ; 124
	i32 112, ; 125
	i32 140, ; 126
	i32 115, ; 127
	i32 157, ; 128
	i32 76, ; 129
	i32 79, ; 130
	i32 37, ; 131
	i32 64, ; 132
	i32 138, ; 133
	i32 15, ; 134
	i32 116, ; 135
	i32 48, ; 136
	i32 70, ; 137
	i32 80, ; 138
	i32 126, ; 139
	i32 94, ; 140
	i32 121, ; 141
	i32 26, ; 142
	i32 97, ; 143
	i32 28, ; 144
	i32 149, ; 145
	i32 169, ; 146
	i32 4, ; 147
	i32 98, ; 148
	i32 33, ; 149
	i32 93, ; 150
	i32 21, ; 151
	i32 41, ; 152
	i32 170, ; 153
	i32 2, ; 154
	i32 134, ; 155
	i32 111, ; 156
	i32 58, ; 157
	i32 95, ; 158
	i32 39, ; 159
	i32 25, ; 160
	i32 94, ; 161
	i32 89, ; 162
	i32 99, ; 163
	i32 10, ; 164
	i32 87, ; 165
	i32 100, ; 166
	i32 7, ; 167
	i32 88, ; 168
	i32 154, ; 169
	i32 33, ; 170
	i32 116, ; 171
	i32 82, ; 172
	i32 20, ; 173
	i32 11, ; 174
	i32 162, ; 175
	i32 3, ; 176
	i32 84, ; 177
	i32 64, ; 178
	i32 143, ; 179
	i32 157, ; 180
	i32 41, ; 181
	i32 117, ; 182
	i32 131, ; 183
	i32 75, ; 184
	i32 66, ; 185
	i32 172, ; 186
	i32 143, ; 187
	i32 106, ; 188
	i32 151, ; 189
	i32 70, ; 190
	i32 156, ; 191
	i32 121, ; 192
	i32 127, ; 193
	i32 152, ; 194
	i32 141, ; 195
	i32 20, ; 196
	i32 14, ; 197
	i32 135, ; 198
	i32 75, ; 199
	i32 59, ; 200
	i32 167, ; 201
	i32 168, ; 202
	i32 15, ; 203
	i32 74, ; 204
	i32 6, ; 205
	i32 23, ; 206
	i32 0, ; 207
	i32 91, ; 208
	i32 1, ; 209
	i32 136, ; 210
	i32 134, ; 211
	i32 69, ; 212
	i32 146, ; 213
	i32 88, ; 214
	i32 96, ; 215
	i32 31, ; 216
	i32 45, ; 217
	i32 109, ; 218
	i32 158, ; 219
	i32 35, ; 220
	i32 22, ; 221
	i32 114, ; 222
	i32 57, ; 223
	i32 144, ; 224
	i32 118, ; 225
	i32 120, ; 226
	i32 110, ; 227
	i32 139, ; 228
	i32 54, ; 229
	i32 105, ; 230
	i32 133, ; 231
	i32 159, ; 232
	i32 163, ; 233
	i32 132, ; 234
	i32 161, ; 235
	i32 140, ; 236
	i32 169, ; 237
	i32 40, ; 238
	i32 81, ; 239
	i32 56, ; 240
	i32 37, ; 241
	i32 97, ; 242
	i32 166, ; 243
	i32 172, ; 244
	i32 82, ; 245
	i32 98, ; 246
	i32 30, ; 247
	i32 159, ; 248
	i32 18, ; 249
	i32 127, ; 250
	i32 119, ; 251
	i32 165, ; 252
	i32 177, ; 253
	i32 170, ; 254
	i32 16, ; 255
	i32 144, ; 256
	i32 125, ; 257
	i32 118, ; 258
	i32 38, ; 259
	i32 115, ; 260
	i32 47, ; 261
	i32 142, ; 262
	i32 117, ; 263
	i32 34, ; 264
	i32 95, ; 265
	i32 53, ; 266
	i32 129, ; 267
	i32 153, ; 268
	i32 24, ; 269
	i32 161, ; 270
	i32 148, ; 271
	i32 104, ; 272
	i32 89, ; 273
	i32 60, ; 274
	i32 142, ; 275
	i32 100, ; 276
	i32 5, ; 277
	i32 13, ; 278
	i32 122, ; 279
	i32 135, ; 280
	i32 28, ; 281
	i32 72, ; 282
	i32 24, ; 283
	i32 173, ; 284
	i32 137, ; 285
	i32 168, ; 286
	i32 101, ; 287
	i32 123, ; 288
	i32 163, ; 289
	i32 167, ; 290
	i32 39, ; 291
	i32 17, ; 292
	i32 171, ; 293
	i32 137, ; 294
	i32 150, ; 295
	i32 155, ; 296
	i32 130, ; 297
	i32 19, ; 298
	i32 65, ; 299
	i32 147, ; 300
	i32 47, ; 301
	i32 174, ; 302
	i32 79, ; 303
	i32 61, ; 304
	i32 106, ; 305
	i32 174, ; 306
	i32 49, ; 307
	i32 14, ; 308
	i32 68, ; 309
	i32 171, ; 310
	i32 78, ; 311
	i32 108, ; 312
	i32 176, ; 313
	i32 67, ; 314
	i32 63, ; 315
	i32 27, ; 316
	i32 160, ; 317
	i32 10, ; 318
	i32 11, ; 319
	i32 78, ; 320
	i32 126, ; 321
	i32 83, ; 322
	i32 66, ; 323
	i32 107, ; 324
	i32 65, ; 325
	i32 128, ; 326
	i32 122, ; 327
	i32 77, ; 328
	i32 8, ; 329
	i32 2, ; 330
	i32 44, ; 331
	i32 156, ; 332
	i32 128, ; 333
	i32 23, ; 334
	i32 133, ; 335
	i32 29, ; 336
	i32 62, ; 337
	i32 90, ; 338
	i32 87, ; 339
	i32 148, ; 340
	i32 36, ; 341
	i32 86, ; 342
	i32 50, ; 343
	i32 6, ; 344
	i32 90, ; 345
	i32 21, ; 346
	i32 162, ; 347
	i32 96, ; 348
	i32 50, ; 349
	i32 113, ; 350
	i32 130, ; 351
	i32 76, ; 352
	i32 27, ; 353
	i32 7, ; 354
	i32 110 ; 355
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
