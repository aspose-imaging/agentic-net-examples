using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.bmp";

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
            // Set up rasterization options for vector to raster conversion
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // BMP save options with the rasterization settings
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Rasterize the OTG image into a memory stream
            using (var memoryStream = new MemoryStream())
            {
                otgImage.Save(memoryStream, bmpOptions);
                memoryStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Apply a median filter with size 5 to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered raster image as BMP
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}