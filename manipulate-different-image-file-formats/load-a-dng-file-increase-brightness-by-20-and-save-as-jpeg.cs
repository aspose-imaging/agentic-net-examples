using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dng";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (Aspose.Imaging.FileFormats.Dng.DngImage dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
            {
                // Increase brightness by ~20% (51 out of 255)
                dngImage.AdjustBrightness(51);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90 // optional quality setting
                };

                // Save as JPEG
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
 * 1. When a photographer needs to batch‑process raw DNG files from a shoot, increase exposure by about 20 % and generate web‑ready JPEGs for online galleries.
 * 2. When an e‑commerce platform receives product photos in DNG format, it can brighten the images slightly and convert them to JPEG to improve visual appeal on product pages.
 * 3. When a mobile app backend receives raw camera uploads, it can use this code to adjust brightness and create compressed JPEG thumbnails for faster preview loading.
 * 4. When a digital archivist wants to preserve original DNG files but also provide lower‑resolution, brighter JPEG copies for quick reference in a catalog system.
 * 5. When a scientific imaging workflow requires enhancing raw DNG microscope images and exporting them as JPEGs for inclusion in research reports or presentations.
 */