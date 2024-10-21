using System.Collections.ObjectModel;

namespace MabinogiSMT
{
	public class Character
	{
		public static readonly ReadOnlyCollection<Keyword>[] SquireSequenceTable = [
			// Kaour
			new ReadOnlyCollection<Keyword>([
				Keyword.Playing, Keyword.Playing, Keyword.Training, Keyword.Cooking, Keyword.Playing, Keyword.Dating,
				Keyword.Training, Keyword.Cooking, Keyword.Dating, Keyword.Cooking, Keyword.Missions, Keyword.Missions,
				Keyword.Fashion, Keyword.Dating, Keyword.Cooking, Keyword.Fashion, Keyword.Dating, Keyword.Missions,
				Keyword.Missions, Keyword.Missions, Keyword.Fashion, Keyword.Dating, Keyword.Missions, Keyword.Fashion,
				Keyword.Playing, Keyword.Missions, Keyword.Fashion, Keyword.Training, Keyword.Dating, Keyword.Missions,
				Keyword.Missions, Keyword.Playing, Keyword.Dating, Keyword.Missions, Keyword.Fashion, Keyword.Missions,
				Keyword.Training, Keyword.Training, Keyword.Training, Keyword.Playing, Keyword.Training, Keyword.Dating,
				Keyword.Fashion, Keyword.Cooking, Keyword.Training, Keyword.Playing, Keyword.Fashion, Keyword.Dating,
				Keyword.Playing, Keyword.Dating, Keyword.Cooking, Keyword.Missions, Keyword.Playing, Keyword.Fashion,
				Keyword.Cooking, Keyword.Cooking, Keyword.Cooking, Keyword.Fashion, Keyword.Fashion, Keyword.Playing,
				Keyword.Playing, Keyword.Training, Keyword.Fashion, Keyword.Training, Keyword.Missions, Keyword.Training,
				Keyword.Cooking, Keyword.Dating, Keyword.Fashion, Keyword.Training, Keyword.Playing, Keyword.Fashion,
				Keyword.Dating, Keyword.Training, Keyword.Missions, Keyword.Missions, Keyword.Cooking, Keyword.Missions,
				Keyword.Missions, Keyword.Fashion, Keyword.Cooking, Keyword.Cooking, Keyword.Training, Keyword.Fashion,
				Keyword.Cooking, Keyword.Dating, Keyword.Missions, Keyword.Fashion, Keyword.Dating, Keyword.Cooking,
				Keyword.Dating, Keyword.Fashion, Keyword.Dating, Keyword.Training, Keyword.Missions, Keyword.Cooking,
				Keyword.Training, Keyword.Dating, Keyword.Fashion,
			]),
			// Elsie
			new ReadOnlyCollection<Keyword>([
				Keyword.Cooking, Keyword.Playing, Keyword.Fashion, Keyword.Dating, Keyword.Fashion, Keyword.Playing,
				Keyword.Dating, Keyword.Dating, Keyword.Playing, Keyword.Missions, Keyword.Training, Keyword.Playing,
				Keyword.Dating, Keyword.Playing, Keyword.Training, Keyword.Playing, Keyword.Missions, Keyword.Cooking,
				Keyword.Playing, Keyword.Playing, Keyword.Playing, Keyword.Dating, Keyword.Playing, Keyword.Cooking,
				Keyword.Playing, Keyword.Dating, Keyword.Missions, Keyword.Fashion, Keyword.Playing, Keyword.Playing,
				Keyword.Playing, Keyword.Dating, Keyword.Cooking, Keyword.Dating, Keyword.Training, Keyword.Dating,
				Keyword.Playing, Keyword.Cooking, Keyword.Missions, Keyword.Training, Keyword.Playing, Keyword.Playing,
				Keyword.Missions, Keyword.Dating, Keyword.Cooking, Keyword.Dating, Keyword.Cooking, Keyword.Playing,
				Keyword.Playing, Keyword.Dating, Keyword.Playing, Keyword.Training, Keyword.Dating, Keyword.Playing,
				Keyword.Missions, Keyword.Playing, Keyword.Playing, Keyword.Playing, Keyword.Fashion, Keyword.Dating,
				Keyword.Playing, Keyword.Playing, Keyword.Missions, Keyword.Training, Keyword.Dating, Keyword.Dating,
				Keyword.Playing, Keyword.Playing, Keyword.Playing, Keyword.Fashion, Keyword.Playing, Keyword.Training,
				Keyword.Cooking, Keyword.Playing, Keyword.Fashion, Keyword.Playing, Keyword.Fashion, Keyword.Dating,
				Keyword.Missions, Keyword.Playing, Keyword.Playing, Keyword.Dating, Keyword.Training, Keyword.Playing,
				Keyword.Playing, Keyword.Fashion, Keyword.Dating, Keyword.Missions, Keyword.Missions, Keyword.Fashion,
				Keyword.Fashion, Keyword.Fashion, Keyword.Fashion, Keyword.Dating, Keyword.Playing, Keyword.Playing,
				Keyword.Missions, Keyword.Cooking, Keyword.Missions,
			]),
			// Dai
			new ReadOnlyCollection<Keyword>([
				Keyword.Playing, Keyword.Dating, Keyword.Playing, Keyword.Fashion, Keyword.Training, Keyword.Playing,
				Keyword.Playing, Keyword.Playing, Keyword.Playing, Keyword.Cooking, Keyword.Playing, Keyword.Training,
				Keyword.Playing, Keyword.Dating, Keyword.Missions, Keyword.Dating, Keyword.Fashion, Keyword.Playing,
				Keyword.Playing, Keyword.Cooking, Keyword.Fashion, Keyword.Playing, Keyword.Playing, Keyword.Fashion,
				Keyword.Fashion, Keyword.Cooking, Keyword.Fashion, Keyword.Playing, Keyword.Cooking, Keyword.Missions,
				Keyword.Dating, Keyword.Playing, Keyword.Cooking, Keyword.Playing, Keyword.Fashion, Keyword.Fashion,
				Keyword.Cooking, Keyword.Playing, Keyword.Fashion, Keyword.Training, Keyword.Playing, Keyword.Fashion,
				Keyword.Playing, Keyword.Dating, Keyword.Missions, Keyword.Dating, Keyword.Playing, Keyword.Dating,
				Keyword.Playing, Keyword.Fashion, Keyword.Cooking, Keyword.Fashion, Keyword.Fashion, Keyword.Playing,
				Keyword.Fashion, Keyword.Training, Keyword.Training, Keyword.Playing, Keyword.Playing, Keyword.Playing,
				Keyword.Playing, Keyword.Playing, Keyword.Fashion, Keyword.Training, Keyword.Cooking, Keyword.Fashion,
				Keyword.Playing, Keyword.Fashion, Keyword.Playing, Keyword.Fashion, Keyword.Playing, Keyword.Training,
				Keyword.Playing, Keyword.Missions, Keyword.Cooking, Keyword.Playing, Keyword.Training, Keyword.Playing,
				Keyword.Fashion, Keyword.Playing, Keyword.Missions, Keyword.Dating, Keyword.Training, Keyword.Dating,
				Keyword.Fashion, Keyword.Missions, Keyword.Fashion, Keyword.Dating, Keyword.Fashion, Keyword.Missions,
				Keyword.Fashion, Keyword.Cooking, Keyword.Playing, Keyword.Fashion, Keyword.Cooking, Keyword.Dating,
				Keyword.Fashion, Keyword.Dating, Keyword.Fashion,
			]),
			// Eirlys
			new ReadOnlyCollection<Keyword>([
				Keyword.Missions, Keyword.Playing, Keyword.Cooking, Keyword.Playing, Keyword.Missions, Keyword.Training,
				Keyword.Missions, Keyword.Missions, Keyword.Training, Keyword.Missions, Keyword.Training, Keyword.Fashion,
				Keyword.Training, Keyword.Training, Keyword.Cooking, Keyword.Dating, Keyword.Training, Keyword.Fashion,
				Keyword.Missions, Keyword.Training, Keyword.Dating, Keyword.Fashion, Keyword.Dating, Keyword.Dating,
				Keyword.Cooking, Keyword.Training, Keyword.Cooking, Keyword.Playing, Keyword.Fashion, Keyword.Fashion,
				Keyword.Missions, Keyword.Missions, Keyword.Missions, Keyword.Training, Keyword.Training, Keyword.Training,
				Keyword.Missions, Keyword.Cooking, Keyword.Missions, Keyword.Missions, Keyword.Cooking, Keyword.Playing,
				Keyword.Playing, Keyword.Training, Keyword.Cooking, Keyword.Playing, Keyword.Cooking, Keyword.Cooking,
				Keyword.Missions, Keyword.Cooking, Keyword.Training, Keyword.Missions, Keyword.Missions, Keyword.Training,
				Keyword.Training, Keyword.Dating, Keyword.Dating, Keyword.Missions, Keyword.Training, Keyword.Cooking,
				Keyword.Playing, Keyword.Fashion, Keyword.Training, Keyword.Training, Keyword.Cooking, Keyword.Missions,
				Keyword.Training, Keyword.Missions, Keyword.Missions, Keyword.Missions, Keyword.Playing, Keyword.Training,
				Keyword.Training, Keyword.Playing, Keyword.Training, Keyword.Missions, Keyword.Training, Keyword.Missions,
				Keyword.Training, Keyword.Fashion, Keyword.Missions, Keyword.Training, Keyword.Cooking, Keyword.Missions,
				Keyword.Fashion, Keyword.Playing, Keyword.Training, Keyword.Training, Keyword.Cooking, Keyword.Cooking,
				Keyword.Missions, Keyword.Training, Keyword.Cooking, Keyword.Missions, Keyword.Missions, Keyword.Dating,
				Keyword.Cooking, Keyword.Cooking, Keyword.Missions,
			]),
		];

