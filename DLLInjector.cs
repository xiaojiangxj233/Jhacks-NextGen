using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    // Singleton模式用于封装和调用DLL中的方法
    public class DLLInjector
    {
        private static DLLInjector instance;

        private DLLInjector() { }

        public static DLLInjector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DLLInjector();
                }
                return instance;
            }
        }

        public bool InjectDLL(int intValue, string stringValue)
        {
            try
            {
                // 从嵌入的资源中提取DLL
                using (Stream dllStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Jhacks_NextGen.DLLinjector.dll"))
                {
                    byte[] dllBytes = new byte[dllStream.Length];
                    dllStream.Read(dllBytes, 0, dllBytes.Length);

                    // 直接加载DLL到内存
                    Assembly loadedAssembly = Assembly.Load(dllBytes);

                    // 获取DLL中的类型和方法
                    Type type = loadedAssembly.GetType("DLLinjector.InjectorClass");
                    MethodInfo method = type.GetMethod("InjectDLL");

                    // 创建类的实例并调用方法
                    object instance = Activator.CreateInstance(type);
                    object[] parameters = new object[] { intValue, stringValue };
                    method.Invoke(instance, parameters);
                }

                return true; // 方法执行成功
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false; // 方法执行失败
            }
        }
    }
}
