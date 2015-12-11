using eVoting.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace eVoting.Controllers
{
    //[ConcurrencyCheck]   
    [Authorize]
    public class PostController : Controller
    {
        UnitOfWork work = new UnitOfWork();
        //
        // GET: /Post/

        public ActionResult Index()
        {
            // work.PostRepository.Get().ToList();
            return View(work.PostRepository.Get().ToList());
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            // evContext con = new evContext();
            // con.Posts.Include(d=>d.)

            Post thePost = work.PostRepository.GetByID(id);
            int thePostId = thePost.PostID;
            List<Participant> theParticipants = work.ParticipantRepository.Get(a => a.PostID == thePostId).ToList();
            ViewBag.Participant = theParticipants;
            return View(thePost);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(Post model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    work.PostRepository.Insert(model);
                    work.Save();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id)
        {
            Post thePost = work.PostRepository.GetByID(id);

            return View(thePost);
        }

        public ActionResult Vote()
        {
            // evContext ev = new evContext();
            ///  ev.Posts.Include(as=).
            List<Post> thePosts = work.PostRepository.Get().ToList();

            // List<Participant> theParticipants = work.ParticipantRepository.Get(a => a.PostID == 2).ToList();
            //foreach (var post in thePosts)
            //{
            //    List<Participant> theParticipants = work.ParticipantRepository.Get(a => a.PostID == post.PostID).ToList();
            //    ViewBag.Participant = theParticipants;
            //}
            //int thePostId = thePost.PostID;
            //List<Participant> theParticipants = work.ParticipantRepository.Get(a => a.PostID == thePostId).ToList();
            //ViewBag.Participant = theParticipants;

            return View("Vote", thePosts);
        }
        [Authorize]
        public ActionResult Voted(string PRESIDENT, string VICE_PRESIDENT, string GENERAL_SECRETARY,
            string ASST_GENERAL_SECRETARY, string FINANCIAL_SECRETARY, string TREASURER, string PUBLIC_RELATIONS_OFFICER,
            string SOCIAL_DIRECTOR, string WELFARE_OFFICER, string SPORT_DIRECTOR, string ASST_SPORT_DIRECTOR,
            string theKey)
        {

            long theCounter = Convert.ToInt64(theKey);
            if (theCounter > 0)
            {
                //   var future = new Date("Dec 3 2013 21:15:00 GMT+0200");
                // var now = new Date();
                // var difference = Math.floor((future.getTime() - now.getTime()) / 1000);
                //@Html.Raw(theParticipants[0].ParticipantID + ":" + "YES")
                //PRESIDENT
                // VICE_PRESIDENT
                //GENERAL_SECRETARY
                //ASSISTANT_GENERAL_SECRETARY
                //FINANCIAL_SECRETARY
                //TREASURER
                //PUBLIC_RELATIONS_OFFICER
                var context = new evContext();
                // using (var context = new evContext())
                // {

                // context.

                //president
                int pre = 0;
                if (!(string.IsNullOrEmpty(PRESIDENT)))
                {
                    string[] c = PRESIDENT.Split(':');
                    if (c.Count() == 1)
                    {
                        pre = Convert.ToInt32(PRESIDENT);
                        // Participant thePar = work.ParticipantRepository.GetByID(pre);
                        Participant thePar = context.Participants.Find(pre);
                        thePar.Vote = thePar.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        //@Html.Raw(theParticipants[0].ParticipantID + ":" + "YES")
                        pre = Convert.ToInt32(c[0]);
                        // Participant thePar = work.ParticipantRepository.GetByID(pre);
                        Participant thePar = context.Participants.Find(pre);
                        if (c[1] == "YES")
                        {
                            thePar.Yes = thePar.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            thePar.No = thePar.No + 1;
                        }

                    }
                    //  context.Participants.sa
                    // work.ParticipantRepository.Update(thePar);
                    // work.Save();
                }


                //vp
                int vp = 0;
                if (!(string.IsNullOrEmpty(VICE_PRESIDENT)))
                {
                    string[] c = VICE_PRESIDENT.Split(':');
                    if (c.Count() == 1)
                    {
                        vp = Convert.ToInt32(VICE_PRESIDENT);
                        Participant vpPar = context.Participants.Find(vp);
                        vpPar.Vote = vpPar.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        vp = Convert.ToInt32(c[0]);
                        Participant vpPar = context.Participants.Find(vp);
                        if (c[1] == "YES")
                        {
                            vpPar.Yes = vpPar.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            vpPar.No = vpPar.No + 1;
                        }
                    }
                    //   work.ParticipantRepository.Update(vpPar);
                    // work.Save();
                }

                //gs
                int gn = 0;
                if (!(string.IsNullOrEmpty(GENERAL_SECRETARY)))
                {
                    string[] c = GENERAL_SECRETARY.Split(':');
                    if (c.Count() == 1)
                    {
                        gn = Convert.ToInt32(GENERAL_SECRETARY);
                        Participant vpPar = context.Participants.Find(gn);
                        vpPar.Vote = vpPar.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        gn = Convert.ToInt32(c[0]);
                        Participant vpPar = context.Participants.Find(gn);
                        if (c[1] == "YES")
                        {
                            vpPar.Yes = vpPar.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            vpPar.No = vpPar.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(vpPar);
                    //  work.Save();

                }


                //ags
                int ags = 0;
                if (!(string.IsNullOrEmpty(ASST_GENERAL_SECRETARY)))
                {
                    string[] c = ASST_GENERAL_SECRETARY.Split(':');
                    if (c.Count() == 1)
                    {
                        ags = Convert.ToInt32(ASST_GENERAL_SECRETARY);
                        Participant Par = context.Participants.Find(ags);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        ags = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(ags);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }

                //pro
                int pro = 0;
                if (!(string.IsNullOrEmpty(PUBLIC_RELATIONS_OFFICER)))
                {
                    string[] c = PUBLIC_RELATIONS_OFFICER.Split(':');
                    if (c.Count() == 1)
                    {
                        pro = Convert.ToInt32(PUBLIC_RELATIONS_OFFICER);
                        Participant Par = context.Participants.Find(pro);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        pro = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(pro);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    // work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }


                //fs
                int fs = 0;
                if (!(string.IsNullOrEmpty(FINANCIAL_SECRETARY)))
                {
                    string[] c = FINANCIAL_SECRETARY.Split(':');
                    if (c.Count() == 1)
                    {
                        fs = Convert.ToInt32(FINANCIAL_SECRETARY);
                        Participant Par = context.Participants.Find(fs);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        fs = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(fs);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    // work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }


                //tr
                int tr = 0;
                if (!(string.IsNullOrEmpty(TREASURER)))
                {
                    string[] c = TREASURER.Split(':');
                    if (c.Count() == 1)
                    {
                        tr = Convert.ToInt32(TREASURER);
                        Participant Par = context.Participants.Find(tr);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        tr = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(tr);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }



                //sd
                int sd = 0;
                if (!(string.IsNullOrEmpty(SOCIAL_DIRECTOR)))
                {
                    string[] c = SOCIAL_DIRECTOR.Split(':');
                    if (c.Count() == 1)
                    {
                        sd = Convert.ToInt32(SOCIAL_DIRECTOR);
                        Participant Par = context.Participants.Find(sd);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        sd = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(sd);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }



                //wo
                int wo = 0;
                if (!(string.IsNullOrEmpty(WELFARE_OFFICER)))
                {
                    string[] c = WELFARE_OFFICER.Split(':');
                    if (c.Count() == 1)
                    {
                        wo = Convert.ToInt32(WELFARE_OFFICER);
                        Participant Par = context.Participants.Find(wo);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        wo = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(wo);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }


                //sdr
                int sdr = 0;
                if (!(string.IsNullOrEmpty(SPORT_DIRECTOR)))
                {
                    string[] c = SPORT_DIRECTOR.Split(':');
                    if (c.Count() == 1)
                    {
                        sdr = Convert.ToInt32(SPORT_DIRECTOR);
                        Participant Par = context.Participants.Find(sdr);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        sdr = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(sdr);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }

                //wo
                int asd = 0;
                if (!(string.IsNullOrEmpty(ASST_SPORT_DIRECTOR)))
                {
                    string[] c = ASST_SPORT_DIRECTOR.Split(':');
                    if (c.Count() == 1)
                    {
                        asd = Convert.ToInt32(ASST_SPORT_DIRECTOR);
                        Participant Par = context.Participants.Find(asd);
                        Par.Vote = Par.Vote + 1;
                    }
                    if (c.Count() == 2)
                    {
                        asd = Convert.ToInt32(c[0]);
                        Participant Par = context.Participants.Find(asd);
                        if (c[1] == "YES")
                        {
                            Par.Yes = Par.Yes + 1;
                        }
                        if (c[1] == "NO")
                        {
                            Par.No = Par.No + 1;
                        }
                    }
                    //  work.ParticipantRepository.Update(Par);
                    //  work.Save();

                }










                //ds
                //int ds = 0;
                //if (!(string.IsNullOrEmpty(DIRECTOR_OF_SPORT)))
                //{
                //    ds = Convert.ToInt32(DIRECTOR_OF_SPORT);
                //    Participant Par = context.Participants.Find(ds);
                //    Par.Vote = Par.Vote + 1;
                //   // work.ParticipantRepository.Update(Par);
                //    //work.Save();

                //}

                //dos
                //int pro = 0;
                //if (!(string.IsNullOrEmpty(PUBLIC_RELATIONS_OFFICER)))
                //{
                //    pro = Convert.ToInt32(PUBLIC_RELATIONS_OFFICER);
                //    Participant Par = context.Participants.Find(pro);
                //    Par.Vote = Par.Vote + 1;
                //   // work.ParticipantRepository.Update(Par);
                //  //  work.Save();

                //}

                //dos
                //int wo = 0;
                //if (!(string.IsNullOrEmpty(WELFARE_OFFICER)))
                //{
                //    wo = Convert.ToInt32(WELFARE_OFFICER);
                //    Participant Par = context.Participants.Find(wo);
                //    Par.Vote = Par.Vote + 1;
                //   // work.ParticipantRepository.Update(Par);
                // //   work.Save();

                //}

                ////l
                //int l = 0;
                //if (!(string.IsNullOrEmpty(LIBRARIAN)))
                //{
                //    l = Convert.ToInt32(LIBRARIAN);
                //    Participant Par = context.Participants.Find(l);
                //    Par.Vote = Par.Vote + 1;
                //   // work.ParticipantRepository.Update(Par);
                //  //  work.Save();

                //}




                bool saveFailed;
                do
                {
                    saveFailed = false;

                    try
                    {
                        string theUserNamee = User.Identity.Name;
                        Voter theVoter = work.VoterRepository.Get(a => a.IdentityNumber == theUserNamee).First();

                        // theVoter.VotedTime = DateTime.Now;
                        // theVoter.Voted = true;
                        if (theVoter.Voted != true)
                        {
                            context.SaveChanges();
                            context.Dispose();
                        }
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update the values of the entity that failed to save from the store
                        //  ex.Entries.Single().Reload();
                        //ex.Data.
                        context = new evContext();
                        //president
                        pre = 0;
                        if (!(string.IsNullOrEmpty(PRESIDENT)))
                        {


                            string[] c = PRESIDENT.Split(':');
                            if (c.Count() == 1)
                            {
                                pre = Convert.ToInt32(PRESIDENT);
                                // Participant thePar = work.ParticipantRepository.GetByID(pre);
                                Participant thePar = context.Participants.Find(pre);
                                thePar.Vote = thePar.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                //@Html.Raw(theParticipants[0].ParticipantID + ":" + "YES")
                                pre = Convert.ToInt32(c[0]);
                                // Participant thePar = work.ParticipantRepository.GetByID(pre);
                                Participant thePar = context.Participants.Find(pre);
                                if (c[1] == "YES")
                                {
                                    thePar.Yes = thePar.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    thePar.No = thePar.No + 1;
                                }

                            }






                            //pre = Convert.ToInt32(PRESIDENT);
                            //// Participant thePar = work.ParticipantRepository.GetByID(pre);
                            //Participant thePar = context.Participants.Find(pre);
                            //thePar.Vote = thePar.Vote + 1;
                            ////  context.Participants.sa
                            //// work.ParticipantRepository.Update(thePar);
                            //// work.Save();
                        }


                        //vp
                        vp = 0;
                        if (!(string.IsNullOrEmpty(VICE_PRESIDENT)))
                        {

                            string[] c = VICE_PRESIDENT.Split(':');
                            if (c.Count() == 1)
                            {
                                vp = Convert.ToInt32(VICE_PRESIDENT);
                                Participant vpPar = context.Participants.Find(vp);
                                vpPar.Vote = vpPar.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                vp = Convert.ToInt32(c[0]);
                                Participant vpPar = context.Participants.Find(vp);
                                if (c[1] == "YES")
                                {
                                    vpPar.Yes = vpPar.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    vpPar.No = vpPar.No + 1;
                                }
                            }











                            //vp = Convert.ToInt32(VICE_PRESIDENT);
                            //Participant vpPar = context.Participants.Find(vp);
                            //vpPar.Vote = vpPar.Vote + 1;
                            ////   work.ParticipantRepository.Update(vpPar);
                            //// work.Save();
                        }

                        //gs
                        gn = 0;
                        if (!(string.IsNullOrEmpty(GENERAL_SECRETARY)))
                        {
                            string[] c = GENERAL_SECRETARY.Split(':');
                            if (c.Count() == 1)
                            {
                                gn = Convert.ToInt32(GENERAL_SECRETARY);
                                Participant vpPar = context.Participants.Find(gn);
                                vpPar.Vote = vpPar.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                gn = Convert.ToInt32(c[0]);
                                Participant vpPar = context.Participants.Find(gn);
                                if (c[1] == "YES")
                                {
                                    vpPar.Yes = vpPar.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    vpPar.No = vpPar.No + 1;
                                }
                            }
                            //gn = Convert.ToInt32(GENERAL_SECRETARY);
                            //Participant vpPar = context.Participants.Find(gn);
                            //vpPar.Vote = vpPar.Vote + 1;
                            ////  work.ParticipantRepository.Update(vpPar);
                            ////  work.Save();

                        }


                        //ags
                        ags = 0;
                        if (!(string.IsNullOrEmpty(ASST_GENERAL_SECRETARY)))
                        {
                            string[] c = ASST_GENERAL_SECRETARY.Split(':');
                            if (c.Count() == 1)
                            {
                                ags = Convert.ToInt32(ASST_GENERAL_SECRETARY);
                                Participant Par = context.Participants.Find(ags);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                ags = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(ags);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //ags = Convert.ToInt32(ASSISTANT_GENERAL_SECRETARY);
                            //Participant Par = context.Participants.Find(ags);
                            //Par.Vote = Par.Vote + 1;
                            ////  work.ParticipantRepository.Update(Par);
                            ////  work.Save();

                        }

                        //pro
                        pro = 0;
                        if (!(string.IsNullOrEmpty(PUBLIC_RELATIONS_OFFICER)))
                        {
                            string[] c = PUBLIC_RELATIONS_OFFICER.Split(':');
                            if (c.Count() == 1)
                            {
                                pro = Convert.ToInt32(PUBLIC_RELATIONS_OFFICER);
                                Participant Par = context.Participants.Find(pro);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                pro = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(pro);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //pro = Convert.ToInt32(PUBLIC_RELATION_OFFICER);
                            //Participant Par = context.Participants.Find(pro);
                            //Par.Vote = Par.Vote + 1;
                            //// work.ParticipantRepository.Update(Par);
                            ////  work.Save();

                        }


                        //fs
                        fs = 0;
                        if (!(string.IsNullOrEmpty(FINANCIAL_SECRETARY)))
                        {
                            string[] c = FINANCIAL_SECRETARY.Split(':');
                            if (c.Count() == 1)
                            {
                                fs = Convert.ToInt32(FINANCIAL_SECRETARY);
                                Participant Par = context.Participants.Find(fs);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                fs = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(fs);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //fs = Convert.ToInt32(FINANCIAL_SECRETARY);
                            //Participant Par = context.Participants.Find(fs);
                            //Par.Vote = Par.Vote + 1;
                            //// work.ParticipantRepository.Update(Par);
                            ////  work.Save();

                        }


                        //tr
                        tr = 0;
                        if (!(string.IsNullOrEmpty(TREASURER)))
                        {
                            string[] c = TREASURER.Split(':');
                            if (c.Count() == 1)
                            {
                                tr = Convert.ToInt32(TREASURER);
                                Participant Par = context.Participants.Find(tr);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                tr = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(tr);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //tr = Convert.ToInt32(TREASURER);
                            //Participant Par = context.Participants.Find(tr);
                            //Par.Vote = Par.Vote + 1;
                            ////  work.ParticipantRepository.Update(Par);
                            ////  work.Save();

                        }


                        sd = 0;
                        if (!(string.IsNullOrEmpty(SOCIAL_DIRECTOR)))
                        {
                            string[] c = SOCIAL_DIRECTOR.Split(':');
                            if (c.Count() == 1)
                            {
                                sd = Convert.ToInt32(SOCIAL_DIRECTOR);
                                Participant Par = context.Participants.Find(sd);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                sd = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(sd);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //  work.ParticipantRepository.Update(Par);
                            //  work.Save();

                        }



                        //wo
                        wo = 0;
                        if (!(string.IsNullOrEmpty(WELFARE_OFFICER)))
                        {
                            string[] c = WELFARE_OFFICER.Split(':');
                            if (c.Count() == 1)
                            {
                                wo = Convert.ToInt32(WELFARE_OFFICER);
                                Participant Par = context.Participants.Find(wo);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                wo = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(wo);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //  work.ParticipantRepository.Update(Par);
                            //  work.Save();

                        }


                        //sdr
                        sdr = 0;
                        if (!(string.IsNullOrEmpty(SPORT_DIRECTOR)))
                        {
                            string[] c = SPORT_DIRECTOR.Split(':');
                            if (c.Count() == 1)
                            {
                                sdr = Convert.ToInt32(SPORT_DIRECTOR);
                                Participant Par = context.Participants.Find(sdr);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                sdr = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(sdr);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //  work.ParticipantRepository.Update(Par);
                            //  work.Save();

                        }

                        //wo
                        asd = 0;
                        if (!(string.IsNullOrEmpty(ASST_SPORT_DIRECTOR)))
                        {
                            string[] c = ASST_SPORT_DIRECTOR.Split(':');
                            if (c.Count() == 1)
                            {
                                asd = Convert.ToInt32(ASST_SPORT_DIRECTOR);
                                Participant Par = context.Participants.Find(asd);
                                Par.Vote = Par.Vote + 1;
                            }
                            if (c.Count() == 2)
                            {
                                asd = Convert.ToInt32(c[0]);
                                Participant Par = context.Participants.Find(asd);
                                if (c[1] == "YES")
                                {
                                    Par.Yes = Par.Yes + 1;
                                }
                                if (c[1] == "NO")
                                {
                                    Par.No = Par.No + 1;
                                }
                            }
                            //  work.ParticipantRepository.Update(Par);
                            //  work.Save();

                        }

                        //ds
                        //pro = 0;
                        //if (!(string.IsNullOrEmpty(PUBLIC_RELATIONS_OFFICER)))
                        //{
                        //    pro = Convert.ToInt32(PUBLIC_RELATIONS_OFFICER);
                        //    Participant Par = context.Participants.Find(pro);
                        //    Par.Vote = Par.Vote + 1;
                        //    // work.ParticipantRepository.Update(Par);
                        //    //work.Save();

                        //}

                        //dos
                        //dos = 0;
                        //if (!(string.IsNullOrEmpty(DIRECTOR_OF_SOCIAL)))
                        //{
                        //    dos = Convert.ToInt32(DIRECTOR_OF_SOCIAL);
                        //    Participant Par = context.Participants.Find(dos);
                        //    Par.Vote = Par.Vote + 1;
                        //    // work.ParticipantRepository.Update(Par);
                        //    //  work.Save();

                        //}

                        ////dos
                        //wo = 0;
                        //if (!(string.IsNullOrEmpty(WELFARE_OFFICER)))
                        //{
                        //    wo = Convert.ToInt32(WELFARE_OFFICER);
                        //    Participant Par = context.Participants.Find(wo);
                        //    Par.Vote = Par.Vote + 1;
                        //    // work.ParticipantRepository.Update(Par);
                        //    //   work.Save();

                        //}

                        ////l
                        //l = 0;
                        //if (!(string.IsNullOrEmpty(LIBRARIAN)))
                        //{
                        //    l = Convert.ToInt32(LIBRARIAN);
                        //    Participant Par = context.Participants.Find(l);
                        //    Par.Vote = Par.Vote + 1;
                        //    // work.ParticipantRepository.Update(Par);
                        //    //  work.Save();

                        //}

                    }

                } while (saveFailed);
                // }


                string theUserName = User.Identity.Name;

                if (!(theUserName.EndsWith("eem")))
                {
                    //if(theUserNamee.)
                    Voter theVoter = work.VoterRepository.Get(a => a.IdentityNumber == theUserName).First();
                    if (theVoter.Voted != true)
                    {
                        theVoter.VotedTime = DateTime.Now;
                        theVoter.Voted = true;
                        work.VoterRepository.Update(theVoter);
                        work.Save();
                    }
                }
                //,string ,string ,string ,string )
                //  MvcMembership.log
                FormsAuthentication.SignOut();
                //   WebSecurity.Logout();///Account/Login
                return RedirectToAction("Login", "Account", new { id = 1 });
                // return View();

            }
            else
            {
                FormsAuthentication.SignOut();
                // WebSecurity.Logout();///Account/Login
                return RedirectToAction("Login", "Account", new { id = 2 });
            }
        }

        public ActionResult Result()
        {
            List<Post> theposts = work.PostRepository.Get().ToList();

            List<Voter> voters = work.VoterRepository.Get(a => a.Voted == true).ToList();
            // List<Voter> totalVoters = work.VoterRepository.Get(a => a.LastName != "Oyebode1234567").ToList();

            List<Voter> totalVoters = work.VoterRepository.Get().ToList();

            ViewBag.NumberVoted = voters.Count();
            ViewBag.TotalVoter = totalVoters.Count() - 3;

            return View("Result", theposts);
        }


        public ActionResult EnterName()
        {
            Roles.AddUserToRole("kayode", "Admin");
            //MvcMembership.ad
            //   WebSecurity.CreateUserAndAccount("kayode", "kayode1");
            //  WebSecurity.CreateUserAndAccount("kayode", "kayode1");

            return View();
        }

        public ActionResult GivePassword(string MatNumber)
        {
            ViewBag.DateTime = "";
            string theMat = "0";
            List<Voter> voter = new List<Voter>();
            if (!(string.IsNullOrEmpty(MatNumber)))
            {
                theMat = MatNumber.ToUpper();
                List<Voter> theVote = work.VoterRepository.Get(a => a.Matric == theMat).ToList();
                if (theVote.Count() > 0)
                {

                    // // DateTime d = new DateTime(
                    //string dateString =  Convert.ToString(theVote[0].VotedTime);

                    //string[] theSplitedDate =   dateString.Split('/');
                    //  DateTime thenewDateFromDatabase = new DateTime(2013,Convert.ToInt16(theSplitedDate[0]),Convert.ToInt16(theSplitedDate[1]));
                    // // DateTime date1 = new DateTime(2009, 8, 1, 0, 0, 0);
                    //  DateTime date2 = new DateTime(2013, 5, 1);
                    //  int result = DateTime.Compare(thenewDateFromDatabase, date2);
                    //  // int 
                    //  if (result < 0)
                    //      ViewBag.DateTime = String.Format("{0:ddd, MMM d, yyyy}", theVote[0].VotedTime);  //"Never voted";
                    //  else if (result == 0)
                    //      ViewBag.DateTime = "Never voted";
                    //  else
                    //      ViewBag.DateTime = String.Format("{0:ddd, MMM d, yyyy h:mm:ss tt}", theVote[0].VotedTime); 
                    return View("PasswordCheck", theVote);
                }
                else
                {
                    return View("PasswordCheck", voter);
                }
                // Voter theV = theVote[0];

            }
            else
            {
                return View("PasswordCheck", voter);
            }






        }


        //public void Populate()
        //{
        //    var chars = "1ABC2DEFGH2JK4LM5N6P7Q8RS9TU1VWXYZ9865432";
        //    var random = new Random();
        //    // string result = new string(Enumerable.Repeat(chars,6).Select(s=>s[random.Next(s.Length)]).ToArray());


        //    FileStream fs = new FileStream("C:\\Users\\kazeem\\Desktop\\School Projects\\studentshut.txt", FileMode.Open, FileAccess.Read);
        //    StreamReader sr = new StreamReader(fs);
        //    // Math.
        //    //  string theLast = null;
        //    // string theMatric = null;
        //    while (!(sr.EndOfStream))
        //    {
        //        string randomPassword = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        //        string theMatric = sr.ReadLine().Trim();

        //        Voter theVoter = new Voter();
        //        theVoter.IdentityNumber = theMatric;
        //        theVoter.Password = randomPassword;
        //        theVoter.VotedTime = DateTime.Now;
        //        theVoter.Voted = false;
        //        work.VoterRepository.Insert(theVoter);
        //        work.Save();

        //        WebSecurity.CreateUserAndAccount(theMatric, randomPassword);
        //        //  theLast  =theMatric;
        //    }
        //    sr.Close();
        //    fs.Close();
        //    //  theLast = theMatric;
        //    // List<Post> theposts = work.PostRepository.Get().ToList();
        //    // return View("Result", theposts);
        //}

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    work.PostRepository.Update(model);
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

        [Authorize(Roles = "SuperAdmin,InterAdmin,Admin")]
        public FileStreamResult PrintPassword()
        {
            // Set up the document and the MS to write it to and create the PDF writer instance
            MemoryStream ms = new MemoryStream();
            Document document = new Document(PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            // Open the PDF document
            document.Open();

            PdfPTable table1 = new PdfPTable(1);

            // oStringWriter.Write("This is the content");
            //  Response.ContentType = "text/plain";
            //  Response.ContentType = "application/pdf";



            //  MemoryStream ms = new MemoryStream();
            //  Document document = new Document(PageSize.A4.Rotate());

            // Open the PDF document
            // document.Open();


            // PdfWriter writer = PdfWriter.GetInstance(document, ms);



            // Set up fonts used in the document
            Font font_heading_1 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 21, Font.BOLD);
            Font font_body = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12);
            Font font_body2 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 13);




            List<string> theDepartments = new List<string>();

            //theDepartments.Add("200level Chemical Engineering");
            //theDepartments.Add("200level Civil Engineering");
            //theDepartments.Add("200level Computer Engineering");
            //theDepartments.Add("200level Electrical Electronics");
            //theDepartments.Add("200level Mechatronics Engineering");
            //theDepartments.Add("200level Mechanical Engineering");
            //theDepartments.Add("200level Petroleum Engineering");
            //theDepartments.Add("400level Chemical Engineering");
            //theDepartments.Add("400level Computer Engineering");
            //theDepartments.Add("400level Civil Engineering");
            //theDepartments.Add("400level Electrical Electronic");
            //theDepartments.Add("400level Mechatronics Engineering");
            //theDepartments.Add("400level Mechanical Engineering");
            //theDepartments.Add("400level Petroleum Engineering");
            //theDepartments.Add("500level Chemical Engineering");
            //theDepartments.Add("500level Computer Engineering");
            //theDepartments.Add("500level Civil Engineering");
            //theDepartments.Add("500level Electrical Electronics");
            //theDepartments.Add("500level Mechatronics Engineering");
            //theDepartments.Add("500level Mechanical Engineering");
            //theDepartments.Add("500level Petroleum Engineering");
            //theDepartments.Add("300level Chemical Engineering");
            //theDepartments.Add("300level Computer Engineering");
            //theDepartments.Add("300level Civil Engineering");

            //theDepartments.Add("300level Electrical Electronics");
            //theDepartments.Add("300level Mechatronics Engineering");
            //theDepartments.Add("300level Mechanical Engineering");
            //theDepartments.Add("300level Petroleum Engineering");


           // theDepartments.Add("ORAL MAXILLOFACIAL SURGERY");
           // theDepartments.Add("GERIATRICS");
           // theDepartments.Add("HOUSE OFFICER");
            theDepartments.Add("ANAESTHESIA");
            theDepartments.Add("CHEMICAL PATHOLOGY");
            theDepartments.Add("CLINICAL PHARMACOLOGY");
            theDepartments.Add("PREVENTIVE DENTISTRY");
            theDepartments.Add("GENERAL OUTPATIENT");
            theDepartments.Add("HAEMATOLOGY");
            theDepartments.Add("PRIVATE SUITE");
            theDepartments.Add("NEURO SURGERY");
            theDepartments.Add("MEDICAL MICROBIOLOGY");
            theDepartments.Add("MEDICINE");
            theDepartments.Add("OBSTETRICS & GYNAECOLOGY");
            theDepartments.Add("OPHTHALMOLOGY");
            theDepartments.Add("ENT");
            theDepartments.Add("PAEDIATRICS");
            theDepartments.Add("PATHOLOGY");
            theDepartments.Add("COMMUNITY MEDICINE");
            theDepartments.Add("PSYCHIATRY");
            theDepartments.Add("RADIOLOGY");
            theDepartments.Add("RADIOTHERAPY");
            theDepartments.Add("COLLEGE OF MEDICINE STAFF");
            theDepartments.Add("STAFF CLINIC");
            theDepartments.Add("SURGERY");
            theDepartments.Add("OFFICE OF CMD");
            theDepartments.Add("CONSULTANT");

            theDepartments.Add("ORTHOPAEDIC & TRAUMA");
            theDepartments.Add("ACCIDENT & EMEGENCY");
            theDepartments.Add("NUCLEAR MEDICINE");
           // theDepartments.Add("RESTORATIVE DENTISTRY");
            theDepartments.Add("ORAL MAXILLOFACIAL SURGERY");
           // theDepartments.Add("GERIATRICS");
           // theDepartments.Add("HOUSE OFFICER");


            //string theDepartment =   
            foreach (string d in theDepartments)
            {
                List<Voter> theVoters = work.VoterRepository.Get(a => a.IdentityNumber != "chair" && a.IdentityNumber != "kazeem" && a.IdentityNumber != "password" && a.Department == d && a.IdentityNumber != "").OrderBy(a => a.IdentityNumber).ToList();
                Font font_body4 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 21);
                PdfPTable table3 = new PdfPTable(1);
                Paragraph paragraph3 = new Paragraph(d, font_body4);
                table3.AddCell(paragraph3);
                table1.AddCell(table3);
                // table1.AddCell(paragraph3);
                foreach (Voter v in theVoters)
                {
                    PdfPTable table2 = new PdfPTable(1);
                    string staffID = v.FirstName + " Staff ID- " + v.Matric;
                    string staffPassword = "USER NAME:- " + v.IdentityNumber + " PASSWORD: " + v.Password;
                    Paragraph paragraph = new Paragraph(staffID, font_body);
                    Paragraph paragraph1 = new Paragraph(staffPassword, font_body2);
                    table2.AddCell(paragraph);
                    table2.AddCell(paragraph1);

                    table1.AddCell(table2);
                }

                // table1.AddCell("");
            }
            document.Add(table1);
            // Create the heading paragraph with the headig font
            // Paragraph paragraph;
            // paragraph = new Paragraph("Hello world!", font_heading_1);
            //  itextDoc.Add(table1);
            // Document thedoc = itextDoc;// print.PrinttheResultPrimary(studentName, Term, studentLevel, ref oStringWriter1, ref document);
            // Add a horizontal line below the headig text and add it to the paragraph
            iTextSharp.text.pdf.draw.VerticalPositionMark seperator = new iTextSharp.text.pdf.draw.LineSeparator();
            seperator.Offset = -6f;
            // paragraph.Add(seperator);

            // Add paragraph to document
            // document.Add(paragraph);


            // Close the PDF document
            document.Close();

            // Hat tip to David for his code on stackoverflow for this bit
            // http://stackoverflow.com/questions/779430/asp-net-mvc-how-to-get-view-to-generate-pdf
            byte[] file = ms.ToArray();
            MemoryStream output = new MemoryStream();
            output.Write(file, 0, file.Length);
            output.Position = 0;
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=form.pdf");




            // Close the PDF document
            // document.Close();






            return File(output, "application/pdf");
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id)
        {
            Post thePost = work.PostRepository.GetByID(id);
            return View(thePost);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(Post model)
        {
            try
            {
                // TODO: Add delete logic here

                work.PostRepository.Delete(model.PostID);
                work.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
