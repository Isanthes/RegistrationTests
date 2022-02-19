using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RegistrationTests.DataModels
{
    [XmlRoot(ElementName = "registrationData")]
    public class Registration
    {
		[XmlElement(ElementName = "user")]
		public string User { get; set; }

		[XmlElement(ElementName = "pass")]
		public string Pass { get; set; }

		[XmlElement(ElementName = "confirmPass")]
		public string ConfirmPass { get; set; }

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "firstName")]
		public string FirstName { get; set; }

		[XmlElement(ElementName = "lastName")]
		public string LastName { get; set; }

		[XmlElement(ElementName = "email")]
		public string Email { get; set; }

		[XmlElement(ElementName = "nationality")]
		public string Nationality { get; set; }
	}
}
