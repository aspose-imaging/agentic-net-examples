using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access the Filter method
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply sharpen filter (kernel size 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce noise in a high‑resolution TIFF scan, sharpen edge detail, and then export the result as a PNG for web display.
 * 2. When an application must preprocess scanned documents by applying a Gaussian blur to smooth artifacts, followed by a sharpen filter to improve readability, before saving as PNG.
 * 3. When a batch‑processing tool prepares TIFF photographs for e‑commerce catalogs by softening background grain, enhancing product edges, and generating PNG thumbnails.
 * 4. When a medical‑imaging system applies a blur‑then‑sharpen pipeline to TIFF images derived from DICOM files to improve visual contrast and then delivers the images as PNG for reporting.
 * 5. When a GIS application cleans up satellite TIFF tiles with a Gaussian blur, sharpens terrain features, and outputs PNG tiles for fast rendering in a web map.
 */