using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to OdgImage to access ODG-specific features
            OdgImage odgImage = (OdgImage)image;

            // Set up rasterization options to convert vector ODG to a raster image (PNG)
            var rasterizationOptions = new PngOptions
            {
                VectorRasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = odgImage.Size
                }
            };

            // Rasterize ODG to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                odgImage.Save(memoryStream, rasterizationOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred image to the output path
                    raster.Save(outputPath);
                }
            }
        }
    }
}