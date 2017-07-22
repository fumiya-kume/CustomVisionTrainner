using System.Windows;
using Windows.UI.Notifications;

namespace CustomVisionTrainner.Service
{
    public class PopupService : IPopupService
    {
        public void Popup(string Message)
        {
            MessageBox.Show(Message, "エラーが発生しました", MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
