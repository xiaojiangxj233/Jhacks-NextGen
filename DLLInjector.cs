using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public class DLLInjector
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(
            int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(
            IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(
            IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        private const int PROCESS_CREATE_THREAD = 0x0002;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;
        private const int PROCESS_VM_OPERATION = 0x0008;
        private const int PROCESS_VM_WRITE = 0x0020;
        private const int PROCESS_VM_READ = 0x0010;
        private const uint MEM_COMMIT = 0x00001000;
        private const uint MEM_RESERVE = 0x00002000;
        private const uint PAGE_READWRITE = 0x04;

        public static bool InjectDLL(string dllPath, int processId)
        {
            try
            {
                IntPtr processHandle = OpenProcess(
                    PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION |
                    PROCESS_VM_WRITE | PROCESS_VM_READ, false, processId);

                if (processHandle == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to open process. Error: " + Marshal.GetLastWin32Error());
                    return false;
                }

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                if (loadLibraryAddr == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to get address of LoadLibraryA. Error: " + Marshal.GetLastWin32Error());
                    return false;
                }

                byte[] dllPathBytes = System.Text.Encoding.ASCII.GetBytes(dllPath);
                IntPtr allocatedMemory = VirtualAllocEx(
                    processHandle, IntPtr.Zero, (uint)dllPathBytes.Length, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

                if (allocatedMemory == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to allocate memory in the remote process. Error: " + Marshal.GetLastWin32Error());
                    return false;
                }

                int bytesWritten;
                if (!WriteProcessMemory(processHandle, allocatedMemory, dllPathBytes, (uint)dllPathBytes.Length, out bytesWritten))
                {
                    Console.WriteLine("Failed to write DLL path to the remote process. Error: " + Marshal.GetLastWin32Error());
                    return false;
                }

                IntPtr threadHandle = CreateRemoteThread(
                    processHandle, IntPtr.Zero, 0, loadLibraryAddr, allocatedMemory, 0, IntPtr.Zero);

                if (threadHandle == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to create remote thread in the remote process. Error: " + Marshal.GetLastWin32Error());
                    return false;
                }

                Console.WriteLine("DLL injected successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
    }
}
