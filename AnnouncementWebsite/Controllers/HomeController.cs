using AnnouncementWebsite.Models;
using AnnouncementWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static AnnouncementService service;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            service = AnnouncementService.GetInstance();
        }

        public IActionResult Index()
        {
            return View(service.Announcements);
        }
        public IActionResult Details(Guid id)
        {
            var announcements = service.GetAnnouncements(id);
            return View(announcements);
        }

        [HttpPost]
        public async Task AddNewAnnouncement(AnnouncementDTO announcement)
        {
            await service.AddNewAnnouncement(announcement);
        }

        [HttpPost]
        public async Task RemoveAnnouncement(Guid announcementid)
        {
            await service.RemoveAnnouncement(announcementid);
        }

        [HttpPost]
        public async Task EditAnnouncementTitle(EditAnnouncementDTO item)
        {
            await service.EditAnnouncementTitle(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}