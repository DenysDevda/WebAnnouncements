using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebsite.Models
{
    public class EditAnnouncementDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
