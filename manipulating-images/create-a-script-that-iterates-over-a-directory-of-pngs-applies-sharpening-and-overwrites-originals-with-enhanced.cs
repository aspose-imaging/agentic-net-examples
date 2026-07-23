using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Wrap the entire logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input directory containing PNG files.
            string inputDirectory = @"C:\Images\";

            // Retrieve all PNG files in the directory.
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify that the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image using Aspose.Imaging.
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering capabilities.
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a sharpen filter (kernel size 5, sigma 4.0) to the whole image.
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Ensure the output directory exists (unconditionally as required).
                    Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

                    // Overwrite the original file with the sharpened version.
                    rasterImage.Save(inputPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any error message without crashing the program.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑process a folder of PNG files to enhance visual sharpness before uploading them to a web gallery, this C# script uses Aspose.Imaging to apply a Sharpen filter and overwrite each original image.
 * 2. When an automated build pipeline must improve the clarity of product screenshots stored as PNGs in a repository, the code iterates through the directory, sharpens each image, and saves the updated files in place.
 * 3. When a desktop application must prepare a collection of PNG assets for print by applying a consistent sharpening effect, the script leverages RasterImage filtering and overwrites the source files to keep the asset folder tidy.
 * 4. When a content management system needs to refresh cached PNG thumbnails with a higher‑definition version, the developer can run this code to scan the thumbnail directory, sharpen each image, and replace the old files without creating duplicates.
 * 5. When a data‑migration tool moves PNG images to a new server and wants to improve image quality on the fly, the program can iterate over the source directory, apply a SharpenFilterOptions kernel, and save the enhanced images back to their original paths.
 */