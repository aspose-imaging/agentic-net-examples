using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.adjusted.png";

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

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access AdjustBrightness
                TiffImage tiffImage = (TiffImage)image;

                // Increase brightness by 20 units (range -255 to 255)
                tiffImage.AdjustBrightness(20);

                // Save the adjusted image as PNG
                PngOptions pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to preprocess scanned TIFF documents that are too dark before converting them to PNG for web display, they can use this code to boost brightness by 20 units and save the result.
 * 2. When an automated batch job must normalize the lighting of archival TIFF photographs and output them as PNG thumbnails, the AdjustBrightness method with a +20 offset provides a quick fix.
 * 3. When integrating a C# application that ingests medical imaging TIFF files and presents them in a PNG viewer, increasing brightness ensures better visibility for clinicians.
 * 4. When a document management system requires converting user‑uploaded TIFF scans to PNG while correcting underexposed images, this snippet adjusts brightness and performs the format conversion in one step.
 * 5. When building a .NET service that extracts TIFF images from PDFs, enhances their contrast by raising brightness, and stores the enhanced images as PNG for downstream AI analysis, this code fulfills the requirement.
 */