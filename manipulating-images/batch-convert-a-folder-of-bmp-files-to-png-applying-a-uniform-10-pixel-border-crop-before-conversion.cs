using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Process each BMP file in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.bmp"))
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to enable cropping
                    RasterImage raster = (RasterImage)image;

                    // Define a rectangle that crops a 10‑pixel border from each side
                    int cropX = 10;
                    int cropY = 10;
                    int cropWidth = raster.Width - 20;
                    int cropHeight = raster.Height - 20;

                    // Guard against images smaller than the crop size
                    if (cropWidth <= 0 || cropHeight <= 0)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                        continue;
                    }

                    // Perform the crop
                    raster.Crop(new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight));

                    // Save as PNG with default options
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to migrate a legacy collection of BMP assets to PNG for web delivery while removing a uniform 10‑pixel border from each image.
 * 2. When an automated build pipeline must generate optimized PNG thumbnails from a folder of BMP scans, applying a consistent crop to eliminate scanner margins.
 * 3. When a desktop application processes user‑uploaded BMP files in bulk, converting them to PNG and trimming a fixed border before storing them in a cloud repository.
 * 4. When a reporting tool prepares printable charts saved as BMP, and the code is used to batch convert them to PNG with a 10‑pixel crop to align them with layout templates.
 * 5. When a migration script needs to replace BMP icons with PNG equivalents across a product’s resource directory, ensuring each icon is uniformly cropped to remove unwanted edge pixels.
 */