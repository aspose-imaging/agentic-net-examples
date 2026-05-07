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
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector illustration
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Configure rasterization options for the vector image
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,
                    BackgroundColor = Color.White
                };

                // Export the vector image to a raster PNG in memory
                using (var tempStream = new MemoryStream())
                {
                    var exportOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    vectorImage.Save(tempStream, exportOptions);
                    tempStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImg = Image.Load(tempStream))
                    {
                        var raster = (RasterImage)rasterImg;

                        // Apply Gaussian blur with radius 2 and sigma 1.0
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 1.0));

                        // Prepare high‑quality PNG save options
                        var saveOptions = new PngOptions
                        {
                            PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                            FilterType = PngFilterType.Adaptive,
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Progressive = true
                        };

                        // Save the final image
                        raster.Save(outputPath, saveOptions);
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