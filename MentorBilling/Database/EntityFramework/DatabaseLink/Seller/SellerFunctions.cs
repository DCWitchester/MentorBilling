using MentorBilling.Login.UserControllers;
using System.Collections.Generic;
using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using System.Linq;
using MentorBilling.ObjectStructures.Auxilliary;
using System;

namespace MentorBilling.Database.EntityFramework.DatabaseLink.Seller
{
    public class SellerFunctions : MentorBillingContext
    {

        #region Select Functions
        /// <summary>
        /// this function will get a complete list of sellers for the given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>a list of sellers</returns>
        public List<ObjectStructures.Invoice.Seller> GetSellersForUser(User user)
        {
            return base.Furnizori.Where(element => element.UtilizatorId == user.ID && (element.Activ ?? false))
                                    .Select(element => new ObjectStructures.Invoice.Seller
                                    {
                                        ID = element.Id,
                                        Name = element.Denumire,
                                        CommercialRegistryNumber = element.NrRegistruComert,
                                        FiscalCode = element.CodFiscal,
                                        Headquarters = element.Sediul,
                                        WorkPoint = element.PunctLucru,
                                        Phone = element.Telefon,
                                        Email = element.Email,
                                        Logo = new Logo(element.Sigla)
                                    }).ToList();
        }

        /// <summary>
        /// this function will retrieve the logo of a given seller
        /// </summary>
        /// <param name="seller">the logo</param>
        /// <returns>the logo object</returns>
        public Logo GetLogoOfSeller(ObjectStructures.Invoice.Seller seller)
        {
            return new Logo(base.Furnizori.Find(seller.ID).Sigla);
        }

        /// <summary>
        /// this function will retrieve a seller by a given id
        /// </summary>
        /// <param name="id">the given id</param>
        /// <returns>the seller retrived from the database</returns>
        public ObjectStructures.Invoice.Seller GetSellerByID(Int32 id)
        {
            return base.Furnizori.Where(element => element.Id == id &&(element.Activ ?? false))
                .Select(element =>
                 new ObjectStructures.Invoice.Seller
                 {
                    ID = element.Id,
                    Name = element.Denumire,
                    CommercialRegistryNumber = element.NrRegistruComert,
                    FiscalCode = element.CodFiscal,
                    WorkPoint = element.PunctLucru,
                    Phone = element.Telefon,
                    Email = element.Email,
                    Logo = new Logo(element.Sigla)
                 }).FirstOrDefault();
        }

        /// <summary>
        /// this function will retrieve a seller by a given fiscal code
        /// </summary>
        /// <param name="fiscalCode">the given fiscal code</param>
        /// <returns>the seller retrieved from the database</returns>
        public ObjectStructures.Invoice.Seller GetSellerByFiscalCode(String fiscalCode)
        {
            return base.Furnizori.Where(element => element.CodFiscal == fiscalCode && (element.Activ ?? false))
                            .Select(element =>
                             new ObjectStructures.Invoice.Seller
                             {
                                 ID = element.Id,
                                 Name = element.Denumire,
                                 CommercialRegistryNumber = element.NrRegistruComert,
                                 FiscalCode = element.CodFiscal,
                                 WorkPoint = element.PunctLucru,
                                 Phone = element.Telefon,
                                 Email = element.Email,
                                 Logo = new Logo(element.Sigla)
                             }).FirstOrDefault();
        }

        public ObjectStructures.Invoice.Seller GetLastUsedSeller(User user)
        {

        }
        #endregion
    }
}
