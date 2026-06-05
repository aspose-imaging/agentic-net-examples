using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded directory containing PNG files
            string inputDirectory = @"C:\Images\";

            // Get all PNG files in the directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Output path is the same as input path (overwrite)
                string outputPath = inputPath;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply sharpen filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access Filter method
                    var rasterImage = (RasterImage)image;

                    // Apply sharpen filter with kernel size 5 and sigma 4.0
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Save the modified image, overwriting the original
                    rasterImage.Save(outputPath);
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
 * 1. When a developer needs to automatically enhance the sharpness of every PNG asset in a folder before publishing a website, they can run this batch filter to overwrite the originals safely.
 * 2. When a photo‑management tool must prepare a large collection of PNG screenshots for printing by applying a consistent sharpen filter across all files, this code provides a simple C# solution.
 * 3. When a CI/CD pipeline for a graphics‑intensive application requires post‑build processing to improve the clarity of generated PNG sprites, the script can be integrated to process the output directory in place.
 * 4. When a digital archivist wants to improve the visual quality of scanned PNG documents stored in a directory without creating duplicate files, the program applies a sharpen filter and saves over each image.
 * 5. When a game developer needs to batch‑process PNG textures to enhance edge definition before packaging them into a Unity asset bundle, this code automates the sharpening step directly on the source files.
 */