using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;
using MentorBilling.ObjectStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.EntityFramework.DatabaseLink
{
    public class GroupFunctions : MentorBillingContext
    {
        /// <summary>
        /// this function will retrieve the group to which the user is part of
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the Group</returns>
        public Group GetUserGroup(User user)
        {
            List<Group> GroupQuery = (from gu in base.GrupuriUtilizatori
                                     join g in base.Grupuri on gu.GrupId equals g.Id
                                     join u in base.Utilizatori on g.AdministratorGrup equals u.Id
                                     where gu.UtilizatorId == user.ID && (gu.Activ ?? false) && (u.Activ ?? false)
                                     select new Group
                                     {
                                         ID = g.Id,
                                         Name = g.Denumire,
                                         Administrator = new User
                                         {
                                             ID = u.Id,
                                             Username = u.NumeUtilizator,
                                             Surname = u.Nume,
                                             Name = u.Prenume
                                         }
                                     }).ToList();
            return GroupQuery.FirstOrDefault();
        }
    }
}
