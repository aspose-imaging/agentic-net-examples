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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gauss‑Wiener filter with custom size and sigma
                // Size must be an odd positive integer; sigma must be positive
                int filterSize = 7;      // example kernel size
                double filterSigma = 3.0; // example sigma value

                var gaussWienerOptions = new GaussWienerFilterOptions(filterSize, filterSigma);
                rasterImage.Filter(rasterImage.Bounds, gaussWienerOptions);

                // Save the filtered raster image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to convert an SVG diagram to a PNG thumbnail and remove slight blur introduced during rasterization by applying a Gauss‑Wiener filter with custom kernel size and sigma.
 * 2. When a C# application must preprocess vector‑based icons saved as SVG for use in a web UI, ensuring sharp edges after saving them as raster PNG files.
 * 3. When an automated image pipeline has to clean up low‑resolution SVG‑to‑PNG conversions for printing, using Aspose.Imaging to load the SVG, filter the raster image, and save the result.
 * 4. When a desktop tool needs to batch‑process SVG assets, applying a custom Gauss‑Wiener filter to improve visual quality before exporting them as PNG for inclusion in a game texture atlas.
 * 5. When a developer wants to programmatically enhance scanned SVG graphics that appear slightly blurry after conversion, by loading the file with Aspose.Imaging, applying a configurable Gauss‑Wiener filter, and saving the sharpened PNG output.
 */