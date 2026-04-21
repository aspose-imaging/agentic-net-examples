using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output/output.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (WebPImage image = new WebPImage(inputPath))
            {
                // Cache data for better performance
                if (!image.IsCached) image.CacheData();

                // Desired crop size
                int cropWidth = 200;
                int cropHeight = 200;

                // Calculate top-left corner to center the crop region
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;

                // Adjust if the image is smaller than the desired crop size
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                int actualCropWidth = Math.Min(cropWidth, image.Width);
                int actualCropHeight = Math.Min(cropHeight, image.Height);

                // Perform cropping
                var rect = new Rectangle(x, y, actualCropWidth, actualCropHeight);
                image.Crop(rect);

                // Save with default options
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}