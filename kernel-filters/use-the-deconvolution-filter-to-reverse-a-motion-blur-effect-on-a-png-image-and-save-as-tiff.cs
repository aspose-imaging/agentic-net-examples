using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\output.tif";

        // Ensure any runtime exception is caught and reported
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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener deconvolution filter to reverse motion blur
                // Parameters: length, smooth (sigma), angle (degrees)
                var motionWienerOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
                rasterImage.Filter(rasterImage.Bounds, motionWienerOptions);

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the processed image as TIFF
                rasterImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to restore a motion‑blurred PNG photograph taken from a moving camera and then archive the corrected image in lossless TIFF format for long‑term storage.
 * 2. When an application must automatically deblur scanned PNG receipts that were captured with handheld motion and save them as TIFF files for reliable OCR processing.
 * 3. When a medical imaging workflow requires removing motion blur from PNG microscopy images using a Wiener deconvolution filter before converting them to TIFF for compatibility with analysis software.
 * 4. When a document management system needs to clean up PNG screenshots blurred by screen‑capture lag and store the sharpened results as TIFF to meet corporate archival standards.
 * 5. When a batch‑processing tool in C# must apply a motion Wiener filter to PNG assets, convert them to TIFF, and ensure the output preserves image quality for high‑resolution printing.
 */