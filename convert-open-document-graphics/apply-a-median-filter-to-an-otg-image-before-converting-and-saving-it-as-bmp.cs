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
        string outputPath = @"C:\Images\sample_filtered.bmp";

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
            // Prepare BMP options with vector rasterization for OTG
            BmpOptions rasterizationOptions = new BmpOptions
            {
                VectorRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                }
            };

            // Rasterize OTG to a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                otgImage.Save(rasterStream, rasterizationOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply median filter with size 5 to the whole image
                    raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as BMP
                    BmpOptions saveOptions = new BmpOptions();
                    raster.Save(outputPath, saveOptions);
                }
            }
        }
    }
}