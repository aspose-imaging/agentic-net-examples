using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
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
                // Prepare BMP save options with rasterization settings for OTG
                BmpOptions bmpOptions = new BmpOptions();
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    // Use the original OTG size for rasterization
                    PageSize = otgImage.Size
                };
                bmpOptions.VectorRasterizationOptions = otgRasterOptions;

                // Rasterize OTG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    otgImage.Save(rasterStream, bmpOptions);
                    rasterStream.Position = 0; // Reset stream for reading

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(rasterStream))
                    {
                        // Cast to RasterImage to apply filters
                        RasterImage raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered raster image as BMP
                        raster.Save(outputPath);
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