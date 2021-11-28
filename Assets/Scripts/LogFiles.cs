using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class LogFiles
{
    public static void WriteToFile(string Message, string msgType)
    {
        string path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Logs";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        string filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Logs\\ServiceLog_{DateTime.Now.Date.ToShortDateString().Replace('/', '-')}.txt";
        if (!File.Exists(filepath))
            using (StreamWriter sw = File.CreateText(filepath))
                sw.WriteLine($"{DateTime.Now} + [{msgType}]: {Message}");
        else
            using (StreamWriter sw = File.AppendText(filepath))
                sw.WriteLine($"{DateTime.Now} + [{msgType}]: {Message}");
    }
}
