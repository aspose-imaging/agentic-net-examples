using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.bmp";
        string outputPath = @"C:\Images\thumbnails\thumb.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired thumbnail dimensions
        const int thumbWidth = 150;
        const int thumbHeight = 150;

        // Load BMP image, resize, and save as thumbnail
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!raster.IsCached)
                raster.CacheData();

            // Resize to fixed thumbnail size (default nearest neighbour resample)
            raster.Resize(thumbWidth, thumbHeight);

            // Save using default BMP options
            BmpOptions saveOptions = new BmpOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}