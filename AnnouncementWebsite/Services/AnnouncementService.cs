using AnnouncementWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebsite.Services
{
    public class AnnouncementService
    {
        private static AnnouncementService instance;
        public List<Announcement> Announcements { get; set; }

        public AnnouncementService()
        {
            Announcements = new List<Announcement>();
            Announcements.Add(new Announcement("WOW game", "All roads lead to Outland, heroes. Start playing the Burning Crusade Classic ™ pre-patch today and prepare your Draenei or Blood Elf hero for the upcoming battle. " +
                "And then on June 2, start developing it to level 70 by going through the Dark Portal and defending Azeroth."));
            Announcements.Add(new Announcement("FIFA game", "Meet the most trusted players of this season who have shown great football in the world's top leagues, with big rating boosts."));
            Announcements.Add(new Announcement("PES game", "Pro Evolution Soccer (abbreviated as PES and currently branded as eFootball PES), known in Japan as Winning Eleven[a] (currently branded as eFootball Winning Eleven[b]), is a series of association football simulation video games developed and released annually since 1995. It is developed and published by Konami. It consists of eighteen main instalments and several spin-off style titles and it has seen releases on many different platforms. It is itself a sister series of Konami's earlier International Superstar Soccer and has been released under different names before the name Pro Evolution Soccer was established worldwide. The series has consistently achieved critical and commercial success."));
        }

        public async Task AddNewAnnouncement(AnnouncementDTO announcement)
        {
            Announcements.Add(new Announcement(announcement.Title, announcement.Description));
        }

        public async Task RemoveAnnouncement(Guid id)
        {
            foreach (var announcement in Announcements)
            {
                if(announcement.Id == id)
                {
                    Announcements.Remove(announcement);
                    break;
                }
            }
        }

        public async Task EditAnnouncementTitle(EditAnnouncementDTO announcement)
        {
            foreach (var announcements in Announcements)
            {
                if (announcements.Id == announcement.Id)
                {
                    announcements.Title = announcement.Title;
                    announcements.Description = announcement.Description;
                }
            }
        }

        public static AnnouncementService GetInstance()
        {
            if(instance == null)
            {
                instance = new AnnouncementService();
            }

            return instance;
        }

        public List<Announcement> GetAnnouncements(Guid id)
        {
            List<Announcement> res = new List<Announcement>();

            foreach (var announcement in Announcements)
            {
                if (announcement.Id == id)
                {
                    res.Add(announcement);
                    res.AddRange(GetTop3(announcement));
                    break;
                }
            }

            return res;
        }

        private List<Announcement> GetTop3(Announcement announcement)
        {
            List<Announcement> res = new List<Announcement>();

            foreach (var item in Announcements)
            {
                if (announcement.Id != item.Id)
                {
                    var announcmentTitle = announcement.Title.Split(' ');
                    var announcmentDescription = announcement.Description.Split(' ');

                    var itemTitle = item.Title.Split(' ');
                    var itemDescription = item.Description.Split(' ');

                    foreach (var title in announcmentTitle)
                    {
                        if (itemTitle.Contains(title))
                        {
                            foreach (var desc in announcmentDescription)
                            {
                                if (itemDescription.Contains(desc) && !res.Contains(item))
                                {
                                    res.Add(item);
                                    if (res.Count == 3)
                                        return res;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return res;
        }
    }
}
