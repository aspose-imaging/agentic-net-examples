using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply a motion blur filter (length 10 pixels, smooth factor 1.0, angle 0 degrees)
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 0.0));

                // Save the result as JPEG
                rasterImage.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to convert legacy BMP screenshots into compressed JPEGs while adding a subtle motion‑blur effect to simulate camera movement for a web gallery.
 * 2. When an image‑processing pipeline must prepare product photos stored as BMP files for e‑commerce sites by applying a 10‑pixel motion blur to hide minor imperfections before saving them as JPEGs.
 * 3. When a desktop application generates BMP frames from a simulation and wants to export them as JPEG thumbnails with a consistent motion‑blur filter to convey motion in a preview pane.
 * 4. When a document‑automation tool has to batch‑process scanned BMP documents, apply a gentle motion blur to reduce scanning artifacts, and store the results as JPEGs for smaller file size.
 * 5. When a C# service receives BMP uploads, needs to apply a 10‑pixel horizontal motion blur for artistic effect, and then saves the output as a JPEG for downstream consumption.
 */