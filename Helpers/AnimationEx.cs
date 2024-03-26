namespace DaddyRecoveryBuilder.Helpers
{
    using System;

    public static class AnimationEx
    {
        public static bool Show(IntPtr hWnd, int time, Enums.AnimateWindowFlags flags) => NativeMethods.AnimateWindow(hWnd, time, flags);
    }
}