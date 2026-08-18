// HOW-TO: Convert BMP to JPEG with Adjustable Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.jpg";

            // Configurable JPEG quality (1-100)
            int jpegQuality = 85;

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set JPEG save options, including quality
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = jpegQuality
                };

                // Save the image as JPEG
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
 * 1. When you need to shrink large BMP files for faster web page loading by converting them to JPEG with a specific compression quality.
 * 2. When migrating legacy BMP assets to a modern format for compatibility with browsers and mobile devices while controlling image fidelity.
 * 3. When generating email attachments in C# and want to reduce attachment size by saving BMP screenshots as JPEG with a chosen quality level.
 * 4. When building an automated image processing pipeline that requires consistent JPEG output from BMP sources for downstream analytics or machine‑learning models.
 * 5. When preparing print‑ready images in a .NET application and must balance file size and visual quality by setting the JPEG quality parameter during conversion.
 */
