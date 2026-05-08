using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPathEmboss3 = "output_emboss3.png";
            string outputPathEmboss5 = "output_emboss5.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathEmboss3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathEmboss5));

            // Load the SVG image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Set up rasterization options for PNG output
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream (PNG format)
                using (var memoryStream = new MemoryStream())
                {
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // ----- Apply Emboss3x3 filter -----
                    using (Image rasterImage1 = Image.Load(memoryStream))
                    {
                        var raster1 = (RasterImage)rasterImage1;
                        raster1.Filter(raster1.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                        raster1.Save(outputPathEmboss3);
                    }

                    // Reset stream to reuse original raster data
                    memoryStream.Position = 0;

                    // ----- Apply Emboss5x5 filter -----
                    using (Image rasterImage2 = Image.Load(memoryStream))
                    {
                        var raster2 = (RasterImage)rasterImage2;
                        raster2.Filter(raster2.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));
                        raster2.Save(outputPathEmboss5);
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