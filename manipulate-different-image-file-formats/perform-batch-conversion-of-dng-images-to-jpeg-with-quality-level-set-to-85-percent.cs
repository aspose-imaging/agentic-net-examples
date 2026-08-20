// HOW-TO: Batch Convert DNG Files to JPEG with 85% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputDng\";
            string outputDir = @"C:\OutputJpeg\";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all DNG files in the input directory
            string[] dngFiles = Directory.GetFiles(inputDir, "*.dng");

            foreach (string inputPath in dngFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path with .jpg extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".jpg");

                // Ensure the output directory exists (handles subfolders if any)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DNG image with default DngLoadOptions
                using (Image image = Image.Load(inputPath, new DngLoadOptions()))
                {
                    // Cast to DngImage to access DNG-specific functionality
                    DngImage dngImage = (DngImage)image;

                    // Set JPEG save options with quality 85
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };

                    // Save as JPEG
                    dngImage.Save(outputPath, jpegOptions);
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
 * 1. When a photographer needs to quickly generate web‑ready JPEG previews from a folder of raw DNG shots while preserving a specific compression level.
 * 2. When an e‑commerce platform must convert large batches of product raw images (DNG) to JPEGs at 85 % quality for faster page loads.
 * 3. When a digital asset management system automates the creation of thumbnail‑size JPEGs from incoming DNG files using Aspose.Imaging in a C# service.
 * 4. When a mobile app backend processes user‑uploaded DNG files and stores them as JPEGs with consistent quality to reduce storage costs.
 * 5. When a scientific imaging pipeline requires converting raw DNG captures to JPEG for easy sharing and reporting while maintaining visual fidelity.
 */
