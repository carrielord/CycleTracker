using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models.BBTModels;


namespace Tracker.Services
{
    public class BBTService
    {
        private readonly Guid _userID;
        public BBTService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateBBT (BBTCreate model)
        {
            var entity = new BasalBodyTemp()
            {
                UserID = _userID,
                Temperature = model.Temperature,
                DateOfTemp = model.DateOfTemp,
                Comments = model.Comments,
                CreatedTime = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BasalBodyTemps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BBTListItem> ViewAllBBTs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.BasalBodyTemps.Where
                    (d => d.UserID == _userID).Select(d => new BBTListItem
                    {
                        BBTID=d.BBTID,
                        Temperature = d.Temperature,
                        DateOfTemp = d.DateOfTemp
                    }
                );
                return query.ToArray();
            }
        }
        public BBTDetails GetBBTByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.BasalBodyTemps.Single(d => d.BBTID == id && d.UserID == _userID);
                return
                    new BBTDetails
                    {
                        BBTID = entity.BBTID,
                        Temperature = entity.Temperature,
                        DateOfTemp = entity.DateOfTemp,
                        Comments = entity.Comments,
                        CreatedTime = entity.CreatedTime,
                        ModifiedTime = entity.ModifiedTime
                    };
            }
        }
        public bool UpdateBBT(BBTUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.BasalBodyTemps.Single
                    (d => d.BBTID == model.BBTID && d.UserID == _userID);
                entity.Temperature = model.Temperature;
                entity.DateOfTemp = model.DateOfTemp;
                entity.Comments = model.Comments;
                entity.ModifiedTime = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBBT(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.BasalBodyTemps.Single
                    (d => d.BBTID == id && d.UserID == _userID);
                ctx.BasalBodyTemps.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
