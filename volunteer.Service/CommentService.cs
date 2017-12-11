using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteersPidev.Service;
using VolunteersPidev.Data.Infrastructure;
using VolunteersPidev.Domain.Entities;

namespace VolunteersPidev.Service
{
    public class CommentService : Service<CommentService>, ICommentService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public CommentService() : base(ut)
        {

        }

        public void insertComment(Comment c)
        {
            ut.getRepository<Comment>().Add(c);
        }

        public void updateComment(Comment c)
        {
            ut.getRepository<Comment>().Update(c);
        }

        public void remove(Comment c)
        {
            ut.getRepository<Comment>().Delete(c);
        }
        public IEnumerable<Comment> getAll()
        {
            return ut.getRepository<Comment>().GetAll();
        }
        public Comment getById(long id)
        {
            return ut.getRepository<Comment>().GetById(id);
        }

        public Comment getByIdI(int id)
        {
            return ut.getRepository<Comment>().GetById(id);
        }

        public int count()
        {
            return ut.getRepository<Comment>().GetMany(x => x.id != 0).Count();
        }
        public double average()
        {
            return ut.getRepository<Comment>().GetMany(x => x.id != 0).Average(x => x.note);
        }
        public users getUserId(int id)
        {
            return ut.getRepository<users>().GetById(id);
        }

    }
}
