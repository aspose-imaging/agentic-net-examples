using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output\\vignette.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Configure PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageContainer = Image.Load(rasterStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Define a custom soft‑edge (vignette) kernel
                        double[,] kernel = new double[,]
                        {
                            { 0.0, 0.0, 0.0, 0.0, 0.0 },
                            { 0.0, 1.0, 2.0, 1.0, 0.0 },
                            { 0.0, 2.0, 4.0, 2.0, 0.0 },
                            { 0.0, 1.0, 2.0, 1.0, 0.0 },
                            { 0.0, 0.0, 0.0, 0.0, 0.0 }
                        };

                        // Apply the custom convolution filter to the entire image
                        ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

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