// HOW-TO: Convert Multiple OTG Files To PDF Concurrently Using C# Parallel.ForEach (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of OTG files to convert
            string[] inputPaths = new string[]
            {
                @"C:\Images\Sample1.otg",
                @"C:\Images\Sample2.otg",
                @"C:\Images\Sample3.otg"
            };

            // Process files in parallel
            Parallel.ForEach(inputPaths, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = inputPath + ".pdf";

                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir);

                // Load the OTG image and convert to PDF
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options
                    OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Set up PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a batch of OTG vector graphics must be turned into PDFs quickly for archiving or sharing.
 * 2. When a server‑side service needs to process many OTG design files in parallel to meet performance SLAs.
 * 3. When an automated build pipeline generates PDF documentation from OTG assets without blocking other tasks.
 * 4. When a desktop application lets users select multiple OTG images and export them as PDFs in a single operation.
 * 5. When a cloud function converts incoming OTG uploads to PDF format while scaling across multiple CPU cores.
 */
