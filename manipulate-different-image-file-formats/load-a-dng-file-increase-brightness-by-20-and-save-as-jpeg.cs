using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DNG image
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                // Increase brightness by approximately 20% (value 51 out of 255)
                dng.AdjustBrightness(51);

                // Save as JPEG with default options
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
 * 1. When a photographer needs to batch‑process raw DNG files, increase their exposure by about 20 % and deliver the results as JPEGs for web galleries using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform receives product photos in DNG format and wants to automatically brighten them before converting to JPEG for faster page loads.
 * 3. When a mobile app backend must convert raw camera captures (DNG) to JPEG while applying a brightness boost to improve visibility on low‑light images.
 * 4. When a digital archiving system needs to normalize the brightness of scanned negatives stored as DNG and store them as compressed JPEGs for long‑term storage.
 * 5. When a scientific imaging workflow requires quick adjustment of raw DNG microscope images and export to JPEG for inclusion in reports or presentations.
 */