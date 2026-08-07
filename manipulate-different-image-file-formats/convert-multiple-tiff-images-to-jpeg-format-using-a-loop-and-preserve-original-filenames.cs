using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            // Also include .tiff extension
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allTiffFiles, 0);
            tiffFilesAlt.CopyTo(allTiffFiles, tiffFiles.Length);

            foreach (string inputPath in allTiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path with the same filename but .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                // Ensure the output directory exists (unconditional as per requirements)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as JPEG using default options
                    image.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected error message
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging system needs to batch‑convert high‑resolution TIFF scans of patient records into smaller JPEG files for faster web viewing while keeping the original file names.
 * 2. When a document management workflow must archive scanned TIFF documents as JPEGs to reduce storage costs, using C# file I/O and Aspose.Imaging to process all files in a folder.
 * 3. When a photography studio wants to generate web‑ready JPEG previews of a large collection of TIFF RAW images, preserving the original filenames for easy cross‑reference.
 * 4. When an e‑commerce platform imports product catalogs supplied as TIFF files and automatically converts them to JPEG format for display on the website, using a loop to handle every file in the input directory.
 * 5. When a GIS application exports map layers as TIFF and later needs to create JPEG thumbnails for a mobile app, employing Aspose.Imaging’s Image.Load and JpegOptions while maintaining the source naming convention.
 */