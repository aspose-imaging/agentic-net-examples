using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.jpg";

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
            // Prepare rasterization options for converting ODG to a raster format
            var rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White
            };

            // Rasterize ODG to a memory stream (PNG format) so we can apply raster filters
            using (var rasterStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };
                odgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access filtering capabilities
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image as JPEG
                    var jpegOptions = new JpegOptions();
                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}