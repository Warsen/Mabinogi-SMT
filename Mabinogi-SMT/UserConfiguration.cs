using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace MabinogiSMT
{
	public class UserConfiguration : INotifyPropertyChanged
	{
		private readonly List<Character> _listOfCharacters = [];
		private Character _selectedCharacter = new("");
		private bool _alwaysOnTop = true;
		private bool _confirmThree = true;
		private bool _useBuffering = true;
		private byte _kaourSequenceBuffer = 0;
		private byte _elsieSequenceBuffer = 0;
		private byte _daiSequenceBuffer = 0;
		private byte _eirlysSequenceBuffer = 0;
		private Squire _selectedSquire = Squire.Kaour;

		public ReadOnlyCollection<Character> ListOfCharacters
		{
			get
			{
				return _listOfCharacters.AsReadOnly();
			}
		}
		public Character SelectedCharacter
		{
			get
			{
				return _selectedCharacter;
			}
			set
			{
				if (value != null && value != _selectedCharacter)
				{
					if (_kaourSequenceBuffer > 0)
					{
						_selectedCharacter.KaourSequence = (byte)((_selectedCharacter.KaourSequence + _kaourSequenceBuffer) % 97);
						_kaourSequenceBuffer = 0;
						OnPropertyChanged(nameof(KaourSequenceBuffer));
					}
					if (_elsieSequenceBuffer > 0)
					{
						_selectedCharacter.ElsieSequence = (byte)((_selectedCharacter.ElsieSequence + _elsieSequenceBuffer) % 97);
						_elsieSequenceBuffer = 0;
						OnPropertyChanged(nameof(ElsieSequenceBuffer));
					}
					if (_daiSequenceBuffer > 0)
					{
						_selectedCharacter.DaiSequence = (byte)((_selectedCharacter.DaiSequence + _daiSequenceBuffer) % 97);
						_daiSequenceBuffer = 0;
						OnPropertyChanged(nameof(DaiSequenceBuffer));
					}
					if (_eirlysSequenceBuffer > 0)
					{
						_selectedCharacter.EirlysSequence = (byte)((_selectedCharacter.EirlysSequence + _eirlysSequenceBuffer) % 97);
						_eirlysSequenceBuffer = 0;
						OnPropertyChanged(nameof(EirlysSequenceBuffer));
					}
					_selectedCharacter = value;
					OnPropertyChanged(nameof(KaourKeyword1));
					OnPropertyChanged(nameof(KaourKeyword2));
					OnPropertyChanged(nameof(KaourKeyword3));
					OnPropertyChanged(nameof(KaourSpecialKeyword));
					OnPropertyChanged(nameof(ElsieKeyword1));
					OnPropertyChanged(nameof(ElsieKeyword2));
					OnPropertyChanged(nameof(ElsieKeyword3));
					OnPropertyChanged(nameof(ElsieSpecialKeyword));
					OnPropertyChanged(nameof(DaiKeyword1));
					OnPropertyChanged(nameof(DaiKeyword2));
					OnPropertyChanged(nameof(DaiKeyword3));
					OnPropertyChanged(nameof(DaiSpecialKeyword));
					OnPropertyChanged(nameof(EirlysKeyword1));
					OnPropertyChanged(nameof(EirlysKeyword2));
					OnPropertyChanged(nameof(EirlysKeyword3));
					OnPropertyChanged(nameof(EirlysSpecialKeyword));
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
				}
			}
		}
		public bool AlwaysOnTop
		{
			get
			{
				return _alwaysOnTop;
			}
			set
			{
				_alwaysOnTop = value;
				OnPropertyChanged();
			}
		}
		public bool ConfirmThree
		{
			get
			{
				return _confirmThree;
			}
			set
			{
				_confirmThree = value;
				OnPropertyChanged();
			}
		}
		public bool UseBuffering
		{
			get
			{
				return _useBuffering;
			}
			set
			{
				_useBuffering = value;
				OnPropertyChanged();
				if (value == false)
					Flush();
			}
		}
		public byte KaourSequence
		{
			get
			{
				return _selectedCharacter.KaourSequence;
			}
			set
			{
				_selectedCharacter.KaourSequence = (byte)(value % 97);
				OnPropertyChanged();
				OnPropertyChanged(nameof(KaourKeyword1));
				OnPropertyChanged(nameof(KaourKeyword2));
				OnPropertyChanged(nameof(KaourKeyword3));

				if (_selectedSquire == Squire.Kaour)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte KaourSequenceBuffer
		{
			get
			{
				return _kaourSequenceBuffer;
			}
			set
			{
				if (_useBuffering)
				{
					_kaourSequenceBuffer = value;
					OnPropertyChanged();
				}
				else
				{
					_selectedCharacter.KaourSequence = (byte)((_selectedCharacter.KaourSequence + value) % 97);
					OnPropertyChanged(nameof(KaourSequence));
					OnPropertyChanged(nameof(KaourKeyword1));
					OnPropertyChanged(nameof(KaourKeyword2));
					OnPropertyChanged(nameof(KaourKeyword3));
				}

				if (_selectedSquire == Squire.Kaour)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte KaourSpecialSequence
		{
			get
			{
				return _selectedCharacter.KaourSpecialSequence;
			}
			set
			{
				_selectedCharacter.KaourSpecialSequence = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(KaourSpecialKeyword));
			}
		}
		public string KaourKeyword1 { get { return Character.SquireSequenceTable[(int)Squire.Kaour][_selectedCharacter.KaourSequence].ToString(); } }
		public string KaourKeyword2 { get { return Character.SquireSequenceTable[(int)Squire.Kaour][_selectedCharacter.KaourSequence + 1].ToString(); } }
		public string KaourKeyword3 { get { return Character.SquireSequenceTable[(int)Squire.Kaour][_selectedCharacter.KaourSequence + 2].ToString(); } }
		public string KaourSpecialKeyword { get { return Character.SquireSpecialSequenceTable[(int)Squire.Kaour][_selectedCharacter.KaourSpecialSequence]; } }
		public byte ElsieSequence
		{
			get
			{
				return _selectedCharacter.ElsieSequence;
			}
			set
			{
				_selectedCharacter.ElsieSequence = (byte)(value % 97);
				OnPropertyChanged();
				OnPropertyChanged(nameof(ElsieKeyword1));
				OnPropertyChanged(nameof(ElsieKeyword2));
				OnPropertyChanged(nameof(ElsieKeyword3));

				if (_selectedSquire == Squire.Elsie)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte ElsieSequenceBuffer
		{
			get
			{
				return _elsieSequenceBuffer;
			}
			set
			{
				if (_useBuffering)
				{
					_elsieSequenceBuffer = value;
					OnPropertyChanged();
				}
				else
				{
					_selectedCharacter.ElsieSequence = (byte)((_selectedCharacter.ElsieSequence + value) % 97);
					OnPropertyChanged(nameof(ElsieSequence));
					OnPropertyChanged(nameof(ElsieKeyword1));
					OnPropertyChanged(nameof(ElsieKeyword2));
					OnPropertyChanged(nameof(ElsieKeyword3));
				}

				if (_selectedSquire == Squire.Elsie)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte ElsieSpecialSequence
		{
			get
			{
				return _selectedCharacter.ElsieSpecialSequence;
			}
			set
			{
				_selectedCharacter.ElsieSpecialSequence = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ElsieSpecialKeyword));
			}
		}
		public string ElsieKeyword1 { get { return Character.SquireSequenceTable[(int)Squire.Elsie][_selectedCharacter.ElsieSequence].ToString(); } }
		public string ElsieKeyword2 { get { return Character.SquireSequenceTable[(int)Squire.Elsie][_selectedCharacter.ElsieSequence + 1].ToString(); } }
		public string ElsieKeyword3 { get { return Character.SquireSequenceTable[(int)Squire.Elsie][_selectedCharacter.ElsieSequence + 2].ToString(); } }
		public string ElsieSpecialKeyword { get { return Character.SquireSpecialSequenceTable[(int)Squire.Elsie][_selectedCharacter.ElsieSpecialSequence]; } }
		public byte DaiSequence
		{
			get
			{
				return _selectedCharacter.DaiSequence;
			}
			set
			{
				_selectedCharacter.DaiSequence = (byte)(value % 97);
				OnPropertyChanged();
				OnPropertyChanged(nameof(DaiKeyword1));
				OnPropertyChanged(nameof(DaiKeyword2));
				OnPropertyChanged(nameof(DaiKeyword3));

				if (_selectedSquire == Squire.Dai)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte DaiSequenceBuffer
		{
			get
			{
				return _daiSequenceBuffer;
			}
			set
			{
				if (_useBuffering)
				{
					_daiSequenceBuffer = value;
					OnPropertyChanged();
				}
				else
				{
					_selectedCharacter.DaiSequence = (byte)((_selectedCharacter.DaiSequence + value) % 97);
					OnPropertyChanged(nameof(DaiSequence));
					OnPropertyChanged(nameof(DaiKeyword1));
					OnPropertyChanged(nameof(DaiKeyword2));
					OnPropertyChanged(nameof(DaiKeyword3));
				}

				if (_selectedSquire == Squire.Dai)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte DaiSpecialSequence
		{
			get
			{
				return _selectedCharacter.DaiSpecialSequence;
			}
			set
			{
				_selectedCharacter.DaiSpecialSequence = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(DaiSpecialKeyword));
			}
		}
		public string DaiKeyword1 { get { return Character.SquireSequenceTable[(int)Squire.Dai][_selectedCharacter.DaiSequence].ToString(); } }
		public string DaiKeyword2 { get { return Character.SquireSequenceTable[(int)Squire.Dai][_selectedCharacter.DaiSequence + 1].ToString(); } }
		public string DaiKeyword3 { get { return Character.SquireSequenceTable[(int)Squire.Dai][_selectedCharacter.DaiSequence + 2].ToString(); } }
		public string DaiSpecialKeyword { get { return Character.SquireSpecialSequenceTable[(int)Squire.Dai][_selectedCharacter.DaiSpecialSequence]; } }
		public byte EirlysSequence
		{
			get
			{
				return _selectedCharacter.EirlysSequence;
			}
			set
			{
				_selectedCharacter.EirlysSequence = (byte)(value % 97);
				OnPropertyChanged();
				OnPropertyChanged(nameof(EirlysKeyword1));
				OnPropertyChanged(nameof(EirlysKeyword2));
				OnPropertyChanged(nameof(EirlysKeyword3));

				if (_selectedSquire == Squire.Eirlys)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte EirlysSequenceBuffer
		{
			get
			{
				return _eirlysSequenceBuffer;
			}
			set
			{
				if (_useBuffering)
				{
					_eirlysSequenceBuffer = value;
					OnPropertyChanged();
				}
				else
				{
					_selectedCharacter.EirlysSequence = (byte)((_selectedCharacter.EirlysSequence + value) % 97);
					OnPropertyChanged(nameof(EirlysSequence));
					OnPropertyChanged(nameof(EirlysKeyword1));
					OnPropertyChanged(nameof(EirlysKeyword2));
					OnPropertyChanged(nameof(EirlysKeyword3));
				}

				if (_selectedSquire == Squire.Eirlys)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public byte EirlysSpecialSequence
		{
			get
			{
				return _selectedCharacter.EirlysSpecialSequence;
			}
			set
			{
				_selectedCharacter.EirlysSpecialSequence = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(EirlysSpecialKeyword));
			}
		}
		public string EirlysKeyword1 { get { return Character.SquireSequenceTable[(int)Squire.Eirlys][_selectedCharacter.EirlysSequence].ToString(); } }
		public string EirlysKeyword2 { get { return Character.SquireSequenceTable[(int)Squire.Eirlys][_selectedCharacter.EirlysSequence + 1].ToString(); } }
		public string EirlysKeyword3 { get { return Character.SquireSequenceTable[(int)Squire.Eirlys][_selectedCharacter.EirlysSequence + 2].ToString(); } }
		public string EirlysSpecialKeyword { get { return Character.SquireSpecialSequenceTable[(int)Squire.Eirlys][_selectedCharacter.EirlysSpecialSequence]; } }
		public Squire SelectedSquire
		{
			get
			{
				return _selectedSquire;
			}
			set
			{
				_selectedSquire = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(SelectedSquireKeywords));
				OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}
		public ReadOnlyCollection<Keyword> SelectedSquireKeywords
		{
			get
			{
				return Character.SquireSequenceTable[(int)_selectedSquire];
			}
		}
		public byte SelectedCharacterSquireSequence
		{
			get
			{
				return _selectedSquire switch
				{
					Squire.Kaour => (byte)(_selectedCharacter.KaourSequence + _kaourSequenceBuffer + 1),
					Squire.Elsie => (byte)(_selectedCharacter.ElsieSequence + _elsieSequenceBuffer + 1),
					Squire.Dai => (byte)(_selectedCharacter.DaiSequence + _daiSequenceBuffer + 1),
					_ => (byte)(_selectedCharacter.EirlysSequence + _eirlysSequenceBuffer + 1),
				};
			}
			set
			{
				Flush();
				switch (_selectedSquire)
				{
					case Squire.Kaour: default:
						_selectedCharacter.KaourSequence = (byte)(value - 1);
						OnPropertyChanged(nameof(KaourSequence));
						OnPropertyChanged(nameof(KaourKeyword1));
						OnPropertyChanged(nameof(KaourKeyword2));
						OnPropertyChanged(nameof(KaourKeyword3));
						break;
					case Squire.Elsie:
						_selectedCharacter.ElsieSequence = (byte)(value - 1);
						OnPropertyChanged(nameof(ElsieSequence));
						OnPropertyChanged(nameof(ElsieKeyword1));
						OnPropertyChanged(nameof(ElsieKeyword2));
						OnPropertyChanged(nameof(ElsieKeyword3));
						break;
					case Squire.Dai:
						_selectedCharacter.DaiSequence = (byte)(value - 1);
						OnPropertyChanged(nameof(DaiSequence));
						OnPropertyChanged(nameof(DaiKeyword1));
						OnPropertyChanged(nameof(DaiKeyword2));
						OnPropertyChanged(nameof(DaiKeyword3));
						break;
					case Squire.Eirlys:
						_selectedCharacter.EirlysSequence = (byte)(value - 1);
						OnPropertyChanged(nameof(EirlysSequence));
						OnPropertyChanged(nameof(EirlysKeyword1));
						OnPropertyChanged(nameof(EirlysKeyword2));
						OnPropertyChanged(nameof(EirlysKeyword3));
						break;
				}
				OnPropertyChanged();
			}
		}

		public void NewCharacter(string name)
		{
			ArgumentNullException.ThrowIfNull(name, nameof(name));
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Character name cannot be null or whitespace.", nameof(name));

			if (!_listOfCharacters.Exists((x) => x.Name == name))
			{
				SelectedCharacter = new Character(name);
				_listOfCharacters.Add(_selectedCharacter);
				OnPropertyChanged(nameof(ListOfCharacters));
			}
		}

		public void NewCopyCharacter(string name, Character copyFromCharacter)
		{
			ArgumentNullException.ThrowIfNull(name, nameof(name));
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Character name cannot be null or whitespace.", nameof(name));

			if (!_listOfCharacters.Exists((x) => x.Name == name))
			{
				SelectedCharacter = new Character(name, copyFromCharacter);
				_listOfCharacters.Add(_selectedCharacter);
				OnPropertyChanged(nameof(ListOfCharacters));
			}
		}

		public void RemoveCharacter()
		{
			if (_listOfCharacters.Count > 1)
			{
				_listOfCharacters.Remove(_selectedCharacter);
				SelectedCharacter = _listOfCharacters[0];
				OnPropertyChanged(nameof(ListOfCharacters));
			}
		}

		public void Flush()
		{
			if (_kaourSequenceBuffer > 0)
			{
				_selectedCharacter.KaourSequence = (byte)((_selectedCharacter.KaourSequence + _kaourSequenceBuffer) % 97);
				_kaourSequenceBuffer = 0;
				OnPropertyChanged(nameof(KaourSequenceBuffer));
				OnPropertyChanged(nameof(KaourKeyword1));
				OnPropertyChanged(nameof(KaourKeyword2));
				OnPropertyChanged(nameof(KaourKeyword3));
				if (_selectedSquire == Squire.Kaour)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
			if (_elsieSequenceBuffer > 0)
			{
				_selectedCharacter.ElsieSequence = (byte)((_selectedCharacter.ElsieSequence + _elsieSequenceBuffer) % 97);
				_elsieSequenceBuffer = 0;
				OnPropertyChanged(nameof(ElsieSequenceBuffer));
				OnPropertyChanged(nameof(ElsieKeyword1));
				OnPropertyChanged(nameof(ElsieKeyword2));
				OnPropertyChanged(nameof(ElsieKeyword3));
				if (_selectedSquire == Squire.Elsie)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
			if (_daiSequenceBuffer > 0)
			{
				_selectedCharacter.DaiSequence = (byte)((_selectedCharacter.DaiSequence + _daiSequenceBuffer) % 97);
				_daiSequenceBuffer = 0;
				OnPropertyChanged(nameof(DaiSequenceBuffer));
				OnPropertyChanged(nameof(DaiKeyword1));
				OnPropertyChanged(nameof(DaiKeyword2));
				OnPropertyChanged(nameof(DaiKeyword3));
				if (_selectedSquire == Squire.Dai)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
			if (_eirlysSequenceBuffer > 0)
			{
				_selectedCharacter.EirlysSequence = (byte)((_selectedCharacter.EirlysSequence + _eirlysSequenceBuffer) % 97);
				_eirlysSequenceBuffer = 0;
				OnPropertyChanged(nameof(EirlysSequenceBuffer));
				OnPropertyChanged(nameof(EirlysKeyword1));
				OnPropertyChanged(nameof(EirlysKeyword2));
				OnPropertyChanged(nameof(EirlysKeyword3));
				if (_selectedSquire == Squire.Eirlys)
					OnPropertyChanged(nameof(SelectedCharacterSquireSequence));
			}
		}

		public void SaveConfiguration(StreamWriter writer)
		{
			Flush();

			writer.Write(_listOfCharacters.IndexOf(_selectedCharacter));
			writer.Write(',');
			writer.Write(_alwaysOnTop ? "true" : "false");
			writer.Write(',');
			writer.Write(_confirmThree ? "true" : "false");
			writer.Write(',');
			writer.Write(_useBuffering ? "true" : "false");

			foreach (Character character in ListOfCharacters)
			{
				writer.WriteLine();
				writer.Write(character.Name);
				writer.Write(',');
				writer.Write(character.KaourSequence);
				writer.Write(',');
				writer.Write(character.KaourSpecialSequence);
				writer.Write(',');
				writer.Write(character.ElsieSequence);
				writer.Write(',');
				writer.Write(character.ElsieSpecialSequence);
				writer.Write(',');
				writer.Write(character.DaiSequence);
				writer.Write(',');
				writer.Write(character.DaiSpecialSequence);
				writer.Write(',');
				writer.Write(character.EirlysSequence);
				writer.Write(',');
				writer.Write(character.EirlysSpecialSequence);
			}

			writer.Flush();
		}

		public void LoadConfiguration(StreamReader reader)
		{
			string? line = reader.ReadLine();
			if (line != null)
			{
				string[] words = line.Split(',');
				int lastSelection = int.Parse(words[0]);
				_alwaysOnTop = bool.Parse(words[1]);
				_confirmThree = bool.Parse(words[2]);
				_useBuffering = bool.Parse(words[3]);

				line = reader.ReadLine();
				while (!string.IsNullOrEmpty(line))
				{
					words = line.Split(',');

					Character character = new(words[0])
					{
						KaourSequence = byte.Parse(words[1]),
						KaourSpecialSequence = byte.Parse(words[2]),
						ElsieSequence = byte.Parse(words[3]),
						ElsieSpecialSequence = byte.Parse(words[4]),
						DaiSequence = byte.Parse(words[5]),
						DaiSpecialSequence = byte.Parse(words[6]),
						EirlysSequence = byte.Parse(words[7]),
						EirlysSpecialSequence = byte.Parse(words[8])
					};
					_listOfCharacters.Add(character);

					line = reader.ReadLine();
				}

				if (_listOfCharacters.Count > 0)
					_selectedCharacter = _listOfCharacters[lastSelection];
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
