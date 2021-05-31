using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebsite.Models
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        
        public Announcement(string title, string description)
        {
            Title = title;
            Description = description;
            Date = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
