using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public class Injector
    {
        // 导入kernel32.dll中的函数
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out uint lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)] static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] static extern IntPtr GetModuleHandle(string lpModuleName);
        // 定义一些常量
        const uint PROCESS_CREATE_THREAD = 0x0002;
        const uint PROCESS_QUERY_INFORMATION = 0x0400;
        const uint PROCESS_VM_OPERATION = 0x0008;
        const uint PROCESS_VM_WRITE = 0x0020;
        const uint PROCESS_VM_READ = 0x0010;
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 0x04;

        // 定义一个可以被其它方法调用的DLL注入方法
        public static bool DLLInjector(int pid, string dllpath)
        {
            // 打开目标进程
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, pid);
            if (hProcess == IntPtr.Zero)
            {
                DevConsole.Instance.WriteLine("无法打开目标进程");
                return false;
            }

            // 在目标进程中分配内存空间，用于存放DLL文件的路径
            IntPtr pDllPath = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllpath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            if (pDllPath == IntPtr.Zero)
            {
                DevConsole.Instance.WriteLine("无法在目标进程中分配内存空间");
                CloseHandle(hProcess);
                return false;
            }

            // 将DLL文件的路径写入目标进程的内存空间
            uint bytesWritten;
            bool result = WriteProcessMemory(hProcess, pDllPath, System.Text.Encoding.Default.GetBytes(dllpath), (uint)((dllpath.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            if (!result)
            {
                DevConsole.Instance.WriteLine("无法将DLL文件的路径写入目标进程的内存空间");
                CloseHandle(hProcess);
                return false;
            }

            // 获取LoadLibraryA函数的地址，这个函数可以加载DLL文件
            IntPtr pLoadLibraryA = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (pLoadLibraryA == IntPtr.Zero)
            {
                DevConsole.Instance.WriteLine("无法获取LoadLibraryA函数的地址");
                CloseHandle(hProcess);
                return false;
            }

            // 在目标进程中创建一个远程线程，执行LoadLibraryA函数，加载DLL文件
            uint threadId;
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, pLoadLibraryA, pDllPath, 0, out threadId);
            if (hThread == IntPtr.Zero)
            {
                DevConsole.Instance.WriteLine("无法在目标进程中创建一个远程线程");
                CloseHandle(hProcess);
                return false;
            }

            // 等待远程线程结束
            WaitForSingleObject(hThread, 0xFFFFFFFF);

            // 关闭句柄
            CloseHandle(hThread);
            CloseHandle(hProcess);

            // 返回注入成功
            return true;
        }
    }
}
