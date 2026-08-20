// HOW-TO: Convert ODG to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options to keep transparent background
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = image.Size
                };

                // Set PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PNG
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
 * 1. When a developer needs to display OpenDocument graphics on a website and must preserve the image’s alpha channel, they can use this code to convert ODG files to PNG with transparency.
 * 2. When integrating a document‑to‑image pipeline that receives ODG drawings from LibreOffice and requires PNG assets for mobile apps, this snippet ensures the background stays clear.
 * 3. When automating batch processing of design assets stored as ODG and the output must be lossless PNGs for UI mockups, the code provides reliable conversion while keeping transparent regions.
 * 4. When creating a reporting tool that embeds vector illustrations from ODG into PDF or HTML reports as PNG thumbnails, developers can rely on this example to maintain the original transparency.
 * 5. When building a content‑management system that accepts user‑uploaded ODG files and needs to generate web‑ready PNG previews without a solid background, this code handles the conversion correctly.
 */