		public static readonly ReadOnlyCollection<string>[] SquireSpecialSequenceTable = [
			// Kaour
			new ReadOnlyCollection<string>([
				"Lv.2 0.7% Training",
				"Lv.2 53.3% Playing",
				"Lv.2 90.0% Missions",
				"Lv.3 15.0% Training",
				"Lv.3 40.0% Training",
				"Lv.3 80.0% Missions",
				"Lv.4 10.0% Dating",
				"Lv.4 56.7% Training",
				"Lv.4 93.3% Playing",
				"",
			]),
			// Elsie
			new ReadOnlyCollection<string>([
				"Lv.2 0.7% Training",
				"Lv.2 46.7% Playing",
				"Lv.2 83.3% Cooking",
				"Lv.3 25.0% Dating",
				"Lv.3 50.0% Playing", // The spreadsheet incorrectly listed it as Training
				"Lv.3 80.0% Missions",
				"Lv.4 25.5% Training",
				"Lv.4 50.0% Playing",
				"Lv.4 85.0% Cooking",
				"",
			]),
			// Dai
			new ReadOnlyCollection<string>([
				"Lv.2 2.0% Playing",
				"Lv.2 33.3% Fashion",
				"Lv.2 80.0% Dating",
				"Lv.3 15.1% Playing",
				"Lv.3 50.0% Training",
				"Lv.3 80.0% Missions",
				"Lv.4 15.0% Training",
				"Lv.4 45.0% Fashion",
				"Lv.4 80.0% Dating",
				"",
			]),
			// Eirlys
			new ReadOnlyCollection<string>([
				"Lv.1 2.9% Training",
				"Lv.1 28.6% Dating",
				"Lv.1 71.4% Training",
				"Lv.2 6.7% Fashion",
				"Lv.2 33.3% Training",
				"Lv.2 80.0% Missions",
				"Lv.3 20.0% Cooking",
				"Lv.3 40.0% Cooking",
				"Lv.3 80.0% Playing",
				"Lv.4 10.0% Dating",
				"Lv.4 40.0% Cooking",
				"Lv.4 80.0% Training",
				"",
			]),
		];

