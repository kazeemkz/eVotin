using eVoting.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace eVoting.Controllers
{
    [Authorize]
    public class ParticipantController : Controller
    {
        //
        // GET: /Participant/
        UnitOfWork work = new UnitOfWork();

        public ActionResult Index(string FirstName, string LastName, string MiddleName, int? page, string Post)
        {
            var candidate = from c in work.ParticipantRepository.Get() select c;

            if (!(string.IsNullOrEmpty(FirstName)))
            {
                candidate = candidate.Where(a => a.FirstName.ToLower().Contains(FirstName.ToLower()));
            }

            if (!(string.IsNullOrEmpty(LastName)))
            {
                candidate = candidate.Where(a => a.LastName.ToLower().Contains(LastName.ToLower()));
            }

            if (!(string.IsNullOrEmpty(MiddleName)))
            {
                candidate = candidate.Where(a => a.MiddleName.ToLower().Contains(MiddleName.ToLower()));
            }

            if (!(string.IsNullOrEmpty(Post)))
            {
                int thePostID = Convert.ToInt32(Post);
                candidate = candidate.Where(a => a.PostID == thePostID);
            }

            List<Post> thePost = work.PostRepository.Get().ToList();
            List<SelectListItem> theItem = new List<SelectListItem>();

            theItem.Add(new SelectListItem() { Text = "...Choose", Value = "" });
            foreach (var post in thePost)
            {
                theItem.Add(new SelectListItem() { Text = post.PostName, Value = Convert.ToString(post.PostID) });
            }

            ViewBag.Item = theItem;

            int pageSize = 100;
            int pageNumber = (page ?? 1);
            ViewBag.Count = candidate.Count();



            return View(candidate.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Participant/Details/5

        public ActionResult Details(int id)
        {
            Participant theParticipant = work.ParticipantRepository.GetByID(id);

            Post thePost = work.PostRepository.GetByID(theParticipant.PostID);
            ViewBag.PostName = thePost.PostName;

            return View(theParticipant);
        }

        //
        // GET: /Participant/Create

        public ActionResult Create()
        {
            List<Post> thePosts = work.PostRepository.Get().ToList();
            List<SelectListItem> theItems = new List<SelectListItem>();

            foreach (var item in thePosts)
            {
                theItems.Add(new SelectListItem() { Text = item.PostName, Value = Convert.ToString(item.PostID) });

            }
            ViewBag.Item = theItems;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public FileContentResult GetImage(int id)
        {
            //PrimarySchoolStudent theStudent = work.PrimarySchoolStudentRepository.GetByID(id);
            //   Book theBook = work.BookRepository.GetByID(id);
            Photo thePhoto = work.PhotoRepository.Get(a => a.ParticipantID == id).First();
            // Photo myPhoto = thePhoto[0];


            return File(thePhoto.FileData, "image/png");

        }

        //
        // POST: /Participant/Create

        [HttpPost]
        public ActionResult Create(Participant model)
        {
            try
            {
                // int thePostID = model.Post.PostID;
                // model.PostID = thePostID;
                if (ModelState.IsValid)
                {
                    work.ParticipantRepository.Insert(model);
                    work.Save();
                }
                // TODO: Add insert logic here


                return RedirectToAction("Create", "Photo", new { id = model.ParticipantID });
                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Participant/Edit/5

        public ActionResult Edit(int id)
        {
            Participant theParticipant = work.ParticipantRepository.GetByID(id);
            List<Post> thePosts = work.PostRepository.Get().ToList();
            List<SelectListItem> theItems = new List<SelectListItem>();

            foreach (var item in thePosts)
            {
                theItems.Add(new SelectListItem() { Text = item.PostName, Value = Convert.ToString(item.PostID) });

            }
            ViewBag.Item = theItems;
            return View(theParticipant);
        }

        //
        // POST: /Participant/Edit/5

        [HttpPost]
        public ActionResult Edit(Participant model)
        {
            try
            {
                // TODO: Add update logic here
                // int thePostID = model.Post.PostID;
                // model.PostID = thePostID;
                if (ModelState.IsValid)
                {
                    work.ParticipantRepository.Update(model);
                    work.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Participant/Delete/5

        public ActionResult Delete(int id)
        {
            Participant theParticipant = work.ParticipantRepository.GetByID(id);
            return View(theParticipant);
        }

        //
        // POST: /Participant/Delete/5

        [HttpPost]
        public ActionResult Delete(Participant model)
        {
            try
            {
                Participant theParticipant = work.ParticipantRepository.GetByID(model.ParticipantID);

                work.ParticipantRepository.Delete(theParticipant);
                work.Save();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
