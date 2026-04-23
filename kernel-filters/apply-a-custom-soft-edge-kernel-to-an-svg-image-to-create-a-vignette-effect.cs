using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                // Configure rasterization options
                var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Set PNG save options with the rasterization settings
                var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Define a soft‑edge (vignette) kernel
                        double[,] kernel = new double[,]
                        {
                            { 0, 0, 1, 0, 0 },
                            { 0, 2, 2, 2, 0 },
                            { 1, 2, 5, 2, 1 },
                            { 0, 2, 2, 2, 0 },
                            { 0, 0, 1, 0, 0 }
                        };

                        // Apply the convolution filter using the custom kernel
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        // Save the processed image
                        raster.Save(outputPath);
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