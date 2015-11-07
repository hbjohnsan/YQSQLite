using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

public class UpdaterHelper
{
    private static string _updaterPath = Path.Combine(Application.StartupPath, "qupdater.exe");

    public static int CheckNewFiles()
    {
        return RunUpdater("-checkforupdates", true);
    }

    public static void RunUpdater()
    {
        RunUpdater(string.Empty, false);
    }

    private static int RunUpdater(string arguments, bool waitForExit)
    {
        FileInfo info = new FileInfo(_updaterPath);
        if (!info.Exists)
        {
            return 0;
        }
        ProcessStartInfo info2 = new ProcessStartInfo();
        info2.FileName = info.FullName;
        info2.WorkingDirectory = info.Directory.FullName;
        info2.Arguments = arguments;
        Process process = new Process();
        process.StartInfo = info2;
        process.Start();
        if (!waitForExit)
        {
            return 0;
        }
        process.WaitForExit();
        return process.ExitCode;
    }
}
