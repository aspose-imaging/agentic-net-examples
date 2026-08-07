using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = new string[]
            {
                @"C:\Images\page1.psd",
                @"C:\Images\page2.psd",
                @"C:\Images\page3.psd"
            };

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load each PSD as a RasterImage
            List<RasterImage> rasterImages = new List<RasterImage>();
            foreach (string inputPath in inputPaths)
            {
                // Load the PSD image
                RasterImage img = (RasterImage)Image.Load(inputPath);
                rasterImages.Add(img);
            }

            // Create a multipage image from the loaded pages.
            // The overload with disposeImages = true will dispose the source images after creation.
            Image multipageImage = Image.Create(rasterImages.ToArray(), true);

            // Hardcoded output PDF path
            string outputPath = @"C:\Output\CombinedDocument.pdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPath, pdfOptions);

            // Dispose the multipage image
            multipageImage.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a graphic design studio needs to merge multiple Photoshop PSD files into a single PDF portfolio for client review.
 * 2. When an e‑learning platform converts layered PSD slides into a multipage PDF handbook for offline distribution.
 * 3. When a marketing team automates the creation of a print‑ready PDF brochure from separate PSD page assets using C# and Aspose.Imaging.
 * 4. When a document management system batches PSD artwork into a searchable PDF archive to simplify storage and retrieval.
 * 5. When a web service generates a combined PDF invoice that includes PSD‑based product images as individual pages.
 */