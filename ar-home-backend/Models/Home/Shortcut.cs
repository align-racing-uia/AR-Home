using System;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Models.Home
{
    public class Shortcut
    {
        public Shortcut()
        {
            Created = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}