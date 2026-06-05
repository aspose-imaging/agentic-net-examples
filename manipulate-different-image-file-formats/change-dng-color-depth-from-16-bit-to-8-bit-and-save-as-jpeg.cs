using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\test.dng";
            string outputPath = @"c:\temp\test.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access DNG‑specific features if needed
                DngImage dngImage = (DngImage)image;

                // Save as JPEG (JPEG format is 8‑bit per channel, effectively reducing depth)
                JpegOptions jpegOptions = new JpegOptions();
                dngImage.Save(outputPath, jpegOptions);
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
 * 1. When a photographer needs to generate web‑ready thumbnails from high‑resolution 16‑bit DNG raw files by converting them to 8‑bit JPEGs for faster page loads.
 * 2. When a mobile app processes raw camera captures and must reduce file size by down‑sampling the color depth before uploading the image as a JPEG to a server.
 * 3. When an e‑commerce platform receives product photos in DNG format and must automatically convert them to 8‑bit JPEGs for display in product listings.
 * 4. When a digital archiving system needs to preserve original 16‑bit DNG files while creating 8‑bit JPEG previews for quick browsing in a .NET application.
 * 5. When a batch‑processing script in C# must validate that a DNG image exists, convert its 16‑bit color depth to 8‑bit, and save it as a JPEG for compatibility with legacy image viewers.
 */