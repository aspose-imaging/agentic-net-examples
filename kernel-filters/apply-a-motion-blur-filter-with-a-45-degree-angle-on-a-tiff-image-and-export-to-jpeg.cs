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

        // Path safety checks
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
 * 1. When a developer needs to preprocess high‑resolution scanned documents (TIFF) by adding a 45° motion blur to simulate camera movement before converting them to web‑friendly JPEGs for online viewing.
 * 2. When a medical imaging application must anonymize patient scans stored as TIFF by applying a directional motion blur and then export the result as JPEG for inclusion in reports.
 * 3. When a GIS system requires generating thumbnail previews of large TIFF satellite images with a subtle 45° motion blur effect to reduce visual noise before saving them as JPEG tiles.
 * 4. When an e‑commerce platform wants to create stylized product photos by applying a diagonal motion blur to original TIFF assets and delivering the final images in JPEG format for faster page loads.
 * 5. When a digital archiving workflow automates the conversion of archival TIFF photographs, adding a 45‑degree motion blur to mask imperfections and then storing the processed files as JPEGs for easy distribution.
 */