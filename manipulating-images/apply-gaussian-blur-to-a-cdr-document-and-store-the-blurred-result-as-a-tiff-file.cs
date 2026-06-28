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
            string outputPath = "output\\result.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image; cannot apply Gaussian blur.");
                    return;
                }

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image as TIFF
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
 * 1. When a developer needs to automatically soften the graphics of a CorelDRAW (CDR) illustration before archiving it as a high‑resolution TIFF for print‑ready proofs.
 * 2. When a web service must preprocess user‑uploaded CDR files by applying a Gaussian blur to protect sensitive details and then store the result in TIFF format for downstream processing.
 * 3. When a batch conversion tool is required to convert a collection of CDR logos into blurred TIFF images to create watermark‑style assets for marketing collateral.
 * 4. When an automated workflow needs to apply a consistent blur radius to CDR diagrams before embedding them in PDF reports, saving the intermediate blurred output as TIFF.
 * 5. When a desktop application must validate that a CDR file can be rasterized, apply a Gaussian blur filter, and export the blurred version as a TIFF for archival compliance.
 */