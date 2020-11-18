﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorBilling.Settings.SpecialSettingsTypes;
using MentorBilling.SettingsComponents;

namespace MentorBilling.Settings
{
    /// <summary>
    /// this class will contain the global settings used by the program instance
    /// </summary>
    public class InstanceSettings : ProgramSettings
    {
        #region Settings
        /// <summary>
        /// the SellerControl for the instance
        /// </summary>
        public Boolean SellerControl 
        { 
            get => base.useSellerControl;
            set => base.useSellerControl = value; 
        }
        /// <summary>
        /// the useBuyerControl for the instance
        /// </summary>
        protected Boolean UseBuyerControl 
        { 
            get => base.useBuyerControl;
            set => base.useBuyerControl = value; 
        }
        /// <summary>
        /// the countryISO for the instance
        /// </summary>
        public SpecialSettingsEnums.CountryISOType CountryISO 
        {
            get => base.countryISO;
            set => base.countryISO = value;
        }
        /// <summary>
        /// the countryName for the instance
        /// </summary>
        public SpecialSettingsEnums.CountryName CountryName 
        {
            get => base.countryName;
            set => base.countryName = value;
        }
        /// <summary>
        /// the autogeneration of the Document Number for the instance
        /// </summary>
        public Boolean AutogenerateDocumentNumber
        {
            get => base.autogenerateDocumentNumber;
            set => base.autogenerateDocumentNumber = value;
        }
        /// <summary>
        /// the autogeneration of the Document Series for the instance
        /// </summary>
        public Boolean AutogenerateDocumentSeries
        {
            get => base.autogenerateDocumentSeries;
            set => base.autogenerateDocumentSeries = value;
        }
        /// <summary>
        /// the autogeneration of the Document Series for the instance
        /// </summary>
        public Boolean AutogenerateNoticeNumber
        {
            get => base.autogenerateNoticeNumber;
            set => base.autogenerateNoticeNumber = value;
        }
        /// <summary>
        /// the setting for permitting the creation of invoices outside of the current month for the instance
        /// </summary>
        public Boolean PermitInvoicesOutsideCurrentMonth
        {
            get => base.permitInvoicesOutsideCurrentMonth;
            set => base.permitInvoicesOutsideCurrentMonth = value;
        }
        /// <summary>
        /// the setting for permitting the creation of invoices in the months prior to the current month for the instance
        /// </summary>
        public Boolean PermitInvoiceInMonthsPrior 
        {
            get => base.permitInvoiceInMonthsPrior;
            set => base.permitInvoiceInMonthsPrior = value;
        }
        /// <summary>
        /// the setting for permitting the creation of invoices in the months following to the current month for the instance
        /// </summary>
        public Boolean PermitInvoiceInMonthsFollowing
        {
            get => base.permitInvoiceInMonthsFollowing; 
            set => base.permitInvoiceInMonthsFollowing = value;
        }
        /// <summary>
        /// the maximum number of prior months in which it is permited to create invoices
        /// </summary>
        public Int32 NumberOfMonthsPrior
        {
            get => base.numberOfMonthsPrior;
            set => base.numberOfMonthsPrior = value;
        }
        /// <summary>
        /// the maximum number of following months in which it is permited to create invoices
        /// </summary>
        public Int32 NumberOfMonthsFollowing
        {
            get => base.numberOfMonthsFollowing;
            set => base.numberOfMonthsFollowing = value;
        }
        /// <summary>
        /// the granting of product complete control to the user
        /// </summary>
        public Boolean UseProductControl
        {
            get => base.useProductControl;
            set => base.useProductControl = value;
        }
        /// <summary>
        /// <br>activates the product by the code property</br>
        /// <br>the default search for the products is by name</br>
        /// </summary>
        public Boolean SearchProductsByCode
        {
            get => base.searchProductsByCode;
            set => base.searchProductsByCode = value;
        }
        /// <summary>
        /// <br> the usage of barcode scanners within the program </br>
        /// <br> used only in tandem with useProductControl </br>
        /// </summary>
        public Boolean UseBarcode
        {
            get => base.useBarcode; 
            set => base.useBarcode = value;

        }
        /// <summary>
        /// the ean code setting used by the instance
        /// </summary>
        public SpecialSettingsEnums.EANCodes EANCode
        {
            get => base.eanCode;
            set => base.eanCode = value;
        }
        #endregion

        #region Functionality
        //TODO: Link the Settings to the Database
        /// <summary>
        /// this function will consume the settings list and set the settings needed values
        /// </summary>
        /// <param name="settings">the complete settings list</param>
        public void ConsumeSettings(List<Setting> settings)
        {
            //we will iterate the settings list
            foreach(Setting setting in settings)
            {
                //we call a switch over the settings
                //and set the settings values
                switch (setting.ID)
                {
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.UseSellerControl:
                        this.SellerControl = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.CountryISO:
                        this.CountryISO = (SpecialSettingsEnums.CountryISOType)setting.GetIntegerValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.CountryName:
                        this.CountryName = (SpecialSettingsEnums.CountryName)setting.GetIntegerValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.UseBuyerControl:
                        this.useBuyerControl = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.AutogenerateDocumentNumber:
                        this.AutogenerateDocumentNumber = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.AutogenerateDocumentSeries:
                        this.AutogenerateDocumentSeries = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.AutogenerateNoticeNumber:
                        this.AutogenerateNoticeNumber = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.PermitInvoicesOutsideCurrentMonth:
                        this.PermitInvoicesOutsideCurrentMonth = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.PermitInvoiceInMonthsPrior:
                        this.PermitInvoiceInMonthsPrior = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.PermitInvoiceInMonthsFollowing:
                        this.PermitInvoiceInMonthsFollowing = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.NumberOfMonthsPrior:
                        this.NumberOfMonthsPrior = setting.GetIntegerValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.NumberOfMonthsFollowing:
                        this.NumberOfMonthsFollowing = setting.GetIntegerValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.UseProductsControl:
                        this.UseProductControl = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.SearchByProductCode:
                        this.SearchProductsByCode = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.UseBarcode:
                        this.UseBarcode = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.BarcodeType:
                        this.EANCode = (SpecialSettingsEnums.EANCodes)setting.GetIntegerValue;
                        break;
                }
            }
        }
        #endregion

    }
}
