using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded directory containing PNG files
        string inputDirectory = "C:\\Images\\";

        try
        {
            // Get all PNG files in the directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(filePath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter with kernel size 5 and sigma 4.0
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Ensure the output directory exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Overwrite the original file with the processed image
                    rasterImage.Save(filePath);
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
 * 1. When a developer needs to automatically enhance the visual clarity of a large collection of product photos stored as PNG files before uploading them to an e‑commerce website.
 * 2. When a desktop application must improve the sharpness of scanned PNG documents in a folder to make text more readable for OCR processing.
 * 3. When a game asset pipeline requires batch sharpening of PNG textures to highlight details without manually editing each file.
 * 4. When a photo‑editing tool offers a one‑click “sharpen all” feature that processes every PNG in a user‑selected directory and safely overwrites the originals.
 * 5. When a server‑side script prepares PNG screenshots for a reporting dashboard by applying a consistent sharpen filter to all images in a directory.
 */