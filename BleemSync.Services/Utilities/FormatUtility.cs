﻿using BleemSync.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BleemSync.Services.Utilities
{
    public class FormatUtility
    {
        public void FormatDrive(DriveInfo driveInfo, DriveFormat format)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                FormatWindows(driveInfo, format);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                FormatMacOs(driveInfo, format);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                FormatLinux(driveInfo, format);
            }
            else
            {
                throw new NotSupportedException("This platform is not supported.");
            }
        }

        private void FormatWindows(DriveInfo driveInfo, DriveFormat format)
        {
            var volume = driveInfo.RootDirectory.FullName.Replace("\\", "");
            var proc = System.Diagnostics.Process.Start("format", $"");
            proc.WaitForExit();
            if (proc.ExitCode != 0) throw new IOException($"mv returned {proc.ExitCode}");
        }

        private void FormatMacOs(DriveInfo driveInfo, DriveFormat format)
        {
            throw new NotImplementedException();
        }

        private void FormatLinux(DriveInfo driveInfo, DriveFormat format)
        {
            throw new NotImplementedException();
        }
    }
}