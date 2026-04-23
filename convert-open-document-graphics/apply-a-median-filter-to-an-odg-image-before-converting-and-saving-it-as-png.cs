using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample_filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Rasterize ODG to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up rasterization options for ODG
                var rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = odgImage.Size
                };

                // PNG save options with the rasterization settings
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized image to the memory stream
                odgImage.Save(rasterStream, pngSaveOptions);
                rasterStream.Position = 0; // Reset stream for reading

                // Load the rasterized image (as a RasterImage)
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access Filter method
                    var raster = (RasterImage)rasterImage;

                    // Apply median filter with size 5 to the whole image
                    raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as PNG
                    raster.Save(outputPath);
                }
            }
        }
    }
}