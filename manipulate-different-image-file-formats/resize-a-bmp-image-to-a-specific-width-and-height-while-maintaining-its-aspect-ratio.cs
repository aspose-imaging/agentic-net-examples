using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Desired maximum dimensions while preserving aspect ratio
        int targetWidth = 800;   // example width
        int targetHeight = 600;  // example height

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cache raster data for better performance
            if (!image.IsCached) image.CacheData();

            // Calculate scaling factor to maintain aspect ratio
            double widthRatio = (double)targetWidth / image.Width;
            double heightRatio = (double)targetHeight / image.Height;
            double scale = Math.Min(widthRatio, heightRatio);

            int newWidth = (int)Math.Round(image.Width * scale);
            int newHeight = (int)Math.Round(image.Height * scale);

            // Resize the image
            image.Resize(newWidth, newHeight);

            // Save the resized image as BMP
            BmpOptions options = new BmpOptions();
            image.Save(outputPath, options);
        }
    }
}