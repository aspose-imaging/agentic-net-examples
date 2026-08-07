using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Ensure there is at least one page
                if (cdrImage.PageCount == 0)
                {
                    Console.Error.WriteLine("The CDR file contains no pages.");
                    return;
                }

                // Get the first page (single‑page document)
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                // Prepare PNG save options with rasterization settings to preserve transparency
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent, // preserve transparency
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    }
                };

                // Save the page as PNG
                page.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to embed a single‑page CorelDRAW (CDR) illustration into a web page and requires a transparent PNG, they can use this C# Aspose.Imaging code to convert the file while keeping the alpha channel intact.
 * 2. When an e‑commerce platform automatically generates product thumbnails from supplier‑provided CDR logos, this snippet converts each single‑page CDR to a PNG with transparent background for seamless overlay on product images.
 * 3. When a document‑management system must archive legacy CDR artwork as lossless PNG files for long‑term storage, developers can employ the code to rasterize the page and preserve transparency in .NET applications.
 * 4. When a mobile app needs to display a CorelDRAW icon on various UI themes, the C# routine converts the single‑page CDR to a transparent PNG that can be tinted or blended without visual artifacts.
 * 5. When a batch‑processing service extracts vector graphics from CDR files for printing proofs and requires PNG output with exact page dimensions and transparent background, this Aspose.Imaging example provides the needed conversion logic.
 */