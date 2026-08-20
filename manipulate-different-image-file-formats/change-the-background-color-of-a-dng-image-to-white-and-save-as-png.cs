// HOW-TO: Change DNG Background Color to White and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\input.dng";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Set background color to white
                dngImage.HasBackgroundColor = true;
                dngImage.BackgroundColor = Aspose.Imaging.Color.White;

                // Save as PNG
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
 * 1. When you need to replace a transparent or black background in a raw DNG file with a white canvas before publishing it as a PNG on a website.
 * 2. When an automated pipeline must convert camera raw images to web‑friendly PNGs while ensuring a consistent white background for branding.
 * 3. When a photo‑editing application wants to display DNG files with a solid white backdrop and then export them as PNG for further processing.
 * 4. When batch processing of raw photos requires setting a uniform background color to avoid dark edges in the resulting PNG thumbnails.
 * 5. When integrating Aspose.Imaging into a C# service that receives DNG uploads and returns PNGs with a white background for printing or e‑commerce listings.
 */
