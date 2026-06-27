using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all DNG files in the input directory
            string[] dngFiles = Directory.GetFiles(inputDir, "*.dng");

            foreach (string inputPath in dngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path with .jpg extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DNG image with default load options
                using (Image image = Image.Load(inputPath, new DngLoadOptions()))
                {
                    // Set JPEG save options with quality 85
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }
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
 * 1. When a photographer needs to quickly convert a folder of raw DNG files into web‑ready JPEGs at 85 % quality using C# and Aspose.Imaging.
 * 2. When a digital asset management system must automate nightly batch processing of newly uploaded DNG images into compressed JPEGs for faster preview loading.
 * 3. When a mobile app backend has to transform raw camera captures (DNG) into smaller JPEG thumbnails with a specific quality setting before storing them in cloud storage.
 * 4. When an e‑commerce platform wants to standardize product photos by converting raw DNG product shots to JPEGs with consistent 85 % quality to reduce bandwidth usage.
 * 5. When a scientific imaging workflow requires exporting raw DNG microscope images to JPEG format for inclusion in reports while preserving visual fidelity via a defined quality level.
 */