using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "thumb.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the BMP image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Work with raster image for resizing
            Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }

            // Cache data for better performance
            if (!raster.IsCached)
                raster.CacheData();

            // Fixed thumbnail size
            int thumbWidth = 150;
            int thumbHeight = 150;

            // Resize using nearest neighbor resampling
            raster.Resize(thumbWidth, thumbHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

            // Save as BMP with default options (24 bpp)
            BmpOptions saveOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            image.Save(outputPath, saveOptions);
        }
    }
}