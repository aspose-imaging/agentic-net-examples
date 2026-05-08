using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string tempPngPath = "temp/temp.png";
        string outputPath = "output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        try
        {
            // Load SVG and rasterize to a temporary PNG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Set up rasterization options
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                // Configure PNG save options with vector rasterization
                var pngSaveOptions = new PngOptions();
                pngSaveOptions.VectorRasterizationOptions = rasterOptions;

                // Save rasterized PNG to temporary file
                svgImage.Save(tempPngPath, pngSaveOptions);
            }

            // Load the rasterized PNG for filtering
            using (Image img = Image.Load(tempPngPath))
            {
                var rasterImage = (RasterImage)img;

                // Define custom 3x3 kernel (central 0.33333, surrounding 0.08333)
                double[,] kernel = new double[,]
                {
                    { 0.08333, 0.08333, 0.08333 },
                    { 0.08333, 0.33333, 0.08333 },
                    { 0.08333, 0.08333, 0.08333 }
                };

                // Apply convolution filter with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the filtered image to the final output path
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}