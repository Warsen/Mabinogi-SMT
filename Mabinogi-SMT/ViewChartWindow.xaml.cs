using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MSMT
{
	public partial class ViewChartWindow : Window
	{
		public UserConfiguration UserConfiguration
		{
			get
			{
				return _userConfiguration;
			}
			set
			{
				_userConfiguration = value;
			}
		}

		private UserConfiguration _userConfiguration;

		public ViewChartWindow()
		{
			InitializeComponent();
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void SquireSequenceTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				byte sequence;
				if (Byte.TryParse(SquireSequenceTextBox.Text, out sequence) && sequence >= 1 && sequence <= 97)
					_userConfiguration.SelectedCharacterSquireSequence = sequence;
			}
		}
	}
}
