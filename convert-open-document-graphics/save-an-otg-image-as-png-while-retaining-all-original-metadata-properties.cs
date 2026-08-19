// HOW-TO: Convert OTG Image to PNG with Metadata Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded relative input and output paths
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with metadata preservation
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                // Configure vector rasterization for OTG to PNG conversion
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save as PNG while retaining original metadata
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails from OTG vector drawings while keeping EXIF and custom metadata for downstream processing.
 * 2. When a web service must convert uploaded OTG files to PNG format for browser display without losing original author information.
 * 3. When archiving design assets, you want to store a lossless PNG copy of each OTG file while preserving all embedded metadata for future reference.
 * 4. When integrating a CAD workflow, you need to rasterize OTG pages to PNG at their original size and keep layer and property data intact.
 * 5. When building a batch conversion tool that reads OTG files from a folder and saves them as PNG files with all metadata retained for compliance reporting.
 */
