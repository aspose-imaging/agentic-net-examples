// HOW-TO: Increase Brightness of TIFF Image by 20 and Save as PNG in C# (Aspose.Imaging for .NET)
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

                // Save the result as PNG
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
 * 1. When a medical imaging system receives low‑contrast TIFF scans and needs a brighter PNG version for web viewing.
 * 2. When a document management workflow converts scanned TIFF pages to PNG thumbnails and must boost visibility by adjusting brightness.
 * 3. When a batch script processes satellite TIFF imagery and requires a quick brightness increase before saving as PNG for GIS analysis.
 * 4. When an e‑commerce platform upgrades product photos from TIFF to PNG and wants to enhance brightness to match catalog standards.
 * 5. When a desktop application prepares archival TIFF files for presentation and needs to raise brightness by a fixed amount while converting to PNG.
 */
