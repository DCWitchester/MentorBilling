using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using System;
using System.Collections.Generic;
using MentorBilling.ObjectStructures;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.EntityFramework.DatabaseLink.Seller
{
    public class BankFunctions : MentorBillingContext
    {
        #region Select Functions
        /// <summary>
        /// this function will retrieve the complete list of viable bank accounts for a given seller
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <returns>the valid bank account list</returns>
        public List<BankAccount> GetBankAccountsForSeller(ObjectStructures.Invoice.Seller seller)
        {
            return base.ConturiBancareFurnizori.Where(element => element.FurnizorId == seller.ID && (element.Activ ?? false))
                            .Select(element => new BankAccount
                            {
                                ID = element.Id,
                                Bank = element.Banca,
                                Account = element.Cont
                            }).ToList();
        }

        /// <summary>
        /// this function will retrieve the last used bank account for the given user
        /// </summary>
        /// <param name="user">the last used bank Account</param>
        /// <returns>the last used Bank Account</returns>
        public BankAccount GetLastUsedBank(Login.UserControllers.User user)
        {
            List<BankAccount> bankAccounts = (from cbf in base.ConturiBancareFurnizori
                                              join ulu in UtilizatoriLastUsed on cbf.Id equals ulu.ConturiBancareLastUsed
                                              where ulu.UtilizatorId == user.ID && (ulu.Activ ?? false)
                                              select new BankAccount
                                              {
                                                  ID = cbf.Id,
                                                  Bank = cbf.Banca,
                                                  Account = cbf.Cont
                                              }).ToList();
            return bankAccounts.FirstOrDefault();
        }
        #endregion

        #region Insert Functions
        /// <summary>
        /// this function will add a bew bank account for the given seller to the database
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccount">the new bank account</param>
        public void AddNewBankAccountForSeller(ObjectStructures.Invoice.Seller seller, BankAccount bankAccount)
        {
            #region ActionLog
            //we generate the log action
            String LogAction = $"Adaugat un nou cont bancar la banca {bankAccount.Bank} pentru societatea {seller.Name}";
            //and the log command
            String LogCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    $"VALUES({seller.ID}, {bankAccount.Account}, {bankAccount.Bank}) " +
                                    "ON CONFLICT(cont) " +
                                    $"DO UPDATE SET banca= {bankAccount.Bank} RETURNING id";
            //before retriving the ip
            String IP = Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            ConturiBancareFurnizori contBancarFurnizor = new ConturiBancareFurnizori
            {
                FurnizorId = seller.ID,
                Cont = bankAccount.Account,
                Banca = bankAccount.Bank
            };
            base.ConturiBancareFurnizori.Add(contBancarFurnizor);
            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            base.SaveChanges();
            bankAccount.ID = contBancarFurnizor.Id;
        }

        /// <summary>
        /// this function will add a bew bank account for the given seller to the database
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccount">the new bank account</param>
        void AddNewBankAccountForSellerWithoutSave(ObjectStructures.Invoice.Seller seller, BankAccount bankAccount)
        {
            #region ActionLog
            //we generate the log action
            String LogAction = $"Adaugat un nou cont bancar la banca {bankAccount.Bank} pentru societatea {seller.Name}";
            //and the log command
            String LogCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    $"VALUES({seller.ID}, {bankAccount.Account}, {bankAccount.Bank}) " +
                                    "ON CONFLICT(cont) " +
                                    $"DO UPDATE SET banca= {bankAccount.Bank} RETURNING id";
            //before retriving the ip
            String IP = Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            ConturiBancareFurnizori contBancarFurnizor = new ConturiBancareFurnizori
            {
                FurnizorId = seller.ID,
                Cont = bankAccount.Account,
                Banca = bankAccount.Bank
            };
            base.ConturiBancareFurnizori.Add(contBancarFurnizor);
            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            bankAccount.ID = contBancarFurnizor.Id;
        }

        /// <summary>
        /// this function will add an entire list of bank accounts to the given seller
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccounts">the list of bank account</param>
        public void AddBankAccountsForSeller(ObjectStructures.Invoice.Seller seller, List<BankAccount> bankAccounts)
        {
            foreach (var element in bankAccounts) AddNewBankAccountForSellerWithoutSave(seller, element);
            base.SaveChanges();
        }
        #endregion

        #region Update Functions

        /// <summary>
        /// this function will update a givent bank account based on the ID
        /// </summary>
        /// <param name="bankAccount">the bank account</param>
        public void UpdateBankAccountByID(BankAccount bankAccount)
        {
            #region ActionLog
            //we initialy generate the action log and command
            String LogAction = $"S-a actualizat contul bancar cu ID: {bankAccount.ID}";
            String LogCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    $"SET cont = {bankAccount.Account}, banca = {bankAccount.Bank} " +
                                    $"WHERE id = {bankAccount.ID}";
            //before retrieving the ip of the current instance
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            ConturiBancareFurnizori contBancarFurnizor = base.ConturiBancareFurnizori.Find(bankAccount.ID);

            contBancarFurnizor.Banca = bankAccount.Bank;
            contBancarFurnizor.Cont = bankAccount.Account;
            contBancarFurnizor.Activ = true;

            base.Update(contBancarFurnizor);
            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            base.SaveChanges();
        }

        /// <summary>
        /// this function will update a bank account 
        /// </summary>
        /// <param name="bankAccount">the given bank account</param>
        public void UpdateBankAccountByAccount(BankAccount bankAccount)
        {
            #region ActionLog
            //we initialy generate the action log and command
            String LogAction = $"S-a actualizat contul bancar cu ID: {bankAccount.ID}";
            String LogCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    $"SET banca = {bankAccount.Bank} " +
                                    $"WHERE cont = {bankAccount.Account}";
            //before retrieving the ip of the current instance
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            ConturiBancareFurnizori contBancarFurnizor = base.ConturiBancareFurnizori.Where(element => element.Cont == bankAccount.Account).FirstOrDefault();

            contBancarFurnizor.Banca = bankAccount.Bank;
            contBancarFurnizor.Cont = bankAccount.Account;
            contBancarFurnizor.Activ = true;

            base.Update(contBancarFurnizor);
            base.LogActiuni.Add(ActionLog.LogAction(LogAction, IP, LogCommand));
            base.SaveChanges();
        }
        #endregion
    }
}
