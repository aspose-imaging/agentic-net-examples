using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.filtered.png";

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
            // Prepare PNG options with rasterization settings for OTG
            PngOptions pngOptions = new PngOptions();
            OtgRasterizationOptions rasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };
            pngOptions.VectorRasterizationOptions = rasterizationOptions;

            // Rasterize OTG to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                otgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream for reading

                // Load the rasterized image as a RasterImage
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply median filter with size 5 to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as PNG
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}