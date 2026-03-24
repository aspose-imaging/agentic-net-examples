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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is already a raster image, apply the filter directly
            if (image is RasterImage rasterImage)
            {
                // Apply sharpen filter (kernel size 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                rasterImage.Save(outputPath);
            }
            else
            {
                // Otherwise rasterize the OTG image to a temporary raster image, apply filter, then save
                var pngOptions = new PngOptions();

                using (MemoryStream ms = new MemoryStream())
                {
                    // Rasterize to PNG in memory
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage tempRaster = (RasterImage)Image.Load(ms))
                    {
                        tempRaster.Filter(tempRaster.Bounds, new SharpenFilterOptions(5, 4.0));
                        tempRaster.Save(outputPath);
                    }
                }
            }
        }
    }
}