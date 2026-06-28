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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputTiffs";
            string outputDirectory = @"C:\OutputJpegs";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            // Also include *.tiff files
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allTiffFiles, 0);
            tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

            foreach (string inputPath in allTiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same name, .jpg extension)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options with 90% quality
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When a medical imaging system needs to archive high‑resolution DICOM TIFF scans as smaller JPEG files for quick web preview, a developer can use this code to batch‑convert the images with 90 % quality and log each conversion.
 * 2. When a publishing house receives scanned book pages in TIFF format and wants to generate web‑ready JPEG thumbnails for their online catalog, this C# routine automates the directory‑wide conversion and records the results.
 * 3. When an e‑commerce platform stores product photographs as lossless TIFF files but must deliver compressed JPEGs to browsers, a developer can employ this script to process the entire folder, applying a 90 % quality setting and outputting a conversion log.
 * 4. When a GIS (geographic information system) project contains aerial imagery saved as TIFF and the team needs portable JPEG copies for field devices, the code provides a simple batch conversion with consistent quality and console logging.
 * 5. When a legal firm digitizes documents as TIFF files and wants to create smaller JPEG versions for email distribution while tracking which files were successfully converted, this example offers a straightforward C# solution.
 */