using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.dng";
        string outputPath = @"c:\temp\output.png";

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

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access DNG‑specific properties
                DngImage dngImage = (DngImage)image;

                // Set background color to white
                dngImage.BackgroundColor = Color.White;
                dngImage.HasBackgroundColor = true;

                // Save as PNG with default options
                dngImage.Save(outputPath, new PngOptions());
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
 * 1. When a photographer needs to convert raw DNG files to web‑ready PNG images with a solid white background for product listings.
 * 2. When an e‑commerce platform must display user‑uploaded raw images on a consistent white canvas to match the site’s design.
 * 3. When a digital archiving system processes batches of DNG scans and replaces transparent backgrounds with white before saving them as PNG files.
 * 4. When a mobile app backend generates thumbnails from raw camera captures and requires a white background to improve visibility across devices.
 * 5. When a printing service prepares raw DNG artwork for print proofs and must export it as PNG with a solid white background to prevent color shifts.
 */