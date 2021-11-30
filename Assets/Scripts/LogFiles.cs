using System;
using System.Linq;
using System.IO;
using UnityEngine;

public class LogFiles : MonoBehaviour
{
    public static void WriteToFile(string Message, string msgType)
    {
        string path = $@"{Application.dataPath}\Logs";
        CreateDirectory(path);

        string filepath = $@"{Application.dataPath}\Logs\BombersLog_{DateTime.Now.Date.ToShortDateString().Replace('/', '-')}.txt";
        if (!File.Exists(filepath))
            using (StreamWriter sw = File.CreateText(filepath))
                sw.WriteLine($"{DateTime.Now} + [{msgType}]: {Message}");
        else
            using (StreamWriter sw = File.AppendText(filepath))
                sw.WriteLine($"{DateTime.Now} + [{msgType}]: {Message}");
    }
    private static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
}