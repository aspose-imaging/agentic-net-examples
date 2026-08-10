// HOW-TO: Deskew CDR Image, Apply Gaussian Blur, and Save as TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Deskew the image
                raster.NormalizeAngle();

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as TIFF
                raster.Save(outputPath);
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
 * 1. When you need to correct the orientation of a scanned CorelDRAW (CDR) file before applying a softening effect for print‑ready TIFF output.
 * 2. When automating a workflow that converts vector CDR artwork into a blurred raster TIFF for use as a background image in a web application.
 * 3. When preprocessing CDR graphics to remove skew and add Gaussian blur so they meet the input requirements of a machine‑learning model that expects TIFF images.
 * 4. When generating preview thumbnails of CDR designs with a consistent blurred look and storing them as high‑quality TIFF files for archival purposes.
 * 5. When integrating Aspose.Imaging in a C# service that normalizes skewed CDR drawings, applies a blur filter, and saves the result as a TIFF for downstream PDF conversion.
 */
