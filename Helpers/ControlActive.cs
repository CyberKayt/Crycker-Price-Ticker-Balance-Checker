namespace DaddyRecoveryBuilder.Helpers
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public static class ControlActive
    {
        /// <summary>
        /// Метод для показа сообщения на короткий промежуток времени
        /// </summary>
        /// <param name="MessageShow">Элемент управления</param>
        /// <param name="Text">Текст сообщения</param>
        /// <param name="Time">Время показа сообщения</param>
        public static async void ShowTextAsync(Label MessageShow, string Text, Color color, int Time)
        {
            try
            {
                MessageShow.Visible = true; // Показывает элемент управления пользователю
                MessageShow.ForeColor = color;
                MessageShow.Text = Text; // Устанавливаем текст
                await Task.Run(() =>
                {
                    Thread.Sleep(Time); // Ожидаем какой-то промежуток времени
                    // Скрываем элемент управления
                    MessageShow.Invoke((Action)(() => { MessageShow.Visible = false; }));
                }).ConfigureAwait(false);
            }
            catch { }
        }

        public static void ControlVisible(Panel Panl, UserControl Uc)
        {
            try
            {
                if (Panl.Controls.Contains(Panl.Controls.OfType<UserControl>().Where(g => g.Name == Uc.Name).FirstOrDefault()))
                {
                    Panl.Controls.OfType<UserControl>().FirstOrDefault(g => g.Name == Uc.Name).BringToFront();
                }
                else
                {
                    Panl.Controls.Add(Uc);
                    Uc.BringToFront();
                }
            }
            catch (Exception) { }
        }
    }
}