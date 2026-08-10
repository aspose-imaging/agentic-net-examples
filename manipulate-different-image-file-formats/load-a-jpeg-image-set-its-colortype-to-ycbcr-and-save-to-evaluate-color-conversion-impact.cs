// HOW-TO: Convert JPEG to YCbCr Color Space Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_ycbcr.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options with YCbCr color type
                JpegOptions saveOptions = new JpegOptions
                {
                    ColorType = JpegCompressionColorMode.YCbCr
                };

                // Save the image with the specified options
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to ensure a JPEG is stored in the YCbCr color space for better compression compatibility with web browsers.
 * 2. When you want to compare visual quality between default RGB JPEGs and YCbCr‑converted versions in a .NET image‑processing pipeline.
 * 3. When preparing images for a printing workflow that requires YCbCr color encoding to match printer color profiles.
 * 4. When performing automated batch processing that standardizes all JPEGs to YCbCr before uploading to a content‑delivery network.
 * 5. When debugging color‑conversion issues by saving a JPEG with explicit YCbCr settings to verify Aspose.Imaging’s handling.
 */
