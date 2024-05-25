﻿using InteropGenerator.Tests.Helpers;
using Xunit;
using VerifyIG = InteropGenerator.Tests.Helpers.IncrementalGeneratorVerifier<InteropGenerator.Generator.InteropGenerator>;

namespace InteropGenerator.Tests.Generator;

public class MemberFunctionAttributeTests {
    [Fact]
    public async Task GenerateMemberFunction() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial int TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunction_ExplicitOffset() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD", 4)]
                                public partial int TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 4, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunction_CALLOffset() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("E8 BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial int TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "E8 BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 1, new ulong[] {0x00000000DDCCBBE8, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "E8 BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunction_JMPOffset() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("E9 BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial int TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "E9 BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 1, new ulong[] {0x00000000DDCCBBE9, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "E9 BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunctionNoReturn() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial void TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, void> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, void>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial void TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunctionStatic() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public static partial int TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public static partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction(argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunctionMultiple() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial int TestFunction(int argOne, void * argTwo);
                                
                                [MemberFunction("?? ?? AA BB CC DD EE ?? ?? EE CC DD BB AA FF ?? ?? EE ?? ??")]
                                public partial int TestFunction2(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                      public static readonly Address TestFunction2 = new Address("TestStruct.TestFunction2", "?? ?? AA BB CC DD EE ?? ?? EE CC DD BB AA FF ?? ?? EE ?? ?? ?? ?? ?? ??", 0, new ulong[] {0x00EEDDCCBBAA0000, 0x00FFAABBDDCCEE00, 0x000000000000EE00}, new ulong[] {0x00FFFFFFFFFF0000, 0x00FFFFFFFFFFFF00, 0x000000000000FF00}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction2 => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction2.Value;
                                  }
                                  public partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                                  public partial int TestFunction2(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction2 is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction2", "?? ?? AA BB CC DD EE ?? ?? EE CC DD BB AA FF ?? ?? EE ?? ??");
                                      }
                                      return MemberFunctionPointers.TestFunction2((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction", "TestFunction2"]));
    }

    [Fact]
    public async Task GenerateMemberFunctionParamModifier() {
        const string code = """
                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial int TestFunction(ref int argOne, out int argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, ref int, out int, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, ref int, out int, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial int TestFunction(ref int argOne, out int argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), ref argOne, out argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunctionInNamespace() {
        const string code = """
                            namespace TestNamespace.InnerNamespace;

                            [GenerateInterop]
                            public unsafe partial struct TestStruct
                            {
                                [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                public partial int TestFunction(int argOne, void * argTwo);
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              namespace TestNamespace.InnerNamespace;

                              unsafe partial struct TestStruct
                              {
                                  public static class Addresses
                                  {
                                      public static readonly Address TestFunction = new Address("TestNamespace.InnerNamespace.TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                  }
                                  public unsafe static class MemberFunctionPointers
                                  {
                                      public static delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <TestStruct*, int, void*, int>) TestStruct.Addresses.TestFunction.Value;
                                  }
                                  public partial int TestFunction(int argOne, void* argTwo)
                                  {
                                      if (MemberFunctionPointers.TestFunction is null)
                                      {
                                          InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("TestStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                      }
                                      return MemberFunctionPointers.TestFunction((TestStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestNamespace.InnerNamespace.TestStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource("TestNamespace.InnerNamespace", "TestStruct", ["TestFunction"]));
    }

    [Fact]
    public async Task GenerateMemberFunctionInnerStruct() {
        const string code = """
                            public partial struct TestStruct
                            {
                                [GenerateInterop]
                                public unsafe partial struct InnerStruct
                                {
                                    [MemberFunction("AA BB CC DD ?? ?? ?? ?? AA BB ?? DD")]
                                    public partial int TestFunction(int argOne, void * argTwo);
                                }
                            }
                            """;

        const string result = """
                              // <auto-generated/>
                              unsafe partial struct TestStruct
                              {
                                  unsafe partial struct InnerStruct
                                  {
                                      public static class Addresses
                                      {
                                          public static readonly Address TestFunction = new Address("TestStruct+InnerStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD ?? ?? ?? ??", 0, new ulong[] {0x00000000DDCCBBAA, 0x00000000DD00BBAA}, new ulong[] {0x00000000FFFFFFFF, 0x00000000FF00FFFF}, 0);
                                      }
                                      public unsafe static class MemberFunctionPointers
                                      {
                                          public static delegate* unmanaged[Stdcall] <InnerStruct*, int, void*, int> TestFunction => (delegate* unmanaged[Stdcall] <InnerStruct*, int, void*, int>) InnerStruct.Addresses.TestFunction.Value;
                                      }
                                      public partial int TestFunction(int argOne, void* argTwo)
                                      {
                                          if (MemberFunctionPointers.TestFunction is null)
                                          {
                                              InteropGenerator.Runtime.ThrowHelper.ThrowNullAddress("InnerStruct.TestFunction", "AA BB CC DD ?? ?? ?? ?? AA BB ?? DD");
                                          }
                                          return MemberFunctionPointers.TestFunction((InnerStruct*)Unsafe.AsPointer(ref this), argOne, argTwo);
                                      }
                                  }
                              }
                              """;

        await VerifyIG.VerifyGeneratorAsync(
            code,
            ("TestStruct+InnerStruct.InteropGenerator.g.cs", result),
            SourceGeneration.GetInitializerSource(string.Empty, "TestStruct.InnerStruct", ["TestFunction"]));
    }
}
