using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.dng";
            string outputPath = "output\\result.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image, adjust brightness, and save as JPEG
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                // Increase brightness by approximately 20% (value 51 out of 255)
                dng.AdjustBrightness(51);

                // Save with default JPEG options
                JpegOptions jpegOptions = new JpegOptions();
                dng.Save(outputPath, jpegOptions);
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
 * 1. When a photographer wants to batch‑process raw DNG files from a shoot, increase their exposure by about 20 % and generate web‑ready JPEG previews using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform receives product photos in DNG format and needs to brighten them slightly before converting them to JPEG for faster page loads.
 * 3. When a scientific imaging application must improve the visibility of raw microscope images stored as DNG and export them as JPEGs for inclusion in reports.
 * 4. When a mobile app backend processes user‑uploaded raw DNG images, applies a brightness boost and stores the result as a JPEG thumbnail for quick display.
 * 5. When a digital archivist automates the conversion of legacy DNG scans, adjusts brightness to compensate for underexposed originals, and saves them as JPEG files for archival distribution.
 */