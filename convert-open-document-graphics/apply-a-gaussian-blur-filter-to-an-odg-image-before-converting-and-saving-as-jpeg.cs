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
        string outputPath = @"C:\Images\sample_blur.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG vector image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Rasterize the ODG to a raster image (PNG in memory)
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        // Set rasterization options for ODG
                        VectorRasterizationOptions = new OdgRasterizationOptions
                        {
                            // Preserve original size
                            PageSize = odgImage.Size,
                            BackgroundColor = Color.White
                        }
                    };

                    // Save rasterized image to memory stream
                    odgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        // Cast to RasterImage to apply filters
                        var raster = (RasterImage)rasterImage;

                        // Apply Gaussian blur filter (size=5, sigma=4.0) to the whole image
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the processed image as JPEG
                        var jpegOptions = new JpegOptions();
                        raster.Save(outputPath, jpegOptions);
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