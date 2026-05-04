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
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };
                pngOptions.VectorRasterizationOptions = otgRaster;

                // Rasterize OTG to a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    otgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0; // Reset stream position for reading

                    // Load the rasterized image from the memory stream
                    using (Image rasterImage = Image.Load(rasterStream))
                    {
                        // Apply median filter to the entire image
                        var raster = (RasterImage)rasterImage;
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as PNG
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