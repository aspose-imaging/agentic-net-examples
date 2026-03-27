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
        string outputPath = @"C:\Images\sample_filtered.jpg";

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
            using (MemoryStream pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions();
                odgImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(pngStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply median filter with size 5 to the whole image
                    raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as JPEG
                    var jpegOptions = new JpegOptions();
                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}