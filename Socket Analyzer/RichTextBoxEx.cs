﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace yournamespace
{
    public class RichTextBoxEx : RichTextBox
    {
        const int WM_USER = 0x400;
        const int WM_SETREDRAW = 0x000B;
        const int EM_GETEVENTMASK = WM_USER + 59;
        const int EM_SETEVENTMASK = WM_USER + 69;
        const int EM_GETSCROLLPOS = WM_USER + 221;
        const int EM_SETSCROLLPOS = WM_USER + 222;

        bool _Painting = true;
        Point _ScrollPoint;
        IntPtr _EventMask;
        int _SuspendIndex = 0;
        int _SuspendLength = 0;

        public bool Autoscroll { get; set; } = true;

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, IntPtr lParam);

        public void SuspendPainting()
        {
            if (_Painting)
            {
                _SuspendIndex = this.SelectionStart;
                _SuspendLength = this.SelectionLength;
                SendMessage(this.Handle, EM_GETSCROLLPOS, 0, ref _ScrollPoint);
                SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                _EventMask = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
                _Painting = false;
            }
        }

        public void ResumePainting()
        {
            if (!_Painting)
            {
                this.Select(_SuspendIndex, _SuspendLength);
                SendMessage(this.Handle, EM_SETSCROLLPOS, 0, ref _ScrollPoint);
                SendMessage(this.Handle, EM_SETEVENTMASK, 0, _EventMask);
                SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                _Painting = true;
                this.Invalidate();
            }
        }

        new public void AppendText(string text)  // overwrites RichTextBox.AppendText
        {
            if (!Autoscroll)
            {
                SuspendPainting();
                base.AppendText(text);
                ResumePainting();
            }
            else
            {
                base.AppendText(text);
            }
        }

        public void AppendText(string text, Color color)
        {
            if (!Autoscroll)
            {
                SuspendPainting();
                SelectionStart = TextLength;
                SelectionLength = 0;
                SelectionColor = color;
                base.AppendText(text);
                ResumePainting();
            }
            else
            {
                SelectionStart = TextLength;
                SelectionLength = 0;
                SelectionColor = color;
                base.AppendText(text);
                if (!Focused) ScrollToCaret();
            }
        }
    }
}