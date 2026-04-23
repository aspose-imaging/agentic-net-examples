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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_blur.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting OTG to a raster format (PNG)
            var rasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize OTG to a memory stream as PNG
            using (var rasterStream = new MemoryStream())
            {
                otgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to apply filters
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter (size = 5, sigma = 4.0) to the whole image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the filtered image as JPEG
                    var jpegOptions = new JpegOptions();
                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}