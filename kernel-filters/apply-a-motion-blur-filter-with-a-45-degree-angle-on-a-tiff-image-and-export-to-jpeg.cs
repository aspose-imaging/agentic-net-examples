// HOW-TO: Apply 45 Degree Motion Blur to TIFF and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply a motion blur (motion wiener) filter with a 45 degree angle
                // Length = 10, sigma = 1.0, angle = 45.0
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 45.0);
                tiffImage.Filter(tiffImage.Bounds, motionOptions);

                // Save the result as JPEG
                var jpegOptions = new JpegOptions();
                tiffImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to add a realistic motion‑blur effect to a high‑resolution TIFF scan before converting it to a smaller JPEG for web publishing.
 * 2. When a medical imaging application must anonymize patient scans by blurring motion artifacts in TIFF files and store the results as JPEG thumbnails.
 * 3. When an e‑commerce platform wants to stylize product TIFF images with a 45° motion blur and deliver them as JPEGs to improve page load speed.
 * 4. When a document management system processes archived TIFF documents, applies a directional blur for visual emphasis, and saves the output in JPEG format for preview.
 * 5. When a batch‑processing script automates the conversion of TIFF photographs with a specific angle blur into JPEGs for archival backup.
 */
