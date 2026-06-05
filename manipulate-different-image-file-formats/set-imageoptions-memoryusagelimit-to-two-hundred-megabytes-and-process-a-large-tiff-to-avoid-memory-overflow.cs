using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\large_input.tif";
            string outputPath = @"C:\Images\processed_output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set a memory limit of 200 MB for loading the image
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 200 // megabytes
            };

            // Load the large TIFF image with the specified memory limit
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // (Optional) Perform any image processing here

                // Set a memory limit of 200 MB for saving the image
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BufferSizeHint = 200 // megabytes
                };

                // Save the image to the output path
                image.Save(outputPath, saveOptions);
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
 * 1. When processing multi‑gigapixel scanned documents in a document‑management system, a developer can limit memory to 200 MB to prevent out‑of‑memory crashes while loading and saving large TIFF files with Aspose.Imaging for .NET.
 * 2. When converting high‑resolution medical imaging (e.g., DICOM‑derived TIFF) on a server with limited RAM, the code ensures the image is processed within a 200 MB buffer using LoadOptions.BufferSizeHint and TiffOptions.BufferSizeHint.
 * 3. When building a batch‑processing service that extracts pages from large multi‑page TIFF archives, setting the memory usage limit avoids exceeding the allocated memory quota in a cloud‑based C# microservice.
 * 4. When integrating a legacy scanning workflow that outputs 200 MB+ TIFF files into a .NET application, developers use this pattern to safely load, optionally edit, and re‑save the image without exhausting system resources.
 * 5. When implementing an on‑premises archival tool that must handle oversized TIFF images on machines with 4 GB RAM, the code’s 200 MB memory cap helps keep the process stable while performing image transformations.
 */