using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace MSMT
{
	public class UserConfiguration : INotifyPropertyChanged
	{
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
						OnPropertyChanged("KaourSequenceBuffer");
					}
					if (_elsieSequenceBuffer > 0)
					{
						_selectedCharacter.ElsieSequence = (byte)((_selectedCharacter.ElsieSequence + _elsieSequenceBuffer) % 97);
						_elsieSequenceBuffer = 0;
						OnPropertyChanged("ElsieSequenceBuffer");
					}
					if (_daiSequenceBuffer > 0)
					{
						_selectedCharacter.DaiSequence = (byte)((_selectedCharacter.DaiSequence + _daiSequenceBuffer) % 97);
						_daiSequenceBuffer = 0;
						OnPropertyChanged("DaiSequenceBuffer");
					}
					if (_eirlysSequenceBuffer > 0)
					{
						_selectedCharacter.EirlysSequence = (byte)((_selectedCharacter.EirlysSequence + _eirlysSequenceBuffer) % 97);
						_eirlysSequenceBuffer = 0;
						OnPropertyChanged("EirlysSequenceBuffer");
					}
					_selectedCharacter = value;
					OnPropertyChanged("KaourKeyword1");
					OnPropertyChanged("KaourKeyword2");
					OnPropertyChanged("KaourKeyword3");
					OnPropertyChanged("KaourSpecialKeyword");
					OnPropertyChanged("ElsieKeyword1");
					OnPropertyChanged("ElsieKeyword2");
					OnPropertyChanged("ElsieKeyword3");
					OnPropertyChanged("ElsieSpecialKeyword");
					OnPropertyChanged("DaiKeyword1");
					OnPropertyChanged("DaiKeyword2");
					OnPropertyChanged("DaiKeyword3");
					OnPropertyChanged("DaiSpecialKeyword");
					OnPropertyChanged("EirlysKeyword1");
					OnPropertyChanged("EirlysKeyword2");
					OnPropertyChanged("EirlysKeyword3");
					OnPropertyChanged("EirlysSpecialKeyword");
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
				OnPropertyChanged("KaourKeyword1");
				OnPropertyChanged("KaourKeyword2");
				OnPropertyChanged("KaourKeyword3");

				if (_selectedSquire == Squire.Kaour)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
					OnPropertyChanged("KaourSequence");
					OnPropertyChanged("KaourKeyword1");
					OnPropertyChanged("KaourKeyword2");
					OnPropertyChanged("KaourKeyword3");
				}

				if (_selectedSquire == Squire.Kaour)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
				OnPropertyChanged("KaourSpecialKeyword");
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
				OnPropertyChanged("ElsieKeyword1");
				OnPropertyChanged("ElsieKeyword2");
				OnPropertyChanged("ElsieKeyword3");

				if (_selectedSquire == Squire.Elsie)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
					OnPropertyChanged("ElsieSequence");
					OnPropertyChanged("ElsieKeyword1");
					OnPropertyChanged("ElsieKeyword2");
					OnPropertyChanged("ElsieKeyword3");
				}

				if (_selectedSquire == Squire.Elsie)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
				OnPropertyChanged("ElsieSpecialKeyword");
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
				OnPropertyChanged("DaiKeyword1");
				OnPropertyChanged("DaiKeyword2");
				OnPropertyChanged("DaiKeyword3");

				if (_selectedSquire == Squire.Dai)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
					OnPropertyChanged("DaiSequence");
					OnPropertyChanged("DaiKeyword1");
					OnPropertyChanged("DaiKeyword2");
					OnPropertyChanged("DaiKeyword3");
				}

				if (_selectedSquire == Squire.Dai)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
				OnPropertyChanged("DaiSpecialKeyword");
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
				OnPropertyChanged("EirlysKeyword1");
				OnPropertyChanged("EirlysKeyword2");
				OnPropertyChanged("EirlysKeyword3");

				if (_selectedSquire == Squire.Eirlys)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
					OnPropertyChanged("EirlysSequence");
					OnPropertyChanged("EirlysKeyword1");
					OnPropertyChanged("EirlysKeyword2");
					OnPropertyChanged("EirlysKeyword3");
				}

				if (_selectedSquire == Squire.Eirlys)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
				OnPropertyChanged("EirlysSpecialKeyword");
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
				OnPropertyChanged("SelectedSquireKeywords");
				OnPropertyChanged("SelectedCharacterSquireSequence");
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
				switch (_selectedSquire)
				{
					case Squire.Kaour: default:
						return (byte)(_selectedCharacter.KaourSequence + _kaourSequenceBuffer + 1);
					case Squire.Elsie:
						return (byte)(_selectedCharacter.ElsieSequence + _elsieSequenceBuffer + 1);
					case Squire.Dai:
						return (byte)(_selectedCharacter.DaiSequence + _daiSequenceBuffer + 1);
					case Squire.Eirlys:
						return (byte)(_selectedCharacter.EirlysSequence + _eirlysSequenceBuffer + 1);
				}
			}
			set
			{
				Flush();
				switch (_selectedSquire)
				{
					case Squire.Kaour: default:
						_selectedCharacter.KaourSequence = (byte)(value - 1);
						OnPropertyChanged("KaourSequence");
						OnPropertyChanged("KaourKeyword1");
						OnPropertyChanged("KaourKeyword2");
						OnPropertyChanged("KaourKeyword3");
						break;
					case Squire.Elsie:
						_selectedCharacter.ElsieSequence = (byte)(value - 1);
						OnPropertyChanged("ElsieSequence");
						OnPropertyChanged("ElsieKeyword1");
						OnPropertyChanged("ElsieKeyword2");
						OnPropertyChanged("ElsieKeyword3");
						break;
					case Squire.Dai:
						_selectedCharacter.DaiSequence = (byte)(value - 1);
						OnPropertyChanged("DaiSequence");
						OnPropertyChanged("DaiKeyword1");
						OnPropertyChanged("DaiKeyword2");
						OnPropertyChanged("DaiKeyword3");
						break;
					case Squire.Eirlys:
						_selectedCharacter.EirlysSequence = (byte)(value - 1);
						OnPropertyChanged("EirlysSequence");
						OnPropertyChanged("EirlysKeyword1");
						OnPropertyChanged("EirlysKeyword2");
						OnPropertyChanged("EirlysKeyword3");
						break;
				}
				OnPropertyChanged();
			}
		}

		private List<Character> _listOfCharacters;
		private Character _selectedCharacter;
		private bool _alwaysOnTop;
		private bool _confirmThree;
		private bool _useBuffering;
		private byte _kaourSequenceBuffer;
		private byte _elsieSequenceBuffer;
		private byte _daiSequenceBuffer;
		private byte _eirlysSequenceBuffer;
		private Squire _selectedSquire;

		public UserConfiguration()
		{
			_listOfCharacters = new List<Character>();
			_selectedCharacter = new Character("");
			_alwaysOnTop = true;
			_confirmThree = true;
			_useBuffering = true;
			_kaourSequenceBuffer = 0;
			_elsieSequenceBuffer = 0;
			_daiSequenceBuffer = 0;
			_eirlysSequenceBuffer = 0;
			_selectedSquire = Squire.Kaour;
		}

		public void NewCharacter(string name)
		{
			if (name == null)
				throw new ArgumentNullException();
			if (String.IsNullOrWhiteSpace(name))
				throw new ArgumentException();

			if (!_listOfCharacters.Exists((x) => x.Name == name))
			{
				Flush();
				_selectedCharacter = new Character(name);
				_listOfCharacters.Add(_selectedCharacter);
				OnPropertyChanged("SelectedCharacter");
				OnPropertyChanged("ListOfCharacters");
				OnPropertyChanged("KaourKeyword1");
				OnPropertyChanged("KaourKeyword2");
				OnPropertyChanged("KaourKeyword3");
				OnPropertyChanged("KaourSpecialKeyword");
				OnPropertyChanged("ElsieKeyword1");
				OnPropertyChanged("ElsieKeyword2");
				OnPropertyChanged("ElsieKeyword3");
				OnPropertyChanged("ElsieSpecialKeyword");
				OnPropertyChanged("DaiKeyword1");
				OnPropertyChanged("DaiKeyword2");
				OnPropertyChanged("DaiKeyword3");
				OnPropertyChanged("DaiSpecialKeyword");
				OnPropertyChanged("EirlysKeyword1");
				OnPropertyChanged("EirlysKeyword2");
				OnPropertyChanged("EirlysKeyword3");
				OnPropertyChanged("EirlysSpecialKeyword");
				OnPropertyChanged("SelectedCharacterSquireSequence");
			}
		}

		public void NewCopyCharacter(string name)
		{
			if (name == null)
				throw new ArgumentNullException();
			if (String.IsNullOrWhiteSpace(name))
				throw new ArgumentException();

			if (!_listOfCharacters.Exists((x) => x.Name == name))
			{
				Flush();
				_selectedCharacter = new Character(name, _selectedCharacter);
				_listOfCharacters.Add(_selectedCharacter);
				OnPropertyChanged("SelectedCharacter");
				OnPropertyChanged("ListOfCharacters");
				OnPropertyChanged("SelectedCharacterSquireSequence");
			}
		}

		public void RemoveCharacter()
		{
			if (_listOfCharacters.Count > 1)
			{
				_listOfCharacters.Remove(_selectedCharacter);
				_selectedCharacter = _listOfCharacters[0];
				OnPropertyChanged("SelectedCharacter");
				OnPropertyChanged("ListOfCharacters");
				OnPropertyChanged("SelectedCharacterSquireSequence");
			}
		}

		public void Flush()
		{
			if (_kaourSequenceBuffer > 0)
			{
				_selectedCharacter.KaourSequence = (byte)((_selectedCharacter.KaourSequence + _kaourSequenceBuffer) % 97);
				_kaourSequenceBuffer = 0;
				OnPropertyChanged("KaourSequenceBuffer");
				OnPropertyChanged("KaourKeyword1");
				OnPropertyChanged("KaourKeyword2");
				OnPropertyChanged("KaourKeyword3");
				if (_selectedSquire == Squire.Kaour)
					OnPropertyChanged("SelectedCharacterSquireSequence");
			}
			if (_elsieSequenceBuffer > 0)
			{
				_selectedCharacter.ElsieSequence = (byte)((_selectedCharacter.ElsieSequence + _elsieSequenceBuffer) % 97);
				_elsieSequenceBuffer = 0;
				OnPropertyChanged("ElsieSequenceBuffer");
				OnPropertyChanged("ElsieKeyword1");
				OnPropertyChanged("ElsieKeyword2");
				OnPropertyChanged("ElsieKeyword3");
				if (_selectedSquire == Squire.Elsie)
					OnPropertyChanged("SelectedCharacterSquireSequence");
			}
			if (_daiSequenceBuffer > 0)
			{
				_selectedCharacter.DaiSequence = (byte)((_selectedCharacter.DaiSequence + _daiSequenceBuffer) % 97);
				_daiSequenceBuffer = 0;
				OnPropertyChanged("DaiSequenceBuffer");
				OnPropertyChanged("DaiKeyword1");
				OnPropertyChanged("DaiKeyword2");
				OnPropertyChanged("DaiKeyword3");
				if (_selectedSquire == Squire.Dai)
					OnPropertyChanged("SelectedCharacterSquireSequence");
			}
			if (_eirlysSequenceBuffer > 0)
			{
				_selectedCharacter.EirlysSequence = (byte)((_selectedCharacter.EirlysSequence + _eirlysSequenceBuffer) % 97);
				_eirlysSequenceBuffer = 0;
				OnPropertyChanged("EirlysSequenceBuffer");
				OnPropertyChanged("EirlysKeyword1");
				OnPropertyChanged("EirlysKeyword2");
				OnPropertyChanged("EirlysKeyword3");
				if (_selectedSquire == Squire.Eirlys)
					OnPropertyChanged("SelectedCharacterSquireSequence");
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
			string line = reader.ReadLine();
			string[] words = line.Split(',');
			int lastSelection = Int32.Parse(words[0]);
			_alwaysOnTop = Boolean.Parse(words[1]);
			_confirmThree = Boolean.Parse(words[2]);
			_useBuffering = Boolean.Parse(words[3]);

			line = reader.ReadLine();
			while (!String.IsNullOrEmpty(line))
			{
				words = line.Split(',');

				Character character = new Character(words[0])
				{
					KaourSequence = Byte.Parse(words[1]),
					KaourSpecialSequence = Byte.Parse(words[2]),
					ElsieSequence = Byte.Parse(words[3]),
					ElsieSpecialSequence = Byte.Parse(words[4]),
					DaiSequence = Byte.Parse(words[5]),
					DaiSpecialSequence = Byte.Parse(words[6]),
					EirlysSequence = Byte.Parse(words[7]),
					EirlysSpecialSequence = Byte.Parse(words[8])
				};
				_listOfCharacters.Add(character);

				line = reader.ReadLine();
			}

			if (_listOfCharacters.Count > 0)
				_selectedCharacter = _listOfCharacters[lastSelection];
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
