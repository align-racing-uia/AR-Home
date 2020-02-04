using System;

namespace web_api.Models.Project
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public float Complele { get; set; }
    }
}