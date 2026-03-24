using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] jpgPaths = {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg"
        };

        // Corresponding temporary PSD files
        string[] psdPaths = {
            @"C:\Temp\image1.psd",
            @"C:\Temp\image2.psd"
        };

        // Hardcoded output PDF file
        string outputPdf = @"C:\Result\combined.pdf";

        // Convert each JPG to PSD
        for (int i = 0; i < jpgPaths.Length; i++)
        {
            string inputPath = jpgPaths[i];
            string psdPath = psdPaths[i];

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(psdPath));

            using (Image jpgImage = Image.Load(inputPath))
            {
                // Set up PSD options (default settings)
                PsdOptions psdOptions = new PsdOptions();

                // Save as PSD
                jpgImage.Save(psdPath, psdOptions);
            }
        }

        // Load all PSD images
        List<Image> psdImages = new List<Image>();
        foreach (string psdPath in psdPaths)
        {
            if (!File.Exists(psdPath))
            {
                Console.Error.WriteLine($"File not found: {psdPath}");
                return;
            }

            Image psdImage = Image.Load(psdPath);
            psdImages.Add(psdImage);
        }

        // Create a multipage image from the PSDs and dispose the source images after creation
        using (Image multipage = Image.Create(psdImages.ToArray(), true))
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

            // PDF options (default settings)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            multipage.Save(outputPdf, pdfOptions);
        }
    }
}