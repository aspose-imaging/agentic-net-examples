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
            string outputPath = "c:\\temp\\output.jpg";

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

                // Save as JPEG (automatically converts to 8‑bit per channel)
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
 * 1. When a photographer needs to convert high‑resolution 16‑bit DNG raw files to smaller 8‑bit JPEGs for web galleries using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must automatically down‑sample raw product photos (DNG) to JPEG thumbnails to reduce bandwidth and storage costs.
 * 3. When a mobile app backend processes uploaded raw images, converting them from 16‑bit DNG to 8‑bit JPEG for compatibility with standard image viewers.
 * 4. When a digital archiving system needs to preserve original DNG files but also generate 8‑bit JPEG preview images for quick browsing.
 * 5. When a batch‑processing script validates the existence of raw DNG files, creates output directories, and saves them as JPEGs with Aspose.Imaging to integrate into a CI/CD pipeline.
 */