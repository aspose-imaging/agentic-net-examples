// HOW-TO: Batch Convert CDR Files to 800x600 PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = new string[]
            {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\Converted";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Cache the whole document and its pages
                    cdrImage.CacheData();
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        page.CacheData();
                    }

                    // Use the first page for conversion
                    CdrImagePage firstPage = (CdrImagePage)cdrImage.Pages[0];

                    // Resize to 800x600
                    firstPage.Resize(800, 600);

                    // Save as PNG
                    firstPage.Save(outputPath, new PngOptions());
                }
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
 * 1. When you need to generate web‑ready thumbnails from a collection of CorelDRAW (CDR) designs for an online portfolio.
 * 2. When an e‑commerce platform must batch‑process product illustrations stored as CDR files into PNGs of a fixed 800×600 size for display on product pages.
 * 3. When a printing service automates the conversion of client‑submitted CDR artwork into PNG previews that fit a standard preview window.
 * 4. When a desktop application migrates legacy CDR assets to PNG format while ensuring each image matches a specific resolution for a digital catalog.
 * 5. When a CI/CD pipeline validates and resizes multiple CDR source files to PNGs before they are uploaded to a content management system.
 */
