﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Yv6502
{
    public partial class Cpu
    {
        private void Bcc(byte op)
        {
            if (!regs.Is(Status.Carry))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte) (rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte) (rt >> 8);
                regs.PcLow = (byte) rt;
            }
        }

        private void Bcs(byte op)
        {
            if (regs.Is(Status.Carry))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }

        private void Beq(byte op)
        {
            if (regs.Is(Status.Zero))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }

        private void Bne(byte op)
        {
            if (!regs.Is(Status.Zero))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }

        private void Bmi(byte op)
        {
            if (regs.Is(Status.Sign))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }

        private void Bpl(byte op)
        {
            if (!regs.Is(Status.Sign))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }

        private void Bvc(byte op)
        {
            if (!regs.Is(Status.VOverflow))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }

        private void Bvs(byte op)
        {
            if (regs.Is(Status.VOverflow))
            {
                ushort rt = GetRelAddr(op);
                clock += regs.PcHigh != (byte)(rt >> 8) ? 2 : 1;
                regs.PcHigh = (byte)(rt >> 8);
                regs.PcLow = (byte)rt;
            }
        }
    }
}
