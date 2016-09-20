
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.81.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly MyCalc
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module MyCalc.exe
// MVID: {95726DB4-5D38-41F5-BCE2-E678E5F200A5}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00E30000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit MyCalc
       extends [mscorlib]System.Object
{
  .field private static literal int32 minBound = int32(0x00000001)
  .field private static literal int32 maxBound = int32(0x0000000A)
  .field private static class [mscorlib]System.Random rnd
  .method private hidebysig static int32 
          GetRandomNumber() cil managed
  {
    // Code size       19 (0x13)
    .maxstack  3
    .locals init (int32 V_0)
    IL_0000:  nop
    IL_0001:  ldsfld     class [mscorlib]System.Random MyCalc::rnd
    IL_0006:  ldc.i4.1
    IL_0007:  ldc.i4.s   11
    IL_0009:  callvirt   instance int32 [mscorlib]System.Random::Next(int32,
                                                                      int32)
    IL_000e:  stloc.0
    IL_000f:  br.s       IL_0011

    IL_0011:  ldloc.0
    IL_0012:  ret
  } // end of method MyCalc::GetRandomNumber

  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       148 (0x94)
    .maxstack  4
    .locals init (string V_0,
             int32 V_1,
             int32 V_2,
             int32 V_3,
             class [mscorlib]System.FormatException V_4,
             bool V_5)
    IL_0000:  nop
    IL_0001:  ldstr      bytearray (2F 04 20 00 14 20 20 00 38 04 3D 04 42 04 35 04   // /. ..  .8.=.B.5.
                                    3B 04 3B 04 35 04 3A 04 42 04 43 04 30 04 3B 04   // ;.;.5.:.B.C.0.;.
                                    4C 04 3D 04 4B 04 39 04 20 00 3A 04 30 04 3B 04   // L.=.K.9. .:.0.;.
                                    4C 04 3A 04 43 04 3B 04 4F 04 42 04 3E 04 40 04   // L.:.C.;.O.B.>.@.
                                    21 00 )                                           // !.
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ldstr      bytearray (1A 04 30 04 3A 04 20 00 42 04 35 04 31 04 4F 04   // ..0.:. .B.5.1.O.
                                    20 00 37 04 3E 04 32 04 43 04 42 04 3F 00 )       //  .7.>.2.C.B.?.
    IL_0011:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0016:  nop
    IL_0017:  call       string [mscorlib]System.Console::ReadLine()
    IL_001c:  stloc.0
    IL_001d:  call       int32 MyCalc::GetRandomNumber()
    IL_0022:  stloc.1
    IL_0023:  call       int32 MyCalc::GetRandomNumber()
    IL_0028:  stloc.2
    IL_0029:  ldstr      bytearray (21 04 3A 04 3E 04 3B 04 4C 04 3A 04 3E 04 20 00   // !.:.>.;.L.:.>. .
                                    31 04 43 04 34 04 35 04 42 04 20 00 7B 00 30 00   // 1.C.4.5.B. .{.0.
                                    7D 00 20 00 7B 00 31 00 7D 00 20 00 7B 00 32 00   // }. .{.1.}. .{.2.
                                    7D 00 3F 00 )                                     // }.?.
    IL_002e:  ldloc.1
    IL_002f:  box        [mscorlib]System.Int32
    IL_0034:  ldstr      "-"
    IL_0039:  ldloc.2
    IL_003a:  box        [mscorlib]System.Int32
    IL_003f:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object,
                                                                  object)
    IL_0044:  nop
    .try
    {
      IL_0045:  nop
      IL_0046:  call       string [mscorlib]System.Console::ReadLine()
      IL_004b:  call       int32 [mscorlib]System.Int32::Parse(string)
      IL_0050:  stloc.3
      IL_0051:  ldloc.1
      IL_0052:  ldloc.2
      IL_0053:  sub
      IL_0054:  ldloc.3
      IL_0055:  ceq
      IL_0057:  ldc.i4.0
      IL_0058:  ceq
      IL_005a:  stloc.s    V_5
      IL_005c:  ldloc.s    V_5
      IL_005e:  brtrue.s   IL_0070

      IL_0060:  nop
      IL_0061:  ldstr      bytearray (12 04 35 04 40 04 3D 04 3E 04 2C 00 20 00 7B 00   // ..5.@.=.>.,. .{.
                                      30 00 7D 00 21 00 )                               // 0.}.!.
      IL_0066:  ldloc.0
      IL_0067:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_006c:  nop
      IL_006d:  nop
      IL_006e:  br.s       IL_007e

      IL_0070:  nop
      IL_0071:  ldstr      bytearray (7B 00 30 00 7D 00 2C 00 20 00 42 04 4B 04 20 00   // {.0.}.,. .B.K. .
                                      3D 04 35 04 20 00 3F 04 40 04 30 04 32 04 )       // =.5. .?.@.0.2.
      IL_0076:  ldloc.0
      IL_0077:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_007c:  nop
      IL_007d:  nop
      IL_007e:  nop
      IL_007f:  leave.s    IL_0092

    }  // end .try
    catch [mscorlib]System.FormatException 
    {
      IL_0081:  stloc.s    V_4
      IL_0083:  nop
      IL_0084:  ldstr      bytearray (1E 04 42 04 32 04 35 04 42 04 3E 04 3C 04 20 00   // ..B.2.5.B.>.<. .
                                      34 04 3E 04 3B 04 36 04 3D 04 3E 04 20 00 31 04   // 4.>.;.6.=.>. .1.
                                      4B 04 42 04 4C 04 20 00 47 04 38 04 41 04 3B 04   // K.B.L. .G.8.A.;.
                                      3E 04 21 00 )                                     // >.!.
      IL_0089:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_008e:  nop
      IL_008f:  nop
      IL_0090:  leave.s    IL_0092

    }  // end handler
    IL_0092:  nop
    IL_0093:  ret
  } // end of method MyCalc::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method MyCalc::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  newobj     instance void [mscorlib]System.Random::.ctor()
    IL_0005:  stsfld     class [mscorlib]System.Random MyCalc::rnd
    IL_000a:  ret
  } // end of method MyCalc::.cctor

} // end of class MyCalc


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
