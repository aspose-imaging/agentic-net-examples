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
        string inputPath = @"C:\temp\sample.otg";
        string outputPath = @"C:\temp\sample_filtered.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Rasterize OTG to a PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();

                    // Set rasterization options for OTG
                    var otgRasterOptions = new OtgRasterizationOptions
                    {
                        PageSize = otgImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = otgRasterOptions;

                    otgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0; // Reset stream position for reading

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the filtered image as JPEG
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