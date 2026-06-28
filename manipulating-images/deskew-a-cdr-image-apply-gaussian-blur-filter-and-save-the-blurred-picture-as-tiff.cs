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
            string inputPath = "input.cdr";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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
 * 1. When a developer needs to automatically correct the orientation of scanned CorelDRAW (CDR) drawings and then soften the details before archiving them as high‑resolution TIFF files.
 * 2. When an application must preprocess user‑uploaded CDR artwork by deskewing it and applying a Gaussian blur to reduce noise prior to printing or further analysis.
 * 3. When a batch conversion tool is required to straighten misaligned CDR images, apply a blur effect for aesthetic purposes, and save the results in TIFF format for compatibility with legacy systems.
 * 4. When integrating Aspose.Imaging into a C# workflow that receives CDR files from a design pipeline, and the workflow must normalize the angle and smooth the image before storing it as a TIFF document.
 * 5. When building a document management system that needs to ingest CDR files, correct their skew, apply a Gaussian blur filter to meet visual standards, and export the processed images as TIFF for long‑term preservation.
 */