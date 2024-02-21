using System.ComponentModel.DataAnnotations.Schema;

namespace Autoglass.Domain.Notifications;

public class Notify
{
	public Notify()
	{
		Notifications = new List<Notify>();
	}

	[NotMapped]
	public string PropertyName { get; set; }

	[NotMapped]
	public string Message { get; set; }

	[NotMapped]
	public List<Notify> Notifications { get; set; }

	public bool ValidateStringProperty(string value, string propertyName)
	{
		if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
		{
			Notifications.Add(new Notify
			{
				Message = "Required Field",
				PropertyName = propertyName
			});

			return false;
		}
		return true;
	}

	public bool ValidateDate(DateTime manufaturingDate, DateTime expiryDate, string propertyName)
	{
		if (manufaturingDate >= expiryDate)
		{
			Notifications.Add(new Notify
			{
				Message = "Manufaturing Date cannot be bigger than expiry date",
				PropertyName = propertyName
			});

			return false;
		}
		return true;
	}
}
