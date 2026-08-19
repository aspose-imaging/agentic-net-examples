// HOW-TO: Convert PNG to JPEG with Safe Disposal and Error Handling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.jpg";

        // Global exception handling
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

            Image image = null;
            try
            {
                // Load the source image
                image = Image.Load(inputPath);

                // Prepare JPEG save options (adjust quality as needed)
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the image in the desired format
                image.Save(outputPath, jpegOptions);
            }
            finally
            {
                // Ensure the image is disposed even if saving fails
                if (image != null)
                {
                    image.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert user‑uploaded PNG images to JPEG for web delivery while guaranteeing the image object is always released even if the save fails.
 * 2. When an automated service must generate thumbnail JPEGs from PNG sources and must handle missing files or directory creation errors gracefully.
 * 3. When integrating image conversion into a C# backend that must log errors without crashing the application and ensure resources are cleaned up.
 * 4. When processing images in a Windows service that converts scanned PNG files to compressed JPEGs with a specific quality setting and needs reliable disposal to avoid memory leaks.
 * 5. When building a command‑line tool that transforms PNG assets to JPEG for mobile apps, requiring robust exception handling and proper cleanup of the Aspose.Imaging Image instance.
 */
