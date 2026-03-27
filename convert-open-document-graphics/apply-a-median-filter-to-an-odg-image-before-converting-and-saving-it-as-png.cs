using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare PNG rasterization options for vector image
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = odgImage.Size
            };

            // Rasterize ODG to a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                odgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as RasterImage
                using (Image rasterImageBase = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageBase;

                    // Apply median filter with size 5 to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered raster image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}