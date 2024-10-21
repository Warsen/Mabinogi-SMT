using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows;

namespace MabinogiSMT
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static MainWindow? _mainWindow;
		private static FileStream? _fileStream;
		private static readonly UserConfiguration _userConfiguration = new();
		private static bool _hasPropertyChanged = false;
		private static double _savedLeft = 0;
		private static double _savedTop = 0;

		private void Application_Startup(object? sender, StartupEventArgs e)
		{
			_userConfiguration.PropertyChanged += UserConfiguration_PropertyChanged;

			try
			{
				if (File.Exists("configuration.txt"))
				{
					_fileStream = new FileStream("configuration.txt", FileMode.Open);
					StreamReader reader = new(_fileStream, System.Text.Encoding.Default, true, 256, true);
					string[] words = reader.ReadLine()!.Split(',');
					_savedLeft = int.Parse(words[0]);
					_savedTop = int.Parse(words[1]);
					_userConfiguration.LoadConfiguration(reader);
				}
				else
				{
					_fileStream = new FileStream("configuration.txt", FileMode.CreateNew);
				}
			}
			catch
			{
				MessageBox.Show("Unable to read configuration.txt", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			// Create a hidden window to achieve the effect that when the main window is restored from minimized,
			// the hidden window as the owner window gains focus, and all of it's sub windows will be restored.
			Window hiddenWindow = new()
			{
				AllowsTransparency = true,
				Height = 0,
				Opacity = 0,
				ShowInTaskbar = false,
				Width = 0,
				WindowStyle = WindowStyle.None,
			};
			hiddenWindow.Show();
			hiddenWindow.Hide();

			_mainWindow = new MainWindow()
			{
				DataContext = _userConfiguration,
				Owner = hiddenWindow,
				Left = _savedLeft,
				Top = _savedTop,
			};
			MainWindow = _mainWindow;
			_mainWindow.Closing += OnClosing;
			_mainWindow.Show();
		}

		private void UserConfiguration_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			_hasPropertyChanged = true;
			_userConfiguration.PropertyChanged -= UserConfiguration_PropertyChanged;
		}

		private void OnClosing(object? sender, CancelEventArgs e)
		{
			if (_mainWindow == null)
				return;

			if (_savedLeft != _mainWindow.Left || _savedTop != _mainWindow.Top)
			{
				_hasPropertyChanged = true;
				_savedLeft = _mainWindow.Left;
				_savedTop = _mainWindow.Top;
			}
		}

		private void Application_Exit(object? sender, ExitEventArgs e)
		{
			if (_fileStream == null)
				return;

			if (_hasPropertyChanged)
			{
				try
				{
					_fileStream.Position = 0;
					_fileStream.SetLength(0L);
					StreamWriter writer = new(_fileStream, System.Text.Encoding.Default, 256, false);
					writer.Write((int)_savedLeft);
					writer.Write(',');
					writer.Write((int)_savedTop);
					writer.WriteLine();
					_userConfiguration.SaveConfiguration(writer);
					writer.Flush();
					writer.Close();
				}
				catch
				{
					MessageBox.Show("Unable to write configuration.txt", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
	}
}
