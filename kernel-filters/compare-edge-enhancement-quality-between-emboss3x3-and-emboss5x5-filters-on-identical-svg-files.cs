using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputDir = "output";
        string outputPath3x3 = Path.Combine(outputDir, "emboss3x3.png");
        string outputPath5x5 = Path.Combine(outputDir, "emboss5x5.png");

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3x3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5x5));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // ---------- Emboss3x3 ----------
                using (MemoryStream pngStream = new MemoryStream())
                {
                    // Rasterize SVG to PNG in memory
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size,
                        BackgroundColor = Color.White
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    // Load raster image for filtering
                    using (RasterImage rasterImage = (RasterImage)Image.Load(pngStream))
                    {
                        // Apply Emboss3x3 filter
                        var emboss3x3 = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                        rasterImage.Filter(rasterImage.Bounds, emboss3x3);
                        rasterImage.Save(outputPath3x3);
                    }
                }

                // ---------- Emboss5x5 ----------
                using (MemoryStream pngStream = new MemoryStream())
                {
                    // Rasterize SVG again to get an unfiltered copy
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size,
                        BackgroundColor = Color.White
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    // Load raster image for filtering
                    using (RasterImage rasterImage = (RasterImage)Image.Load(pngStream))
                    {
                        // Apply Emboss5x5 filter
                        var emboss5x5 = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5);
                        rasterImage.Filter(rasterImage.Bounds, emboss5x5);
                        rasterImage.Save(outputPath5x5);
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