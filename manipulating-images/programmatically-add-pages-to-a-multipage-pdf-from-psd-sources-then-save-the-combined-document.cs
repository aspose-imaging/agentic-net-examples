using System;
using System.Collections.Generic;
using System.IO;
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

            // Hardcoded output PDF file
            string outputPath = @"C:\Output\combined.pdf";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PSD images
            List<Image> loadedImages = new List<Image>();
            foreach (string inputPath in inputPaths)
            {
                loadedImages.Add(Image.Load(inputPath));
            }

            // Create a multipage image from the loaded PSDs and dispose the source images afterwards
            using (Image multipageImage = Image.Create(loadedImages.ToArray(), true))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the combined document as PDF
                multipageImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a designer needs to bundle multiple Photoshop PSD layers or artboards into a single PDF portfolio for client review, a developer can use this code to load each PSD, create a multipage image, and export it as a combined PDF.
 * 2. When an automated publishing pipeline must convert a series of PSD mock‑ups into a printable PDF booklet, the code programmatically assembles the PSD files into a multipage PDF using Aspose.Imaging for .NET.
 * 3. When a web service generates custom marketing collateral by merging several PSD templates into one PDF brochure, developers can employ this snippet to load the PSDs, create a multipage image, and save the final PDF.
 * 4. When a batch‑processing tool needs to archive design assets by converting a folder of PSD files into a single searchable PDF document, the example shows how to verify file existence, load the images, and combine them with C#.
 * 5. When an enterprise workflow requires converting PSD source files into a multipage PDF for compliance documentation, this code demonstrates how to use Image.Create and PdfOptions in Aspose.Imaging to produce the combined PDF automatically.
 */