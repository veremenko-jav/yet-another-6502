﻿using System;
using Yv6502;

namespace Yv6502Emu
{
    public class GrantsSimple6502 : Cpu
    {
        public GrantsSimple6502(byte[] rom)
        {
            var ram = new byte[0x8000];
            RegisterIo(0x0000, 0x7fff, (ref IoEventArgs e) =>
            {
                if (e.IsWrite)
                {
                    ram[e.Address] = e.Value;
                }
                e.Value = ram[e.Address];
            });
            RegisterIo(0xC000, 0xffff, (ref IoEventArgs e) =>
            {
                var addr = (ushort)(e.Address - 0xC000);
                if (e.IsWrite)
                {
                    rom[addr] = e.Value;
                }
                else
                {
                    e.Value = rom[addr];
                }
            });
            RegisterIo(0xA000, (ref IoEventArgs e) =>
            {
                var res = Console.KeyAvailable ? 0x01 : 0;
                e.Value = (byte)(res | 0x02);
            });
            RegisterIo(0xA001, (ref IoEventArgs e) =>
            {
                if (e.IsWrite)
                {
                    Console.Write((char)e.Value);
                }
                else
                {
                    var c = char.ToUpperInvariant(Console.ReadKey(true).KeyChar);
                    e.Value = (byte)c;
                }
            });
        }

        public new void Step()
        {
            base.Step();
        }
    }
}
