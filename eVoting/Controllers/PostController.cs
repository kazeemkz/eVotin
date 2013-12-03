using eVoting.DAL;
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
            string ASSISTANT_GENERAL_SECRETARY, string FINANCIAL_SECRETARY, string TREASURER, string PUBLIC_RELATIONS_OFFICER, string theKey)
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
                if (!(string.IsNullOrEmpty(ASSISTANT_GENERAL_SECRETARY)))
                {
                    string[] c = ASSISTANT_GENERAL_SECRETARY.Split(':');
                    if (c.Count() == 1)
                    {
                        ags = Convert.ToInt32(ASSISTANT_GENERAL_SECRETARY);
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
                        context.SaveChanges();
                        context.Dispose();
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
                        if (!(string.IsNullOrEmpty(ASSISTANT_GENERAL_SECRETARY)))
                        {
                            string[] c = ASSISTANT_GENERAL_SECRETARY.Split(':');
                            if (c.Count() == 1)
                            {
                                ags = Convert.ToInt32(ASSISTANT_GENERAL_SECRETARY);
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
                    Voter theVoter = work.VoterRepository.Get(a => a.IdentityNumber == theUserName).First();

                    theVoter.VotedTime = DateTime.Now;
                    theVoter.Voted = true;
                    work.VoterRepository.Update(theVoter);
                    work.Save();
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
                theMat = MatNumber;
                List<Voter> theVote = work.VoterRepository.Get(a => a.IdentityNumber == theMat).ToList();
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
