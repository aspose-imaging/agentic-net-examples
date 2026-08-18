// HOW-TO: Increase Brightness of DNG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output\\result.jpg";

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

            // Load DNG image
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                // Increase brightness by ~20% (51 out of 255)
                dng.AdjustBrightness(51);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save as JPEG
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
 * 1. When a photographer needs to batch‑process raw DNG files, brighten them by about 20 % and deliver the results as JPEGs for web galleries.
 * 2. When an e‑commerce platform receives product photos in DNG format and wants to improve visibility by adjusting brightness before converting them to JPEG for faster page loads.
 * 3. When a mobile app backend must convert user‑uploaded raw DNG images to JPEG while applying a brightness boost to compensate for underexposed shots.
 * 4. When a digital archivist wants to preserve raw DNG scans but also create brighter JPEG previews for quick browsing.
 * 5. When a scientific imaging workflow requires enhancing the brightness of raw sensor data in DNG files and exporting the adjusted images as JPEG for reporting.
 */
