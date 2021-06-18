using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyEasyOS
{
    class dongtaibianyi
    {
        public static object CalcValue(string code)
        {
            //动态编译计算值
            var codeProvider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;//不生成exe文件
            parameters.GenerateInMemory = true;
            var result = codeProvider.CompileAssemblyFromSource(parameters, code);
            if (result.CompiledAssembly != null)
            {
                MethodInfo method = result.CompiledAssembly.GetType("DynamicClass").GetMethod("CalcValue", BindingFlags.Static | BindingFlags.Public);
                return method.Invoke(null, null);
            }
            return null;
        }
    }
}
