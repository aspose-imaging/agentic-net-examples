// HOW-TO: Lazy Load JPEG Image and Rotate 90 Degrees in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Lazy‑load the image – it will be loaded only when Value is accessed
            Lazy<Image> lazyImage = new Lazy<Image>(() => Image.Load(inputPath));

            // Access the image (trigger loading) and apply a simple operation
            using (Image image = lazyImage.Value)
            {
                // Example operation: if the image is a raster image, rotate it 90 degrees
                if (image is RasterImage raster)
                {
                    raster.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When you need to improve startup performance by loading large JPEG files only when a rotation operation is required.
 * 2. When processing batches of images on a server and want to avoid loading each file into memory until a specific filter, such as a 90‑degree rotation, is applied.
 * 3. When building a desktop application that lets users preview and rotate photos, using lazy loading to keep the UI responsive.
 * 4. When converting images in an automated pipeline and need to ensure the output directory exists before saving the rotated JPEG.
 * 5. When handling raster images with Aspose.Imaging in C# and want to safely release resources after applying transformations like RotateFlip.
 */
