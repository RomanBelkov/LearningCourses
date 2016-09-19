
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
// MVID: {BBFF6F13-4476-4D5C-8451-DC2EE961F7AA}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x012B0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit MyCalc
       extends [mscorlib]System.Object
{
  .field private static literal int32 minBound = int32(0x00000001)
  .field private static literal int32 maxBound = int32(0x0000000A)
  .field private static class [mscorlib]System.Random rnd
  .method private hidebysig static int32 
          getRandomNumber() cil managed
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
  } // end of method MyCalc::getRandomNumber

  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       143 (0x8f)
    .maxstack  3
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
    IL_001d:  call       int32 MyCalc::getRandomNumber()
    IL_0022:  stloc.1
    IL_0023:  call       int32 MyCalc::getRandomNumber()
    IL_0028:  stloc.2
    IL_0029:  ldstr      bytearray (21 04 3A 04 3E 04 3B 04 4C 04 3A 04 3E 04 20 00   // !.:.>.;.L.:.>. .
                                    31 04 43 04 34 04 35 04 42 04 20 00 7B 00 30 00   // 1.C.4.5.B. .{.0.
                                    7D 00 20 00 2B 00 20 00 7B 00 31 00 7D 00 3F 00 ) // }. .+. .{.1.}.?.
    IL_002e:  ldloc.1
    IL_002f:  box        [mscorlib]System.Int32
    IL_0034:  ldloc.2
    IL_0035:  box        [mscorlib]System.Int32
    IL_003a:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object)
    IL_003f:  nop
    .try
    {
      IL_0040:  nop
      IL_0041:  call       string [mscorlib]System.Console::ReadLine()
      IL_0046:  call       int32 [mscorlib]System.Int32::Parse(string)
      IL_004b:  stloc.3
      IL_004c:  ldloc.1
      IL_004d:  ldloc.2
      IL_004e:  sub
      IL_004f:  ldloc.3
      IL_0050:  ceq
      IL_0052:  ldc.i4.0
      IL_0053:  ceq
      IL_0055:  stloc.s    V_5
      IL_0057:  ldloc.s    V_5
      IL_0059:  brtrue.s   IL_006b

      IL_005b:  nop
      IL_005c:  ldstr      bytearray (12 04 35 04 40 04 3D 04 3E 04 2C 00 20 00 7B 00   // ..5.@.=.>.,. .{.
                                      30 00 7D 00 21 00 )                               // 0.}.!.
      IL_0061:  ldloc.0
      IL_0062:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_0067:  nop
      IL_0068:  nop
      IL_0069:  br.s       IL_0079

      IL_006b:  nop
      IL_006c:  ldstr      bytearray (7B 00 30 00 7D 00 2C 00 20 00 42 04 4B 04 20 00   // {.0.}.,. .B.K. .
                                      3D 04 35 04 20 00 3F 04 40 04 30 04 32 04 )       // =.5. .?.@.0.2.
      IL_0071:  ldloc.0
      IL_0072:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_0077:  nop
      IL_0078:  nop
      IL_0079:  nop
      IL_007a:  leave.s    IL_008d

    }  // end .try
    catch [mscorlib]System.FormatException 
    {
      IL_007c:  stloc.s    V_4
      IL_007e:  nop
      IL_007f:  ldstr      bytearray (1E 04 42 04 32 04 35 04 42 04 3E 04 3C 04 20 00   // ..B.2.5.B.>.<. .
                                      34 04 3E 04 3B 04 36 04 3D 04 3E 04 20 00 31 04   // 4.>.;.6.=.>. .1.
                                      4B 04 42 04 4C 04 20 00 47 04 38 04 41 04 3B 04   // K.B.L. .G.8.A.;.
                                      3E 04 21 00 )                                     // >.!.
      IL_0084:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0089:  nop
      IL_008a:  nop
      IL_008b:  leave.s    IL_008d

    }  // end handler
    IL_008d:  nop
    IL_008e:  ret
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
