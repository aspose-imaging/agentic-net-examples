using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
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

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access frames
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a TIFF.");
                    return;
                }

                // Iterate over each frame (page)
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path with page number (1‑based)
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.webp");

                    // Ensure the directory for this file exists (already created above, but call per rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current frame as a WebP image
                    // Only the active frame (the current TiffFrame) will be saved
                    tiffImage.ActiveFrame = tiffImage.Frames[i];
                    tiffImage.ActiveFrame.Save(outputPath, new WebPOptions());
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
 * 1. When a developer needs to extract each page of a multi‑page TIFF scan and save them as lightweight WebP files for faster web delivery, they can use this code to generate page‑numbered images.
 * 2. When an application must convert high‑resolution scanned documents (TIFF) into lossless WebP thumbnails for a document preview gallery, the snippet provides a C# solution that names each thumbnail by its page index.
 * 3. When a batch‑processing service has to archive each page of a multi‑page medical image (TIFF) as separate WebP assets for storage‑efficient retrieval, this code automates the per‑page conversion and naming.
 * 4. When a content‑management system requires converting uploaded multi‑page TIFFs into individual WebP images for responsive design, the example shows how to loop through frames and save them with sequential filenames.
 * 5. When a developer is building a migration tool that moves legacy TIFF archives to modern WebP format while preserving page order, this C# routine using Aspose.Imaging handles the conversion and creates page‑specific file names.
 */