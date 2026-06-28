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
            string inputPath = "c:\\temp\\input.dng";
            string outputPath = "c:\\temp\\output.png";

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
                DngImage dngImage = (DngImage)image;

                // Apply gamma correction (2.2 for all channels)
                dngImage.AdjustGamma(2.2f);

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
 * 1. When a photographer needs to convert raw DNG files to web‑ready PNGs with a standard 2.2 gamma for consistent display across browsers.
 * 2. When an image‑processing pipeline must normalize the tonal response of raw sensor data by applying gamma correction before saving as PNG for downstream analysis.
 * 3. When a mobile app backend receives DNG uploads and must generate PNG thumbnails with correct gamma to match the visual appearance of the original photo.
 * 4. When a scientific imaging application requires converting raw DNG microscopy images to PNG while adjusting gamma to improve contrast for publication.
 * 5. When an e‑commerce platform automates the conversion of high‑dynamic‑range DNG product shots to PNG assets with gamma 2.2 to ensure accurate color on consumer devices.
 */