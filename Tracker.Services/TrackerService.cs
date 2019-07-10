using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;
using Tracker.Models.PersonalInfoModels;

namespace Tracker.Services
{
    public class TrackerService
    {
        private readonly Guid _userID;
        public TrackerService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreatePersonalInfo(PersonalInfoCreate model)
        {
            var entity =
                new PersonalInfo()
                {
                    UserID = _userID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    PreviousPregnancies = model.PreviousPregnancies,
                    ViablePreg = model.ViablePreg,
                    FailedPreg = model.FailedPreg,
                    TerminatedPreg = model.TerminatedPreg,
                    WhyUsing = model.WhyUsing,
                    MedicalHistory = model.MedicalHistory,
                    CreatedTime = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PersonalInfos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PersonalInfoDetails> ViewPersonalInfoDetail()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PersonalInfos.Where
                    (d => d.UserID == _userID).Select(
                    d => new PersonalInfoDetails
                    {
                        FirstName = d.FirstName,
                        LastName = d.LastName,
                        Age = d.Age,
                        PreviousPregnancies = d.PreviousPregnancies,
                        ViablePreg = d.ViablePreg,
                        FailedPreg = d.FailedPreg,
                        TerminatedPreg = d.TerminatedPreg,
                        WhyUsing = d.WhyUsing,
                        MedicalHistory = d.MedicalHistory,
                        CreatedTime = d.CreatedTime
                    }
                    );
                return query;
            }
        }
        public PersonalInfoDetails GetPersonalInfoByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx.PersonalInfos.SingleOrDefault(d => d.UserID == id && d.UserID == _userID);

                if (entity != null)
                {
                    return new PersonalInfoDetails
                    {
                        UserID = id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Age = entity.Age,
                        PreviousPregnancies = entity.PreviousPregnancies,
                        ViablePreg = entity.ViablePreg,
                        FailedPreg = entity.FailedPreg,
                        TerminatedPreg = entity.TerminatedPreg,
                        WhyUsing = entity.WhyUsing,
                        MedicalHistory = entity.MedicalHistory,
                        CreatedTime = entity.CreatedTime,
                        ModifiedTime = entity.ModifiedTime
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public bool UpdatePersonalInfo(PersonalInfoUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalInfos.Single(u => u.UserID == model.UserId && u.UserID == _userID);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Age = model.Age;
                entity.PreviousPregnancies = model.PreviousPregnancies;
                entity.ViablePreg = model.ViablePreg;
                entity.FailedPreg = model.FailedPreg;
                entity.TerminatedPreg = model.TerminatedPreg;
                entity.WhyUsing = model.WhyUsing;
                entity.MedicalHistory = model.MedicalHistory;
                entity.ModifiedTime = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePersonalInfo(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PersonalInfos.Single(d => d.UserID == userID && d.UserID == _userID);
                ctx.PersonalInfos.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
