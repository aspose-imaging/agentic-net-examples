using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image, cast to RasterImage for pixel operations
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Cache data for better performance
            if (!raster.IsCached)
                raster.CacheData();

            // Crop to a rectangle (x=100, y=100, width=400, height=300)
            var cropRect = new Aspose.Imaging.Rectangle(100, 100, 400, 300);
            raster.Crop(cropRect);

            // Rotate 45 degrees around the center
            raster.Rotate(45f);

            // Resize to 800x600 using default nearest‑neighbour resampling
            raster.Resize(800, 600);

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}