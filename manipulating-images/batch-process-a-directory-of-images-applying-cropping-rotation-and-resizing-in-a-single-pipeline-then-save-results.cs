// HOW-TO: Batch Crop and Rotate Images from Folder Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Enumerate all files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string inputPath in files)
            {
                // Validate that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Work with RasterImage for pixel‑level operations
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image type: {inputPath}");
                        continue;
                    }

                    // ----- Cropping -----
                    // Crop to the central half of the image
                    int cropWidth = raster.Width / 2;
                    int cropHeight = raster.Height / 2;
                    int cropX = (raster.Width - cropWidth) / 2;
                    int cropY = (raster.Height - cropHeight) / 2;
                    raster.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

                    // ----- Rotation -----
                    // Rotate 90 degrees clockwise without flipping
                    raster.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // ----- Resizing -----
                    // Resize to a fixed size (e.g., 800x600)
                    int newWidth = 800;
                    int newHeight = 600;
                    raster.Resize(newWidth, newHeight);

                    // Prepare the output file path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileName + "_processed.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG
                    PngOptions saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically trim the central portion of every photo in a directory and rotate them 90° clockwise for a web gallery.
 * 2. When you want to preprocess scanned documents by cropping out margins and correcting orientation before archiving them in a batch job.
 * 3. When a set of product images must be standardized to a consistent view by applying the same central crop and rotation to all files programmatically.
 * 4. When generating thumbnails for a mobile app that require central cropping and a 90‑degree rotation without manual editing.
 * 5. When migrating a legacy image collection to a new system and you need to apply identical crop‑and‑rotate transformations to all images using C#.
 */
