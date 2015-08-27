using System.Windows;
using System.Windows.Controls;

namespace Wox.Plugin.CMD
{
    public partial class CMDSetting : UserControl
    {
        public CMDSetting()
        {
            InitializeComponent();
        }

        private void CMDSetting_OnLoaded(object sender, RoutedEventArgs re)
        {
            cbReplaceWinR.IsChecked = CMDStorage.Instance.ReplaceWinR;

            cbReplaceWinR.Checked += (o, e) =>
            {
                CMDStorage.Instance.ReplaceWinR = true;
                CMDStorage.Instance.Save();
            };
            cbReplaceWinR.Unchecked += (o, e) =>
            {
                CMDStorage.Instance.ReplaceWinR = false;
                CMDStorage.Instance.Save();
            };
        }
    }
}
