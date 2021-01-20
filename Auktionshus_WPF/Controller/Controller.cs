using Auktionshus_WPF.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktionshus_WPF
{
    public class Controller
    {
        public static void CreateAccount(string name, string phone, string email, string username, string password)
        {
            var context = new AuktionDatabaseEntities();
            Account account = new Account
            {
                Name = name,
                Phone = phone,
                Email = email,
                Username = username,
                Password = password
            };
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public static Account FindAccount(string username, string password)
        {
            var context = new AuktionDatabaseEntities();
            Account account = context.Accounts.Where(a => a.Username.Equals(username) && a.Password.Equals(password)).FirstOrDefault();
            return account;
        }

        public static List<SalesOffer> GetSalesOffers()
        {
            List<SalesOffer> salesoffer;
            using (var context = new AuktionDatabaseEntities())
            {
                salesoffer = context.SalesOffers.ToList();
            }
            return salesoffer;
        }

        public static void CreatePurchaseOffer(Account account, SalesOffer salesoffer, string amount)
        {
            var context = new AuktionDatabaseEntities();
            var po = new PurchaseOffer { Amount = amount, SalesOfferId = salesoffer.Id, AccountId = account.Id };
            context.PurchaseOffers.Add(po);
            context.SaveChanges();
        }

        public static List<PurchaseOffer> GetPurchaseOffersById(SalesOffer salesoffer)
        {
            var context = new AuktionDatabaseEntities();
            var query = from x in context.PurchaseOffers
                       where x.SalesOfferId == salesoffer.Id
                       select x;

            List<PurchaseOffer> list = new List<PurchaseOffer>(query);
            return list;
        }
    }
}
