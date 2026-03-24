using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string resizedPath = @"C:\temp\output_resized.png";
        string croppedPath = @"C:\temp\output_cropped.png";
        string convertedPath = @"C:\temp\output_converted.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(resizedPath));
        Directory.CreateDirectory(Path.GetDirectoryName(croppedPath));
        Directory.CreateDirectory(Path.GetDirectoryName(convertedPath));

        // ---------- Resize PNG (maintain lossless PNG) ----------
        using (PngImage png = new PngImage(inputPath))
        {
            // Resize to 200x200 pixels
            png.Resize(200, 200);
            // Save resized image preserving PNG options
            png.Save(resizedPath);
        }

        // ---------- Crop PNG ----------
        using (PngImage png = new PngImage(inputPath))
        {
            // Define crop rectangle (x, y, width, height)
            var cropRect = new Rectangle(50, 50, 100, 100);
            // Crop the image
            png.Crop(cropRect);
            // Save cropped image
            png.Save(croppedPath);
        }

        // ---------- Convert PNG to BMP (lossless conversion) ----------
        using (PngImage png = new PngImage(inputPath))
        {
            // Create BMP options (default lossless settings)
            var bmpOptions = new BmpOptions();
            // Save as BMP using the options
            png.Save(convertedPath, bmpOptions);
        }
    }
}