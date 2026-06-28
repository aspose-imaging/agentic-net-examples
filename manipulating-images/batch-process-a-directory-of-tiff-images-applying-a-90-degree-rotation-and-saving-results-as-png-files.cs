using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
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

            // Ensure the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Process each TIFF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.tif"))
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
                {
                    // Rotate 90 degrees clockwise, resize proportionally, black background
                    tiffImage.Rotate(90f, true, Color.Black);

                    // Determine output PNG path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert a large collection of scanned TIFF documents into web‑friendly PNG images while rotating each page 90° for correct orientation.
 * 2. When an archival system must automatically process incoming TIFF files, apply a clockwise rotation, and store the results as PNGs in a separate output folder for downstream applications.
 * 3. When a photo‑management tool has to batch‑resize and re‑orient TIFF photos from a camera’s raw export and save them as PNG thumbnails using C# and Aspose.Imaging.
 * 4. When a document‑conversion service requires a script that reads all TIFF files in a directory, rotates them, and outputs PNG files to a network share for easy viewing.
 * 5. When a Windows service needs to monitor a folder of TIFF scans, apply a 90‑degree rotation, and generate PNG versions for integration with a reporting dashboard.
 */