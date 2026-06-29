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
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output\\result.jpg";

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
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply a motion blur filter with length 10, smooth factor 1.0, angle 0 degrees
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 0.0));

                // Save the result as JPEG
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to convert legacy BMP screenshots to compressed JPEGs while adding a subtle 10‑pixel motion blur to simulate camera movement for a web gallery.
 * 2. When an automated image‑processing pipeline must prepare product photos by applying a 10‑pixel motion blur to reduce sharp edges before saving them as JPEGs for faster page loads.
 * 3. When a desktop application generates thumbnail previews from BMP assets and wants to apply a 10‑pixel motion blur effect to give a stylized look before exporting to JPEG format.
 * 4. When a batch script processes scanned documents in BMP format, adds a motion blur of length 10 to mask scanning artifacts, and saves the cleaned images as JPEGs for archival.
 * 5. When a game developer exports in‑game BMP textures, applies a 10‑pixel motion blur to create motion‑blurred UI elements, and stores the result as JPEG for use in the UI overlay.
 */