using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_blur.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Rasterize the ODG image into a memory stream (PNG format)
            using (var rasterStream = new MemoryStream())
            {
                odgImage.Save(rasterStream, new PngOptions());
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter (size=5, sigma=4.0) to the whole image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image as JPEG
                    raster.Save(outputPath, new JpegOptions());
                }
            }
        }
    }
}