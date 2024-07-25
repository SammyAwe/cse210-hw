using System;

namespace EventPlanning
{
    public class Address
    {
        private string Street { get; }
        private string City { get; }
        private string State { get; }
        private string ZipCode { get; }

        public Address(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string GetFullAddress()
        {
            return $"{Street}, {City}, {State} {ZipCode}";
        }
    }

    public abstract class Event
    {
        private string Title { get; }
        private string Description { get; }
        private string Date { get; }
        private string Time { get; }
        private Address Address { get; }

        protected Event(string title, string description, string date, string time, Address address)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
            Address = address;
        }

        public string GetStandardDetails()
        {
            return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nAddress: {Address.GetFullAddress()}";
        }

        public string GetShortDescription()
        {
            return $"Event Type: {GetType().Name}\nTitle: {Title}\nDate: {Date}";
        }

        public abstract string GetFullDetails();
    }

    public class Lecture : Event
    {
        private string Speaker { get; }
        private int Capacity { get; }

        public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            Speaker = speaker;
            Capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
        }
    }

    public class Reception : Event
    {
        private string RsvpEmail { get; }

        public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            RsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {RsvpEmail}";
        }
    }

    public class OutdoorGathering : Event
    {
        private string WeatherForecast { get; }

        public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            WeatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Springfield", "IL", "62701");
            Address address2 = new Address("456 Elm St", "Springfield", "IL", "62701");
            Address address3 = new Address("789 Oak St", "Springfield", "IL", "62701");

            Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in tech.", "2024-08-01", "10:00 AM", address1, "John Doe", 100);
            Reception reception = new Reception("Networking Event", "Meet and greet with professionals.", "2024-08-02", "6:00 PM", address2, "rsvp@example.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic in the Park", "A fun outdoor picnic.", "2024-08-03", "12:00 PM", address3, "Sunny and 75°F");

            Event[] events = { lecture, reception, outdoorGathering };

            foreach (Event e in events)
            {
                Console.WriteLine(e.GetStandardDetails());
                Console.WriteLine();
                Console.WriteLine(e.GetFullDetails());
                Console.WriteLine();
                Console.WriteLine(e.GetShortDescription());
                Console.WriteLine(new string('=', 50));
                Console.WriteLine();
            }
        }
    }
}