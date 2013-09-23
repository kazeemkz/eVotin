﻿using eVoting.DAL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using PagedList;
using System.Data.SqlClient;
using eVoting.Filters;

namespace eVoting.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class VoterController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        //
        // GET: /Voter/

        public ActionResult Index(string FirstName, string LastName, string ID, int? page, string Voted)
        {
            List<SelectListItem> theItem = new List<SelectListItem>();
            theItem.Add(new SelectListItem() { Text = "...Choose", Value = "" });

            theItem.Add(new SelectListItem() { Text = "False", Value = "False" });
            theItem.Add(new SelectListItem() { Text = "True", Value = "True" });
            //foreach (var post in thePost)
            //{
                //theItem.Add(new SelectListItem() { Text = post.PostName, Value = Convert.ToString(post.PostID) });
         //   }

            ViewBag.Item = theItem;

            var voters = from v in work.VoterRepository.Get() select v;

            if (!(string.IsNullOrEmpty(FirstName)))
            {
                voters = voters.Where(a => a.FirstName.ToLower().Contains(FirstName.ToLower()));
            }

            if (!(string.IsNullOrEmpty(LastName)))
            {
                voters = voters.Where(a => a.LastName.ToLower().Contains(LastName.ToLower()));
            }

            if (!(string.IsNullOrEmpty(ID)))
            {
                voters = voters.Where(a => a.IdentityNumber == ID);
            }

            if (!(string.IsNullOrEmpty(Voted)))
            {
                bool theVote = Convert.ToBoolean(Voted);
                voters = voters.Where(a => a.Voted == theVote);
            }

            voters = voters.Where(a => a.LastName != "Oyebode1234567");


            int pageSize = 100;
            int pageNumber = (page ?? 1);
            ViewBag.Count = voters.Count();



            return View(voters.ToPagedList(pageNumber, pageSize));
            //List<Voter> theVoterList = new List<Voter>();
            //theVoterList = work.VoterRepository.Get().ToList();
            //return View(theVoterList);
        }

        public void Populate()
        {
            var chars = "1eyryidjmncb4a9w8x5r93hb3mqa4j3n3nwm31kvj6c2j9kcm1n3n4bs6a8e91jcvk3n5m7rka9a5x7z8mn3k3n4nman3kwn7k8k3n2a93mabfbsk347sbal3hdkcks128jk";
            var random = new Random();
            // string result = new string(Enumerable.Repeat(chars,6).Select(s=>s[random.Next(s.Length)]).ToArray());


            FileStream fs = new FileStream("C:\\Users\\kazeem\\Desktop\\School Projects\\doctorsreal.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            // Math.
            //  string theLast = null;
            // string theMatric = null;
            while (!(sr.EndOfStream))
            {
                string randomPassword = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                string theMatric = sr.ReadLine().Trim();
                string[] theBrokenData = theMatric.Split('\t');

               // theBrokenData[6];

                Voter theVoter = new Voter();
                //theVoter.IdentityNumber = theMatric;
                theVoter.IdentityNumber = theBrokenData[4].TrimEnd().TrimStart();
             theVoter.Department =   theBrokenData[1].TrimEnd().TrimStart();
                theVoter.Password = randomPassword;
                theVoter.VotedTime = DateTime.Now;
                theVoter.FirstName = theBrokenData[3].TrimEnd().TrimStart(); ;
               // theVoter.LastName = theBrokenData[5].TrimEnd().TrimStart(); ;
                theVoter.Voted = false;
                work.VoterRepository.Insert(theVoter);
                work.Save();

                WebSecurity.CreateUserAndAccount(theVoter.IdentityNumber, randomPassword);
                //  theLast  =theMatric;
            }
            sr.Close();
            fs.Close();
            //  theLast = theMatric;
            // List<Post> theposts = work.PostRepository.Get().ToList();
            // return View("Result", theposts);
        }

        //
        // GET: /Voter/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Voter/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Voter/Create

        [HttpPost]
        public ActionResult Create(Voter model)
        {
            model.VotedTime = DateTime.Now;
            model.Voted = false;
            try
            {
                if (!(ModelState.IsValid))
                {
                    View(model);
                }
                work.VoterRepository.Insert(model);
                work.Save();

                WebSecurity.CreateUserAndAccount(model.IdentityNumber, model.Password);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Voter/Edit/5

        public ActionResult Edit(int id)
        {

            Voter theVoter = work.VoterRepository.GetByID(id);
            return View(theVoter);
        }

        //
        // POST: /Voter/Edit/5

        [HttpPost]
        public ActionResult Edit(Voter theVoter)
        {
            try
            {
                if (TryUpdateModel(theVoter))
                {

                    work.VoterRepository.Update(theVoter);
                    work.Save();

                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Voter/Delete/5

        public ActionResult Delete(int id)
        {
            Voter theVoter = work.VoterRepository.GetByID(id);


            return View(theVoter);
        }

        //
        // POST: /Voter/Delete/5

        [HttpPost]
        public ActionResult Delete(Voter theVoter)
        {
            try
            {

            Voter theRealVoter =    work.VoterRepository.GetByID(theVoter.VoterID);
               // Membership.GetUser
           // Membership.DeleteUser(theRealVoter.IdentityNumber, true);


            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(theRealVoter.IdentityNumber);

            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(theRealVoter.IdentityNumber,true);

            work.VoterRepository.Delete(theRealVoter);
             //  
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
