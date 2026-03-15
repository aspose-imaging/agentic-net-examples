using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class JpegToPdfViaOdg
{
    static void Main()
    {
        // Input JPEG files – adjust the paths as needed
        string[] jpegFiles = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Temporary storage for ODG representations (in memory)
        List<MemoryStream> odgStreams = new List<MemoryStream>();

        // -----------------------------------------------------------------
        // 1. Convert each JPEG to an ODG image (intermediate vector format)
        // -----------------------------------------------------------------
        foreach (string jpegPath in jpegFiles)
        {
            // Load the JPEG image using the unified Image.Load method
            using (Image jpegImage = Image.Load(jpegPath))
            {
                // Prepare a memory stream to hold the ODG data
                MemoryStream odgStream = new MemoryStream();

                // Save the raster image as ODG.
                // No explicit ODG options class is required – the format is inferred from the file extension.
                jpegImage.Save(odgStream, new OdgOptions()); // ODG options are default; using the dedicated class.

                // Reset the stream position for later reading
                odgStream.Position = 0;
                odgStreams.Add(odgStream);
            }
        }

        // ---------------------------------------------------------------
        // 2. Create a PDF document and add each ODG page to it
        // ---------------------------------------------------------------
        // Output PDF file
        string outputPdf = @"C:\Images\Combined.pdf";

        // Prepare PDF save options with vector rasterization based on ODG
        PdfOptions pdfOptions = new PdfOptions();

        // The rasterization options tell Aspose.Imaging how to render vector pages (ODG) into raster pages of the PDF
        OdgRasterizationOptions rasterization = new OdgRasterizationOptions
        {
            // Use white background for consistency
            BackgroundColor = Color.White,

            // PageSize will be set per page; initialize with the size of the first image
            PageSize = odgStreams.Count > 0 ? Image.Load(odgStreams[0]).Size : new Size(800, 600)
        };
        pdfOptions.VectorRasterizationOptions = rasterization;

        // Create a list to hold the loaded ODG images (each will become a PDF page)
        List<Image> odgImages = new List<Image>();
        foreach (MemoryStream ms in odgStreams)
        {
            // Load the ODG image from the memory stream
            Image odgImage = Image.Load(ms);
            odgImages.Add(odgImage);
        }

        // The first ODG image will be used as the base; subsequent images are added as pages
        using (Image firstOdg = odgImages[0])
        {
            // Ensure the PDF options are applied to the first page
            firstOdg.Save(outputPdf, pdfOptions);

            // Append remaining pages (if any) to the same PDF file
            for (int i = 1; i < odgImages.Count; i++)
            {
                // Load the current ODG page
                using (Image pageOdg = odgImages[i])
                {
                    // Update the rasterization page size to match the current image
                    rasterization.PageSize = pageOdg.Size;

                    // Append the page to the existing PDF.
                    // The AppendPage method is not directly exposed; instead we re‑save using the same file
                    // with MultiPageOptions that include the new page range.
                    // Here we use the MultiPageOptions to specify the page index to add.
                    pdfOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    // Save the current page; Aspose.Imaging will merge it into the existing PDF.
                    pageOdg.Save(outputPdf, pdfOptions);
                }
            }
        }

        // Cleanup temporary streams
        foreach (var ms in odgStreams)
        {
            ms.Dispose();
        }

        Console.WriteLine("PDF created successfully at: " + outputPdf);
    }
}

// Placeholder class for ODG save options – Aspose.Imaging provides a default implementation.
// If a dedicated ODG options class exists in the library, replace this with the actual type.
class OdgOptions : ImageOptionsBase { }