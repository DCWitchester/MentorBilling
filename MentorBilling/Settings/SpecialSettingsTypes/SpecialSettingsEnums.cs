﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings.SpecialSettingsTypes
{
    public class SpecialSettingsEnums
    {
        /// <summary>
        /// the CountryISOType bound to the Settings
        /// </summary>
        public enum CountryISOType
        {
            ISO2 = 0,
            ISO3 = 1,
            ISOM49
        }
        /// <summary>
        /// the CountryName bound to the Settings
        /// </summary>
        public enum CountryName
        {
            RO = 0,
            EN = 1
        }

        /// <summary>
        /// the database settings link
        /// </summary>
        public enum DatabaseSettingsLink 
        {
            UseSellerControl = 0,
            CountryISO = 1,
            CountryName = 2,
            UseBuyerControl = 3,
            AutogenerateDocumentNumber = 4,
            AutogenerateDocumentSeries = 5,
            AutogenerateNoticeNumber = 6,
            PermitInvoicesOutsideCurrentMonth = 7,
            PermitInvoiceInMonthsPrior = 8,
            PermitInvoiceInMonthsFollowing = 9,
            NumberOfMonthsPrior = 10,
            NumberOfMonthsFollowing = 11,
            UseProductsControl = 12,
            SearchByProductCode = 13,
            UseBarcode = 14,
            BarcodeType = 15,
            DefaultVATRate = 16
        }

        /// <summary>
        /// the enum containing the EAN Codes liKed to the prodcut scanner code settings
        /// </summary>
        public enum EANCodes
        {
            EAN8 = 0,
            EAN13 = 1
        }
    }
}
