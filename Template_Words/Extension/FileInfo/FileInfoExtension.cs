using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Words.Extension.FileInfos
{
    public static class FileInfoExtension
    {
        public static Process? Execute(this FileInfo file)
        {
            var proc = new ProcessStartInfo(file.FullName)
            {
                UseShellExecute = true,
            };
            return Process.Start(proc);
        }
    }
}
