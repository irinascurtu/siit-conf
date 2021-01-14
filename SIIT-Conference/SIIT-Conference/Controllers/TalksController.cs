using AutoMapper;
using Conference.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Controllers
{
    //  [Area("Admin")]
    public class TalksController : Controller
    {
        private readonly ConfContext context;
        private readonly IMapper mapper;

        public TalksController(ConfContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        // GET: TalksController
        public ActionResult Index()
        {
            var ss = context.Talks.Include(x => x.Speakers).ToList();
            return View();
        }

        // GET: TalksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TalksController/Create
        public ActionResult Create()
        {
            TalkDto model = new TalkDto();
            return View(model);
        }

        // POST: TalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TalkDto model)
        {
            if (ModelState.IsValid)
            {
                //create a new Speaker
                Talk newTalk = new Talk();
                //newTalk = mapper.Map<Talk>(model);
                //service.Add(newTalk);
                ////save speaker
                //service.Save();
                //redirect to List
                return RedirectToAction("List", "Speakers");
            }

            return View(model);
        }

        // GET: TalksController/Edit/5
        public ActionResult Edit(int id)
        {
            var talk = context.Talks.Find(id);
            TalkDto model = new TalkDto();
            model = mapper.Map<TalkDto>(talk);
            return View(model);
        }

        // POST: TalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TalksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TalksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult FillData()
        {
            var model = new TalkDto();
            return new JsonResult(model);
        }

        [HttpGet]
        public IActionResult GetSpeakerData(int id)
        {
            var speaker = context.Speakers.Find(id);

            var model = new List<SelectModel>();
            for (int i = id; i < id + 10; i++)
            {
                var currentModel = new SelectModel();
                currentModel.Id = i;
                currentModel.TextToDisplay = speaker.FullName + i;
                model.Add(currentModel);
            }

            return new JsonResult(model);
        }
    }
}
