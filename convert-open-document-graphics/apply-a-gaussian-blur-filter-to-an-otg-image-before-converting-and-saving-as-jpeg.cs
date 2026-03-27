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
        string outputPath = @"C:\Images\output.jpg";

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
            // Rasterize the OTG image to a raster format (PNG) in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions();
                // Set rasterization options for OTG
                var otgRasterization = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save rasterized image to memory stream
                otgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0; // reset stream position for reading

                // Load the rasterized image as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply Gaussian blur filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image as JPEG
                    var jpegOptions = new JpegOptions();
                    rasterImage.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}