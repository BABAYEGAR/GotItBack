using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotItBack.Data.Context.DataContext;
using GotItBack.Data.Objects.Entities;

namespace GotItBack.Data.Factory.FactoryClasses
{
    public class ContactFactory
    {
        private readonly ContactDataContext _db = new ContactDataContext();

        /// <summary>
        ///     This method finds a yuser with the provided password and email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Contact GetAppUserByLogin(string email, string password)
        {
            email = email.Trim();
            var appUser =
                _db.Contacts.SingleOrDefault(n => n.Email == email && n.Password == password);
            return appUser;
        }

        /// <summary>
        ///     This method checks if a user exist
        /// </summary>
        /// <param name="email"></param>
        /// <param name="matricNumber"></param>
        /// <returns></returns>
        public bool CheckIfStudentUserExist(string email, string matricNumber)
        {
            var userExist = false;
            try
            {
                var allUsers = _db.Contacts;
                if (allUsers.Any(n => n.Email == email))
                    userExist = true;
            }
            catch (Exception)
            {
                // ignored
            }
            return userExist;
        }
        /// <summary>
        ///     This method checks if a user exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckIfGeneralUserExist(string email)
        {
            var userExist = false;
            try
            {
                var allUsers = _db.Contacts;
                if (allUsers.Any(n => n.Email == email))
                    userExist = true;
            }
            catch (Exception)
            {
                // ignored
            }
            return userExist;
        }

        /// <summary>
        ///     This method is used to retrieve a user by user email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Contact GetAppUserByEmail(string email)
        {
            email = email.Trim();
            var appUser = _db.Contacts.Single(n => n.Email == email);
            return appUser;
        }

        /// <summary>
        ///     This method retrives a user by an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetAppUserById(int id)
        {
            var appUser = _db.Contacts.Find(id);
            return appUser;
        }
    }
}
