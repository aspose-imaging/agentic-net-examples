using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Ensure any runtime exception is reported cleanly
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

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Set up rasterization options for PNG output
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Apply Gauss-Wiener deconvolution (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

                        // Save the processed image
                        rasterImage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}