		public string Name { get; set; }
		public byte KaourSequence { get; set; }
		public byte KaourSpecialSequence { get; set; }
		public byte ElsieSequence { get; set; }
		public byte ElsieSpecialSequence { get; set; }
		public byte DaiSequence { get; set; }
		public byte DaiSpecialSequence { get; set; }
		public byte EirlysSequence { get; set; }
		public byte EirlysSpecialSequence { get; set; }

		public Character(string name)
		{
			Name = name;
			KaourSequence = 0;
			KaourSpecialSequence = 0;
			ElsieSequence = 0;
			ElsieSpecialSequence = 0;
			DaiSequence = 0;
			DaiSpecialSequence = 0;
			EirlysSequence = 0;
			EirlysSpecialSequence = 0;
		}
		public Character(string name, Character copyFromCharacter)
		{
			Name = name;
			KaourSequence = copyFromCharacter.KaourSequence;
			KaourSpecialSequence = copyFromCharacter.KaourSpecialSequence;
			ElsieSequence = copyFromCharacter.ElsieSequence;
			ElsieSpecialSequence = copyFromCharacter.ElsieSpecialSequence;
			DaiSequence = copyFromCharacter.DaiSequence;
			DaiSpecialSequence = copyFromCharacter.DaiSpecialSequence;
			EirlysSequence = copyFromCharacter.EirlysSequence;
			EirlysSpecialSequence = copyFromCharacter.EirlysSpecialSequence;
		}
	}
}
