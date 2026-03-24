using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmz";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary raster file path
        string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

        // Rasterize the WMZ (vector) image to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = vectorImage.Size,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            vectorImage.Save(tempPath, pngOptions);
        }

        // Apply edge detection (sharpen) filter to the rasterized image
        using (Image rasterImage = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)rasterImage;
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
            raster.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary file
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}