using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage to access vector-specific methods
                SvgImage svgImage = (SvgImage)image;

                // Rotate the SVG by 45 degrees
                svgImage.Rotate(45f);

                // Rasterize the rotated SVG into a PNG stored in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    // Set up rasterization options (use original SVG size)
                    SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // Configure PNG save options with the rasterization settings
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the rasterized image to the memory stream
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0; // Reset stream position for reading

                    // Load the rasterized image as a RasterImage to apply filters
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the final image to the output path
                        rasterImage.Save(outputPath);
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