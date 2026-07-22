using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a motion blur (motion wiener) filter with a 45 degree angle
                // Parameters: length = 10, smooth = 1.0, angle = 45.0
                tiffImage.Filter(tiffImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 45.0));

                // Save the result as JPEG
                tiffImage.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to convert high‑resolution TIFF scans of documents into smaller JPEG files while adding a 45‑degree motion blur to simulate a scanning artifact.
 * 2. When an image‑processing pipeline must prepare satellite TIFF imagery for web preview by applying a directional motion blur and exporting to JPEG for faster loading.
 * 3. When a photo‑editing application wants to offer a “streak” effect on TIFF photos, using C# and Aspose.Imaging to blur at a 45° angle before saving as JPEG for sharing.
 * 4. When a batch job processes archival TIFF files, applying a motion‑wiener filter to reduce noise and then converting them to JPEG for inclusion in a digital catalog.
 * 5. When a developer integrates Aspose.Imaging into a .NET service that receives TIFF uploads, applies a 45° motion blur for artistic styling, and returns the result as a JPEG image.
 */