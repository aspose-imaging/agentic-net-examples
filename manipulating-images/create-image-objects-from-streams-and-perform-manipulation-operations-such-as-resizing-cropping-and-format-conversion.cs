using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string resizedOutputPath = @"C:\temp\output_resized.png";
        string croppedOutputPath = @"C:\temp\output_cropped.bmp";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(resizedOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(croppedOutputPath));

        // Load the image, resize it, and save as PNG (format conversion)
        using (Image image = Image.Load(inputPath))
        {
            // Resize to 800x600 using default resampling
            image.Resize(800, 600);

            // Save resized image as PNG
            var pngOptions = new PngOptions();
            image.Save(resizedOutputPath, pngOptions);
        }

        // Load the image again, crop a central region, and save as BMP
        using (Image image = Image.Load(inputPath))
        {
            // Define a rectangle that represents the central half of the image
            int cropX = image.Width / 4;
            int cropY = image.Height / 4;
            int cropWidth = image.Width / 2;
            int cropHeight = image.Height / 2;
            var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Perform cropping
            image.Crop(cropRect);

            // Save cropped image as BMP
            var bmpOptions = new BmpOptions();
            image.Save(croppedOutputPath, bmpOptions);
        }
    }
}