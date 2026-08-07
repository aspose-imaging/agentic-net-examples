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
        string inputPath = "input.bmp";
        string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply a motion blur filter with length 10 pixels, smooth factor 1.0, angle 0 degrees
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
 * 1. When a developer needs to convert legacy BMP scans of documents into compressed JPEGs while adding a subtle 10‑pixel motion blur to hide scanning artifacts.
 * 2. When an e‑commerce platform wants to generate product thumbnails from high‑resolution BMP assets and apply a 10‑pixel motion blur to simulate motion before saving as JPEG.
 * 3. When a game developer processes sprite sheets stored as BMP files, applying a 10‑pixel motion blur to create a speed‑effect and then exporting the result as JPEG for web preview.
 * 4. When a medical imaging application must anonymize patient BMP images by blurring background details with a 10‑pixel motion blur and store the output in JPEG format for faster transmission.
 * 5. When an automated batch job needs to read BMP files, apply a consistent 10‑pixel motion blur using Aspose.Imaging’s MotionWienerFilterOptions, and save the processed images as JPEGs for archival.
 */