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

        /// <summary>
        /// this function will retrieve the last seller used by the current user
        /// </summary>
        /// <param name="user">the current user</param>
        /// <returns>the last used seller object</returns>
        public ObjectStructures.Invoice.Seller GetLastUsedSeller(User user)
        {
            return (from u in base.UtilizatoriLastUsed
                    join f in base.Furnizori
                    on u.FurnizoriLastUsed equals f.Id
                    where u.UtilizatorId == user.ID && (u.Activ ?? false)
                    select new ObjectStructures.Invoice.Seller
                    {
                        ID = f.Id,
                        Name = f.Denumire,
                        CommercialRegistryNumber = f.NrRegistruComert,
                        FiscalCode = f.CodFiscal,
                        Headquarters = f.Sediul,
                        WorkPoint = f.PunctLucru,
                        Phone = f.Telefon,
                        Email = f.Email,
                        Logo = new Logo(f.Sigla)
                    }).FirstOrDefault();
        }

        /// <summary>
        /// this function will update the given seller from the context based on its id value
        /// </summary>
        /// <param name="seller">the given seller</param>
        public void UpdateLocalSellerByID(ObjectStructures.Invoice.Seller seller)
        {
            seller.ConsumeDatabaseObject(base.Furnizori.Find(seller.ID));
        }

        /// <summary>
        /// this function will update the given seller from the context based on its fiscal code value
        /// </summary>
        /// <param name="seller">the given seller</param>
        public void UpdateLocalSellerByFiscalCode(ObjectStructures.Invoice.Seller seller)
        {
            seller.ConsumeDatabaseObject(base.Furnizori.Where(element => element.CodFiscal == seller.FiscalCode).ToList().FirstOrDefault());
        }
        #endregion

        #region Insert Functions 
        /// <summary>
        /// this function will add a new seller to the database and link it to the given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="seller">the new seller</param>
        public void AddSellerToUser(User user, ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            //the log action will contain an explanation of the command
            String LogAction = $"S-a adaugat o noua firma cu denumirea {seller.Name} pentru utilizatorul {user.ID}";
            //the formatted log command
            String LogCommand = "INSERT INTO seller.furnizori(denumire,nr_registru_comert,cod_fiscal,capital_social,sediul,punct_lucru,telefon,email,utilizator_id) " +
                                    $"VALUES({seller.Name},{seller.CommercialRegistryNumber},{seller.FiscalCode},{seller.JointStock},{seller.Headquarters},{seller.WorkPoint},{seller.Phone},{seller.Email},{user.ID}) " +
                                    "ON CONFLICT(cod_fiscal) " +
                                    $"DO UPDATE SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                        $"utilizator_id = {user.ID} " +
                                    "RETURNING id";
            //the instance IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            //we generate a new object over furnizor
            var furnizor = new Furnizori
            {
                Denumire = seller.Name,
                NrRegistruComert = seller.CommercialRegistryNumber,
                CodFiscal = seller.FiscalCode,
                CapitalSocial = seller.JointStock,
                Sediul = seller.Headquarters,
                PunctLucru = seller.WorkPoint,
                Telefon = seller.Phone,
                Email = seller.Email,
                Sigla = seller.Logo.LogoBase
            };
            //add it to the context
            base.Furnizori.Add(furnizor);

            //set the newly linked id back to the seller object
            seller.ID = furnizor.Id;

            //we also log the action
            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));

            //and save the context changes
            base.SaveChanges();
        }
        #endregion

        #region Update Functions
        /// <summary>
        /// update the seller with the given logo
        /// </summary>
        /// <param name="logo">the given logo</param>
        /// <param name="seller">the seller</param>
        public void AddLogoToSeller(Logo logo, ObjectStructures.Invoice.Seller seller)
        {
            #region Action Log
            //the log action detailing the event
            String LogAction = $"S-a adaugat/modificat logo-ul la societatea cu denumirea {seller.Name}";
            //the query formatted command
            String LogCommand = $"UPDATE seller.furnizori SET sigla = {logo.LogoBase.Take(10)} WHERE id = {seller.ID}";
            //the IP of the user instance
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            var furnizor = base.Furnizori.Find(seller.ID);
            furnizor.Sigla = seller.Logo.LogoBase;

            base.Update(furnizor);

            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            base.SaveChanges();
        }

        /// <summary>
        /// update a given seller by id
        /// </summary>
        /// <param name="seller">the given seller</param>
        public void UpdateSellerByID(ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            //the log action detailing the event
            String LogAction = $"S-au actualizat datele societatii cu denumirea {seller.Name}";
            //the formatted log command
            //for safety reasons it does not contain the image
            String LogCommand = "UPDATE seller.furnizori " +
                                    $"SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                      $"WHERE id = {seller.ID}";
            //the ip of the instance user
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            Furnizori furnizor = base.Furnizori.Find(seller.ID);
            seller.DumpIntoDatabaseObject(furnizor);

            base.Update(furnizor);

            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            base.SaveChanges();
        }

        /// <summary>
        /// update a given seller by its fiscal code
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="user">the logged in user for the instance</param>
        public void UpdateSellerByFiscalCode(ObjectStructures.Invoice.Seller seller, User user)
        {
            #region ActionLog
            //the log action detailing the command
            String LogAction = $"S-au actualizat datele societatii cu denumirea {seller.Name}";
            //the formatted query command
            String LogCommand = "UPDATE seller.furnizori " +
                                    $"SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                      $"WHERE cod_fiscal = {seller.FiscalCode}";
            //the instance ip adress
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            Furnizori furnizor = base.Furnizori.Where(element => element.CodFiscal == seller.FiscalCode && element.UtilizatorId  == user.ID).FirstOrDefault();
            seller.DumpIntoDatabaseObject(furnizor);

            base.Update(furnizor);

            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            base.SaveChanges();
        }
        #endregion
    }

}