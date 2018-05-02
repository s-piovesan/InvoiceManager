using System;
using System.Collections.Generic;
using System.Linq;
using FacturationWebSite.Models;

namespace InvoiceManager.WebSite.Data
{
	public static class DbInitializer
	{
		public static void Initialize(MvcAppContext context)
		{
			context.Database.EnsureCreated();

			// Look for any students.
			if (context.Deliveries.Any())
			{
				return;   // DB has been seeded
			}

			var deliveries = new List<Delivery>();

			
			var tuesdays = GetDatesByDayOfWeek(2018, DayOfWeek.Tuesday);
			var thursdays = GetDatesByDayOfWeek(2018, DayOfWeek.Thursday);

			foreach (var day in tuesdays) {
				deliveries.Add(new Delivery { Date = day, Status = FacturationWebSite.Models.Enum.DeliveryStatus.Pending });
			}

			foreach (var day in thursdays)
			{
				deliveries.Add(new Delivery { Date = day, Status = FacturationWebSite.Models.Enum.DeliveryStatus.Pending });
			}
		

			foreach (Delivery d in deliveries)
			{
				context.Deliveries.Add(d);
			}
			context.SaveChanges();

		}
		private static List<DateTime> GetDatesByDayOfWeek(int selectedYear, DayOfWeek dayOfWeek)
		{
			string firstDayOfTheYear = String.Format("January 1, {0}", selectedYear);
			string lastDayOfTheYear = String.Format("December 31, {0}", selectedYear);

			DateTime firstDateTime = DateTime.Parse(firstDayOfTheYear);
			DateTime lastDateTime = DateTime.Parse(lastDayOfTheYear);

			Int32 dayCount = lastDateTime.DayOfYear - 1;

			List<DateTime> selectedDates = new List<DateTime>();

			for (Int32 ctr = 0; ctr <= dayCount; ctr++)
			{
				DateTime processedDate = firstDateTime.AddDays(ctr);
				if (processedDate.DayOfWeek == dayOfWeek)
				{
					selectedDates.Add(processedDate);
				}
			}

			return selectedDates;
		}
	}
}


