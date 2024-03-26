namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.IO;
    using System.Media;

    public static class MusicPlay
    {
        public static void Inizialize(UnmanagedMemoryStream stream)
        {
            try
            {
                using var snd = new SoundPlayer(stream);
                snd?.Load();
                if (snd.IsLoadCompleted)
                {
                    snd.Play();
                }
            }
            catch (Exception ex) { File.WriteAllText(GlobalPaths.CombinePath(GlobalPaths.CurrDir, "ErrorPlay.txt"), ex.Message); }
        }
    }
}