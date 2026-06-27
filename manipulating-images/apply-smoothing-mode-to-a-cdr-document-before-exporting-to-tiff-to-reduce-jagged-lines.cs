using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.cdr";
        string outputPath = @"C:\temp\output.tif";

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

            // Load the CDR vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with smoothing (anti‑aliasing)
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    // Apply anti‑aliasing to reduce jagged lines
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                // Set up TIFF save options and attach the rasterization options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When converting CorelDRAW (.cdr) vector artwork to a high‑resolution TIFF for printing, a developer can use this code to enable anti‑aliasing and eliminate jagged edges.
 * 2. When generating archival TIFF files from CDR designs for legal or compliance purposes, applying SmoothingMode ensures the rasterized images retain smooth line quality.
 * 3. When integrating a C# application that creates TIFF previews of CDR logos for web catalogs, the code provides vector rasterization with anti‑aliasing to improve visual appearance.
 * 4. When automating batch conversion of multiple CDR files to TIFF in a Windows service, the smoothing option helps maintain consistent line smoothness across all output files.
 * 5. When developing a document management system that stores scanned‑like TIFF copies of CDR drawings, using this code guarantees the exported images have reduced pixelation and smoother curves.
 */