using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MabinogiSMT
{
    partial class ViewChartWindow : Window
    {
		private UserConfiguration _userConfiguration = null!;

		public ViewChartWindow()
		{
			InitializeComponent();

			Loaded += OnLoaded;
			Closing += OnClosing;
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			_userConfiguration = DataContext as UserConfiguration ?? throw new InvalidOperationException("DataContext must be of type UserConfiguration.");
		}

		private void OnClosing(object? sender, CancelEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void SquireSequenceTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return && byte.TryParse(SquireSequenceTextBox.Text, out byte sequence) && sequence >= 1 && sequence <= 97)
				_userConfiguration.SelectedCharacterSquireSequence = sequence;
		}
	}
}
