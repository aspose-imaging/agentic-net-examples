// HOW-TO: Apply Median Filter to ODG Image and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample_filtered.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply a median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the processed image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                rasterImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to reduce salt‑and‑pepper noise in an ODG diagram before converting it to a BMP for legacy Windows applications.
 * 2. When a document‑management system stores drawings as ODG files and requires a filtered BMP thumbnail for quick previews.
 * 3. When preprocessing ODG graphics for OCR or pattern‑recognition pipelines that accept only BMP input.
 * 4. When integrating Aspose.Imaging into a C# batch job that cleans up scanned ODG assets and archives them as BMP files.
 * 5. When creating a printable BMP version of an ODG illustration while smoothing out artifacts caused by compression.
 */
