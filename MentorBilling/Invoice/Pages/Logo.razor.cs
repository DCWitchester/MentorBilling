using BlazorInputFile;
using MentorBilling.Invoice.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using MentorBilling.Miscellaneous;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace MentorBilling.Invoice.Pages
{
    public partial class Logo
    {
        /// <summary>
        /// the main page controller will be pased from the father component
        /// </summary>
        [Parameter]
        public LogoController PageController { get; set; }

        /// <summary>
        /// the default status for the display element
        /// </summary>
        const String DefaultStatus = "Faceti click sau trageti o imagine aici pentru a selecta o imagine";

#pragma warning disable CS0414
        /// <summary>
        /// the display element for the Drag N Drop element
        /// </summary>
        String Status = DefaultStatus;
#pragma warning restore

        /// <summary>
        /// the initial dimmension for the image
        /// </summary>
        Size ImageDimensions { get; set; }

        /// <summary>
        /// this will be the main function linked to the Drag N Drop on the
        /// </summary>
        /// <param name="files">the selected files</param>
        /// <returns>the current Task Thread</returns>
        async Task SelectLogo(IFileListEntry[] files) 
        {
            //we get the first and most likely only file from the list
            IFileListEntry file = files.FirstOrDefault();
            //if no file was selected we return
            if (file == null)
            {
                return;
            }
            else
            {
                //we set the loading status
                Status = "Se incarca...";
                //then using the fileReader
                //we need the component dimmension for the div to format the image to the correct sizes
                ImageDimensions = await JSRuntime.InvokeAsync<Size>("getElementSize", "InputFile");

                //we retrieve the image info
                //if we have the settings to mantain aspect ratio we need to reformat the image
                //we initialize a new ImageFile
                IFileListEntry ImageFile;
                if (PageController.MaintainAspectRatio)
                {
                    //we get the image file from the reformated image
                    ImageFile = await file.ToImageFileAsync(PageController.ImageFormat, ImageDimensions.Width, ImageDimensions.Height);
                }
                else 
                { 
                    //we get the image file from the file directly
                    ImageFile = file; 
                }

                //we initialize a new memory stream
                MemoryStream ms = new MemoryStream();
                //get all the data from the Image file into the memeory stream
                ImageFile.Data.CopyTo(ms);
                //then dump the stream into a bite array and set it to the PageControllers LogoBaseProperty
                PageController.LogoBase = ms.ToArray();
                //we also set the status back to the default value
                Status = DefaultStatus;
            }
        }

        /// <summary>
        /// this function will reset the LogoBase to deselect the image
        /// </summary>
        void ResetSelected()
        {
            PageController.LogoBase = null;
        }
    }
}
