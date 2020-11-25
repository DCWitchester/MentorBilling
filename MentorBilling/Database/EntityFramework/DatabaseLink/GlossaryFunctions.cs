using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.ObjectStructures.Auxilliary;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MentorBilling.Database.EntityFramework.DatabaseLink
{
    public class GlossaryFunctions : MentorBillingContext
    {

        /// <summary>
        /// this function will retrive the bank name from the glossary tables based upon the given bank account
        /// </summary>
        /// <param name="bankAccountController">the bank account controller</param>
        public void GetBankOfAccount(BankAccountController bankAccountController)
        {
            bankAccountController.Bank = base.InstitutiiBancare
                                            .Where(element => 
                                                element.CodIban == Miscellaneous.BankFunctions.GetCodeFromIBAN(bankAccountController.Account))
                                            .FirstOrDefault().Denumire;
        }

        /// <summary>
        /// this function will retrieve the complete list of countries from the database glossary
        /// </summary>
        /// <returns>the country list</returns>
        public List<Country> GetCountries()
        {
            return base.Tari.Where(element => element.Activ ?? false).Select(element => new Country
            {
                ID = element.Id,
                CountryCodeISO2 = element.CodTaraIso2,
                CountryCodeISO3 = element.CodTaraIso3,
                CountryCodeM49 = element.CodTaraIsoM49,
                EnglishName = element.DenTaraEn,
                RomanianName = element.DenTaraRo
            }).ToList();
        }

        /// <summary>
        /// this function will retrieve the complete list countries from the database glossary
        /// </summary>
        /// <returns>the county list</returns>
        public List<County> GetCounties()
        {
            return base.Judete.Where(element => element.Activ ?? false).Select(element => new County
            {
                ID = element.Id,
                CountyCode = element.CodJudet,
                CountyName = element.DenJudet
            }).ToList();
        }

        /// <summary>
        /// this function will retrieve the complete list of VAT Rates from the database glossary
        /// </summary>
        /// <returns>the VAT list</returns>
        public List<VATRate> GetVatRates()
        {
            return base.CoteTva.Where(element => element.Activ ?? false).Select(element => new VATRate
            {
                ID = element.Id,
                CharID = element.Cota,
                VAT = (Int32)element.Tva,
                RegistryIndex = element.IndiceCasaMarcat,
                DisplayCode = element.Cod
            }).ToList();
        }
    }
}
