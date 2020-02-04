using System;

namespace web_api.Models.Info
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}