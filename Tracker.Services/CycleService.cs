using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models.CycleModels;

namespace Tracker.Services
{
    public class CycleService
    {
        private readonly Guid _userID;
        public CycleService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCycle (CycleCreate model)
        {
            var entity = new Cycle()
            {
                UserID = _userID,
                DateStarted = model.DateStarted,
                DateEnded = model.DateEnded,
                Comments = model.Comments,
                CreatedTime = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cycles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CycleListItem> ViewAllCycles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Cycles.Where
                    (d => d.UserID == _userID).Select(d => new CycleListItem
                    {
                        CycleID = d.CycleID,
                        DateStarted = d.DateStarted,
                        DateEnded = d.DateEnded
                    }
                );
                return query.ToArray();
            }
        }
        public CycleDetails GetCycleByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Cycles.Single(d => d.CycleID == id && d.UserID == _userID);
                return
                    new CycleDetails
                    {
                        CycleID = entity.CycleID,
                        DateStarted = entity.DateStarted,
                        DateEnded = entity.DateEnded,
                        Comments = entity.Comments,
                        CreatedTime = entity.CreatedTime,
                        ModifiedTime = entity.ModifiedTime
                    };
            }
        }
        public bool UpdateCycle (CycleUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cycles.Single
                    (d => d.CycleID == model.CycleID && d.UserID == _userID);
                        entity.DateStarted = model.DateStarted;
                        entity.DateEnded = model.DateEnded;
                        entity.Comments = model.Comments;
                        entity.ModifiedTime = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCycle(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cycles.Single
                    (d => d.CycleID == id && d.UserID == _userID);
                ctx.Cycles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
