// HOW-TO: Resize BMP Image to Half Size Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output_resized.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Calculate half of the original dimensions
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize the image (default NearestNeighbourResample)
                image.Resize(newWidth, newHeight);

                // Save the resized image back as BMP
                image.Save(outputPath);
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
 * 1. When you need to generate smaller thumbnail versions of large BMP files for faster web page loading.
 * 2. When a desktop application must reduce the memory footprint of BMP assets before embedding them in a report.
 * 3. When an automated batch job processes scanned BMP documents and must halve their resolution to meet email attachment size limits.
 * 4. When a game developer wants to downscale high‑resolution BMP textures to improve rendering performance on low‑end devices.
 * 5. When a legacy system requires BMP images at exactly half their original width and height for compatibility with older hardware.
 */
