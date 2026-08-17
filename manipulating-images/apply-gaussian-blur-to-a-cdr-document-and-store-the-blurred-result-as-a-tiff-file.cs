// HOW-TO: Apply Gaussian Blur to CDR and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
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

        try
        {
            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the blurred image as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to soften vector artwork from a CorelDRAW file before printing, you can blur it and export to a high‑resolution TIFF for the press.
 * 2. When a web service must generate a blurred preview of a CDR design for privacy reasons, this code creates a TIFF thumbnail with the effect applied.
 * 3. When integrating Aspose.Imaging into a batch‑processing pipeline that converts multiple CDR files to TIFF while applying a uniform Gaussian blur for consistent visual style.
 * 4. When a desktop application requires on‑the‑fly image manipulation, such as blurring a logo stored in CDR format before embedding it into a PDF as a TIFF image.
 * 5. When automating archival of design assets, you can blur sensitive details in a CDR file and store the result as a lossless TIFF for long‑term preservation.
 */
