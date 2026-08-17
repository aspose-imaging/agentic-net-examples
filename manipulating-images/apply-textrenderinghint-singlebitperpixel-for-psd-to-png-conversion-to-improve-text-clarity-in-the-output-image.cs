// HOW-TO: Convert PSD to PNG with SingleBitPerPixel Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "C:\\Images\\input.psd";
            string outputPath = "C:\\Images\\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with SingleBitPerPixel text rendering
                var rasterOptions = new VectorRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                };

                // Set PNG options to use the rasterization options
                var pngOptions = new PngOptions
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
 * 1. When you need to export layered Photoshop files to PNG while preserving crisp vector text for web thumbnails.
 * 2. When generating product catalog images from PSD designs and require sharp, readable labels in the PNG output.
 * 3. When automating batch conversion of PSD assets to PNG for a mobile app and want to avoid blurry text rendering.
 * 4. When creating printable marketing materials from PSD sources and need high‑contrast text in the final PNG files.
 * 5. When integrating Aspose.Imaging into a C# service that converts user‑uploaded PSD files to PNG and must maintain text legibility for accessibility compliance.
 */
