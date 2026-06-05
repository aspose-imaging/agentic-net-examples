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
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Rasterize ODG to BMP in memory
                using (var memoryStream = new MemoryStream())
                {
                    // Set up rasterization options for ODG
                    var odgRasterOptions = new OdgRasterizationOptions
                    {
                        PageSize = odgImage.Size,
                        BackgroundColor = Color.White
                    };

                    // BMP save options with vector rasterization
                    var bmpSaveOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = odgRasterOptions
                    };

                    // Save rasterized image to memory stream
                    odgImage.Save(memoryStream, bmpSaveOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized BMP image
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        // Cast to RasterImage to apply filters
                        var raster = (RasterImage)rasterImage;

                        // Apply median filter with size 5 to the whole image
                        raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as BMP
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