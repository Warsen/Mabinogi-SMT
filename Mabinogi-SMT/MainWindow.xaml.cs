using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MabinogiSMT
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private UserConfiguration _userConfiguration = null!;
		private ViewChartWindow _viewChartWindow = null!;

		public MainWindow()
		{
			InitializeComponent();

			Loaded += OnLoaded;
			StateChanged += OnStateChanged;
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			_userConfiguration = DataContext as UserConfiguration ?? throw new InvalidOperationException("DataContext must be of type UserConfiguration.");
			_viewChartWindow = new ViewChartWindow()
			{
				DataContext = DataContext,
				Owner = Owner,
			};
		}

		private void OnStateChanged(object? sender, EventArgs e)
		{
			switch (WindowState)
			{
				case WindowState.Minimized:
					_viewChartWindow.WindowState = WindowState.Minimized;
					break;
				case WindowState.Normal:
					_viewChartWindow.WindowState = WindowState.Normal;
					break;
			}
		}

		private void CharacterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			KaourSpecialConfirmButton.IsEnabled = (_userConfiguration.KaourSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Kaour].Count - 1);
			ElsieSpecialConfirmButton.IsEnabled = (_userConfiguration.ElsieSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Elsie].Count - 1);
			DaiSpecialConfirmButton.IsEnabled = (_userConfiguration.DaiSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Dai].Count - 1);
			EirlysSpecialConfirmButton.IsEnabled = (_userConfiguration.EirlysSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Eirlys].Count - 1);
			KaourKeywordTextBlock1.Style = (Style)FindResource("KaourKeywordStyle1");
			KaourKeywordTextBlock2.Style = (Style)FindResource("KaourKeywordStyle1");
			KaourKeywordTextBlock3.Style = (Style)FindResource("KaourKeywordStyle1");
			ElsieKeywordTextBlock1.Style = (Style)FindResource("ElsieKeywordStyle1");
			ElsieKeywordTextBlock2.Style = (Style)FindResource("ElsieKeywordStyle1");
			ElsieKeywordTextBlock3.Style = (Style)FindResource("ElsieKeywordStyle1");
			DaiKeywordTextBlock1.Style = (Style)FindResource("DaiKeywordStyle1");
			DaiKeywordTextBlock2.Style = (Style)FindResource("DaiKeywordStyle1");
			DaiKeywordTextBlock3.Style = (Style)FindResource("DaiKeywordStyle1");
			EirlysKeywordTextBlock1.Style = (Style)FindResource("EirlysKeywordStyle1");
			EirlysKeywordTextBlock2.Style = (Style)FindResource("EirlysKeywordStyle1");
			EirlysKeywordTextBlock3.Style = (Style)FindResource("EirlysKeywordStyle1");
		}

		private void AddCharacterButton_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(CharacterComboBox.Text) && !string.Equals(CharacterComboBox.Text, _userConfiguration.SelectedCharacter.Name, StringComparison.OrdinalIgnoreCase))
			{
				if (string.IsNullOrWhiteSpace(_userConfiguration.SelectedCharacter.Name))
					_userConfiguration.NewCopyCharacter(CharacterComboBox.Text, _userConfiguration.SelectedCharacter);
				else
					_userConfiguration.NewCharacter(CharacterComboBox.Text);
			}
		}

		private void RemoveCharacterButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.Equals(CharacterComboBox.Text, _userConfiguration.SelectedCharacter.Name, StringComparison.OrdinalIgnoreCase) && _userConfiguration.ListOfCharacters.Count > 1)
				_userConfiguration.RemoveCharacter();
		}

		private void ResetDayButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.KaourSequenceBuffer > 0)
			{
				KaourKeywordTextBlock1.Style = (Style)FindResource("KaourKeywordStyle1");
				KaourKeywordTextBlock2.Style = (Style)FindResource("KaourKeywordStyle1");
				KaourKeywordTextBlock3.Style = (Style)FindResource("KaourKeywordStyle1");
			}
			if (_userConfiguration.ElsieSequenceBuffer > 0)
			{
				ElsieKeywordTextBlock1.Style = (Style)FindResource("ElsieKeywordStyle1");
				ElsieKeywordTextBlock2.Style = (Style)FindResource("ElsieKeywordStyle1");
				ElsieKeywordTextBlock3.Style = (Style)FindResource("ElsieKeywordStyle1");
			}
			if (_userConfiguration.DaiSequenceBuffer > 0)
			{
				DaiKeywordTextBlock1.Style = (Style)FindResource("DaiKeywordStyle1");
				DaiKeywordTextBlock2.Style = (Style)FindResource("DaiKeywordStyle1");
				DaiKeywordTextBlock3.Style = (Style)FindResource("DaiKeywordStyle1");
			}
			if (_userConfiguration.EirlysSequenceBuffer > 0)
			{
				EirlysKeywordTextBlock1.Style = (Style)FindResource("EirlysKeywordStyle1");
				EirlysKeywordTextBlock2.Style = (Style)FindResource("EirlysKeywordStyle1");
				EirlysKeywordTextBlock3.Style = (Style)FindResource("EirlysKeywordStyle1");
			}
			_userConfiguration.Flush();
		}

		private void KaourConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.KaourSequenceBuffer == 0)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					if (_userConfiguration.UseBuffering)
					{
						KaourKeywordTextBlock1.Style = (Style)FindResource("KaourKeywordStyle2");
						KaourKeywordTextBlock2.Style = (Style)FindResource("KaourKeywordStyle2");
						KaourKeywordTextBlock3.Style = (Style)FindResource("KaourKeywordStyle2");
					}
					_userConfiguration.KaourSequenceBuffer = 3;
				}
				else
				{
					if (_userConfiguration.UseBuffering)
						KaourKeywordTextBlock1.Style = (Style)FindResource("KaourKeywordStyle2");
					_userConfiguration.KaourSequenceBuffer = 1;
				}
			}
			else if (_userConfiguration.KaourSequenceBuffer == 1)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					KaourKeywordTextBlock2.Style = (Style)FindResource("KaourKeywordStyle2");
					KaourKeywordTextBlock3.Style = (Style)FindResource("KaourKeywordStyle2");
					_userConfiguration.KaourSequenceBuffer = 3;
				}
				else
				{
					KaourKeywordTextBlock2.Style = (Style)FindResource("KaourKeywordStyle2");
					_userConfiguration.KaourSequenceBuffer = 2;
				}
			}
			else if (_userConfiguration.KaourSequenceBuffer == 2)
			{
				KaourKeywordTextBlock3.Style = (Style)FindResource("KaourKeywordStyle2");
				_userConfiguration.KaourSequenceBuffer = 3;
			}
		}

		private void KaourViewChartButton_Click(object sender, RoutedEventArgs e)
		{
			_userConfiguration.SelectedSquire = Squire.Kaour;
			_viewChartWindow.Top = RestoreBounds.TopRight.Y;
			_viewChartWindow.Left = RestoreBounds.TopRight.X;
			_viewChartWindow.DataContext = DataContext;
			_viewChartWindow.Show();
		}

		private void KaourSpecialConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.KaourSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Kaour].Count - 1)
			{
				_userConfiguration.KaourSpecialSequence += 1;
				if (_userConfiguration.KaourSpecialSequence == Character.SquireSpecialSequenceTable[(int)Squire.Kaour].Count - 1)
					KaourSpecialConfirmButton.IsEnabled = false;
			}
		}

		private void ElsieConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.ElsieSequenceBuffer == 0)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					if (_userConfiguration.UseBuffering)
					{
						ElsieKeywordTextBlock1.Style = (Style)FindResource("ElsieKeywordStyle2");
						ElsieKeywordTextBlock2.Style = (Style)FindResource("ElsieKeywordStyle2");
						ElsieKeywordTextBlock3.Style = (Style)FindResource("ElsieKeywordStyle2");
					}
					_userConfiguration.ElsieSequenceBuffer = 3;
				}
				else
				{
					if (_userConfiguration.UseBuffering)
						ElsieKeywordTextBlock1.Style = (Style)FindResource("ElsieKeywordStyle2");
					_userConfiguration.ElsieSequenceBuffer = 1;
				}
			}
			else if (_userConfiguration.ElsieSequenceBuffer == 1)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					ElsieKeywordTextBlock2.Style = (Style)FindResource("ElsieKeywordStyle2");
					ElsieKeywordTextBlock3.Style = (Style)FindResource("ElsieKeywordStyle2");
					_userConfiguration.ElsieSequenceBuffer = 3;
				}
				else
				{
					ElsieKeywordTextBlock2.Style = (Style)FindResource("ElsieKeywordStyle2");
					_userConfiguration.ElsieSequenceBuffer = 2;
				}
			}
			else if (_userConfiguration.ElsieSequenceBuffer == 2)
			{
				ElsieKeywordTextBlock3.Style = (Style)FindResource("ElsieKeywordStyle2");
				_userConfiguration.ElsieSequenceBuffer = 3;
			}
		}

		private void ElsieViewChartButton_Click(object sender, RoutedEventArgs e)
		{
			_userConfiguration.SelectedSquire = Squire.Elsie;
			_viewChartWindow.Top = RestoreBounds.TopRight.Y;
			_viewChartWindow.Left = RestoreBounds.TopRight.X;
			_viewChartWindow.DataContext = DataContext;
			_viewChartWindow.Show();
		}

		private void ElsieSpecialConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.ElsieSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Elsie].Count - 1)
			{
				_userConfiguration.ElsieSpecialSequence += 1;
				if (_userConfiguration.ElsieSpecialSequence == Character.SquireSpecialSequenceTable[(int)Squire.Elsie].Count - 1)
					ElsieSpecialConfirmButton.IsEnabled = false;
			}
		}

		private void DaiConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.DaiSequenceBuffer == 0)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					if (_userConfiguration.UseBuffering)
					{
						DaiKeywordTextBlock1.Style = (Style)FindResource("DaiKeywordStyle2");
						DaiKeywordTextBlock2.Style = (Style)FindResource("DaiKeywordStyle2");
						DaiKeywordTextBlock3.Style = (Style)FindResource("DaiKeywordStyle2");
					}
					_userConfiguration.DaiSequenceBuffer = 3;
				}
				else
				{
					if (_userConfiguration.UseBuffering)
						DaiKeywordTextBlock1.Style = (Style)FindResource("DaiKeywordStyle2");
					_userConfiguration.DaiSequenceBuffer = 1;
				}
			}
			else if (_userConfiguration.DaiSequenceBuffer == 1)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					DaiKeywordTextBlock2.Style = (Style)FindResource("DaiKeywordStyle2");
					DaiKeywordTextBlock3.Style = (Style)FindResource("DaiKeywordStyle2");
					_userConfiguration.DaiSequenceBuffer = 3;
				}
				else
				{
					DaiKeywordTextBlock2.Style = (Style)FindResource("DaiKeywordStyle2");
					_userConfiguration.DaiSequenceBuffer = 2;
				}
			}
			else if (_userConfiguration.DaiSequenceBuffer == 2)
			{
				DaiKeywordTextBlock3.Style = (Style)FindResource("DaiKeywordStyle2");
				_userConfiguration.DaiSequenceBuffer = 3;
			}
		}

		private void DaiViewChartButton_Click(object sender, RoutedEventArgs e)
		{
			_userConfiguration.SelectedSquire = Squire.Dai;
			_viewChartWindow.Top = RestoreBounds.TopRight.Y;
			_viewChartWindow.Left = RestoreBounds.TopRight.X;
			_viewChartWindow.DataContext = DataContext;
			_viewChartWindow.Show();
		}

		private void DaiSpecialConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.DaiSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Dai].Count - 1)
			{
				_userConfiguration.DaiSpecialSequence += 1;
				if (_userConfiguration.DaiSpecialSequence == Character.SquireSpecialSequenceTable[(int)Squire.Dai].Count - 1)
					DaiSpecialConfirmButton.IsEnabled = false;
			}
		}

		private void EirlysConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.EirlysSequenceBuffer == 0)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					if (_userConfiguration.UseBuffering)
					{
						EirlysKeywordTextBlock1.Style = (Style)FindResource("EirlysKeywordStyle2");
						EirlysKeywordTextBlock2.Style = (Style)FindResource("EirlysKeywordStyle2");
						EirlysKeywordTextBlock3.Style = (Style)FindResource("EirlysKeywordStyle2");
					}
					_userConfiguration.EirlysSequenceBuffer = 3;
				}
				else
				{
					if (_userConfiguration.UseBuffering)
						EirlysKeywordTextBlock1.Style = (Style)FindResource("EirlysKeywordStyle2");
					_userConfiguration.EirlysSequenceBuffer = 1;
				}
			}
			else if (_userConfiguration.EirlysSequenceBuffer == 1)
			{
				if (ConfirmThreeCheckBox.IsChecked.HasValue && ConfirmThreeCheckBox.IsChecked.Value)
				{
					EirlysKeywordTextBlock2.Style = (Style)FindResource("EirlysKeywordStyle2");
					EirlysKeywordTextBlock3.Style = (Style)FindResource("EirlysKeywordStyle2");
					_userConfiguration.EirlysSequenceBuffer = 3;
				}
				else
				{
					EirlysKeywordTextBlock2.Style = (Style)FindResource("EirlysKeywordStyle2");
					_userConfiguration.EirlysSequenceBuffer = 2;
				}
			}
			else if (_userConfiguration.EirlysSequenceBuffer == 2)
			{
				EirlysKeywordTextBlock3.Style = (Style)FindResource("EirlysKeywordStyle2");
				_userConfiguration.EirlysSequenceBuffer = 3;
			}
		}

		private void EirlysViewChartButton_Click(object sender, RoutedEventArgs e)
		{
			_userConfiguration.SelectedSquire = Squire.Eirlys;
			_viewChartWindow.Top = RestoreBounds.TopRight.Y;
			_viewChartWindow.Left = RestoreBounds.TopRight.X;
			_viewChartWindow.DataContext = DataContext;
			_viewChartWindow.Show();
		}

		private void EirlysSpecialConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			if (_userConfiguration.EirlysSpecialSequence < Character.SquireSpecialSequenceTable[(int)Squire.Eirlys].Count - 1)
			{
				_userConfiguration.EirlysSpecialSequence += 1;
				if (_userConfiguration.EirlysSpecialSequence == Character.SquireSpecialSequenceTable[(int)Squire.Eirlys].Count - 1)
					EirlysSpecialConfirmButton.IsEnabled = false;
			}
		}

		private void UseBufferingCheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			KaourKeywordTextBlock1.Style = (Style)FindResource("KaourKeywordStyle1");
			KaourKeywordTextBlock2.Style = (Style)FindResource("KaourKeywordStyle1");
			KaourKeywordTextBlock3.Style = (Style)FindResource("KaourKeywordStyle1");
			ElsieKeywordTextBlock1.Style = (Style)FindResource("ElsieKeywordStyle1");
			ElsieKeywordTextBlock2.Style = (Style)FindResource("ElsieKeywordStyle1");
			ElsieKeywordTextBlock3.Style = (Style)FindResource("ElsieKeywordStyle1");
			DaiKeywordTextBlock1.Style = (Style)FindResource("DaiKeywordStyle1");
			DaiKeywordTextBlock2.Style = (Style)FindResource("DaiKeywordStyle1");
			DaiKeywordTextBlock3.Style = (Style)FindResource("DaiKeywordStyle1");
			EirlysKeywordTextBlock1.Style = (Style)FindResource("EirlysKeywordStyle1");
			EirlysKeywordTextBlock2.Style = (Style)FindResource("EirlysKeywordStyle1");
			EirlysKeywordTextBlock3.Style = (Style)FindResource("EirlysKeywordStyle1");
		}
	}
}