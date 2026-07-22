using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng.Decoder;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.png";

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
 * 1. When a photographer needs to convert raw DNG files to web‑friendly PNGs with a uniform white background for online galleries.
 * 2. When an e‑commerce platform processes product photos captured in DNG format and wants to ensure the background appears white before displaying them on the site.
 * 3. When a scientific imaging workflow requires stripping the original background of raw DNG microscopy images and exporting them as PNGs for publication.
 * 4. When a mobile app backend receives raw DNG uploads and must standardize them to PNG with a white canvas to maintain consistent UI rendering.
 * 5. When a digital archiving system batch‑processes heritage photographs stored as DNG and needs to replace any transparent or colored background with white before long‑term storage as PNG.
 */