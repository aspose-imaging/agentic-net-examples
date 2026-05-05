using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\blurred.svg";
        string tempPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\restored.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist for temporary and output files
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image and rasterize it to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options matching the SVG size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized image to temporary file
                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply deconvolution (Gauss-Wiener) filter, and save the result
            using (Image rasterImage = Image.Load(tempPath))
            {
                var raster = (RasterImage)rasterImage;

                // Apply Gauss-Wiener deconvolution filter (radius 5, sigma 1.0)
                raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 1.0));

                // Save the filtered image
                raster.Save(outputPath);
            }

            // Optional: clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}