using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputDirectory = @"C:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame (page) of the TIFF
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path using page number (1‑based)
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.webp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a WebP image
                    tiffImage.Frames[i].Save(outputPath, new WebPOptions());
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
 * 1. When a developer needs to extract each frame of a multi‑page TIFF scan and save them as lightweight WebP images for faster web page loading.
 * 2. When an application must convert scanned document pages stored in TIFF format into individual, page‑numbered WebP files for use in a mobile app’s image gallery.
 * 3. When a batch‑processing service has to generate WebP thumbnails from each page of a multi‑page TIFF to display in a PDF preview component.
 * 4. When a cloud‑based image pipeline requires converting every frame of a TIFF into separate WebP files to reduce storage costs while preserving the original page order.
 * 5. When a legacy system stores medical imaging reports as multi‑page TIFFs and needs to output each page as a WebP image for modern web‑based viewers.
 */