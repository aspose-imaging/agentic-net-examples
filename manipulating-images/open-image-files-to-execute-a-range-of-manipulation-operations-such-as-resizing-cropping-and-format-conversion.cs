using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string resizedOutputPath = @"C:\Images\output_resized.png";
        string croppedOutputPath = @"C:\Images\output_cropped.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(resizedOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(croppedOutputPath));

        // ---------- Resize operation ----------
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Optional: cache data for better performance on raster images
            if (!image.IsCached) image.CacheData();

            // Resize to 800x600 using default NearestNeighbourResample
            image.Resize(800, 600);

            // Save as PNG
            var pngOptions = new PngOptions();
            image.Save(resizedOutputPath, pngOptions);
        }

        // ---------- Crop operation ----------
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            if (!image.IsCached) image.CacheData();

            // Define crop rectangle (x, y, width, height)
            var cropRect = new Aspose.Imaging.Rectangle(100, 100, 400, 300);
            image.Crop(cropRect);

            // Save as JPEG
            var jpegOptions = new JpegOptions();
            image.Save(croppedOutputPath, jpegOptions);
        }
    }
}