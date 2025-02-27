﻿using System.Runtime.InteropServices;

namespace AmeisenBotX.Wow.Objects.Raw
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RawRaidPlayer
    {
        public ulong Guid { get; set; }

        public fixed ulong Padding[9];
    }
}