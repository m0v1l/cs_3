using System;
using System.Collections.Generic;

namespace _3_2
{
	abstract class Tariff
	{
		public string Name { get; set; }

		public Tariff(string name)
		{
			Name = name;
		}

		public abstract decimal CalculateCost(int seconds);
	}

	class PerSecondTariff : Tariff
	{
		public decimal CostPerSecond { get; set; }

		public PerSecondTariff(string name, decimal costPerSecond) : base(name)
		{
			CostPerSecond = costPerSecond;
		}

		public override decimal CalculateCost(int seconds)
		{
			if (seconds <= 0) return 0m;
			return CostPerSecond * seconds;
		}
	}

	class PerMinuteTariff : Tariff
	{
		public decimal CostPerMinute { get; set; }

		public PerMinuteTariff(string name, decimal costPerMinute) : base(name)
		{
			CostPerMinute = costPerMinute;
		}

		public override decimal CalculateCost(int seconds)
		{
			if (seconds <= 0) return 0m;
			int minutes = (seconds + 59) / 60;
			return CostPerMinute * minutes;
		}
	}

	class Company
	{
		public string Name { get; set; }
		public List<Tariff> Tariffs { get; } = new List<Tariff>();

		public Company(string name)
		{
			Name = name;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var company = new Company("Мобильная компания");

			var perMinute = new PerMinuteTariff("Поминутный", 3.00m); // 3.00 за минуту
			var perSecond = new PerSecondTariff("Посекундный", 0.10m); // 0.10 за секунду

			company.Tariffs.Add(perMinute);
			company.Tariffs.Add(perSecond);

			int durationSeconds = 80;

			for (int i = 0; i < company.Tariffs.Count; i++)
			{
				var tariff = company.Tariffs[i];
				decimal cost = tariff.CalculateCost(durationSeconds);
				Console.WriteLine($"Тариф: {tariff.Name} | Длительность: {durationSeconds} сек. | Стоимость: {cost:C}");
			}
		}
	}
}

