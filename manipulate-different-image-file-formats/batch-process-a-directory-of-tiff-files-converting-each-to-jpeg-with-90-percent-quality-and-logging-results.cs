using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\InputTiffs";
            string outputDir = @"C:\OutputJpegs";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output JPEG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists (unconditional per rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image, convert and save as JPEG with 90% quality
                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };
                    image.Save(outputPath, jpegOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate a legacy archive of TIFF scans to smaller JPEG files for web publishing, they can batch‑process the directory with 90 % quality using Aspose.Imaging for .NET.
 * 2. When an automated nightly job must convert newly uploaded TIFF images to JPEG to reduce storage costs, this code can scan the input folder, convert each file, and log the results.
 * 3. When a document management system requires all incoming TIFF documents to be saved as JPEG thumbnails for quick preview, the sample demonstrates how to load, set JpegOptions, and save each image in C#.
 * 4. When a Windows service has to validate that every TIFF file in a folder exists before conversion and ensure the output directory is created, the code provides the necessary file‑system checks and error handling.
 * 5. When a batch image‑processing pipeline needs to report successful conversions and capture any exceptions while converting multiple TIFFs to high‑quality JPEGs, this example shows how to log each operation using Console output.
 */