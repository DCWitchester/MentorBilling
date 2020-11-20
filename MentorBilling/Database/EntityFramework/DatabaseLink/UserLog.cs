using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;

namespace MentorBilling.Database.EntityFramework.DatabaseLink
{
    public class UserLog : MentorBillingContext
    {

        /// <summary>
        /// this function will login a given user in the log
        /// </summary>
        /// <param name="user">the user</param>
        /// <returns>the state of the query</returns>
        public void LoginUser(User user)
        {
            LogUtilizatori logUtilizator = new LogUtilizatori
            {
                UtilizatorId = user.ID,
                Logged = true
            };
            base.LogUtilizatori.Add(logUtilizator);
            base.SaveChanges();

        }
    }
}
