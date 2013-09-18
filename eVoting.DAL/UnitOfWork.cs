using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoting.DAL
{
    public class UnitOfWork : IDisposable
    {
        private evContext context = new evContext();
        private PostRepository postRepository;
        private ElectorateRepository electorateRepository;
        private ParticipantRepository participantRepository;
        private VoterRepository voterRepository;
        private PhotoRepository photoRepository;

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Save()
        {
            try
            {

                context.SaveChanges();
            }
            catch (Exception e)
            {
                //  context.r
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PhotoRepository PhotoRepository
        {
            get
            {
                if (this.photoRepository == null)
                {
                    this.photoRepository = new PhotoRepository(context);
                }
                return photoRepository;
            }
        }
        public VoterRepository VoterRepository
        {
            get
            {
                if (this.voterRepository == null)
                {
                    this.voterRepository = new VoterRepository(context);
                }
                return voterRepository;
            }
        }

        public ParticipantRepository ParticipantRepository
        {
            get
            {
                if (this.participantRepository == null)
                {
                    this.participantRepository = new ParticipantRepository(context);
                }
                return participantRepository;
            }
        }


        public ElectorateRepository ElectorateRepository
        {
            get
            {
                if (this.electorateRepository == null)
                {
                    this.electorateRepository = new ElectorateRepository(context);
                }
                return electorateRepository;
            }
        }


        public PostRepository PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(context);
                }
                return postRepository;
            }
        }

    }
}
