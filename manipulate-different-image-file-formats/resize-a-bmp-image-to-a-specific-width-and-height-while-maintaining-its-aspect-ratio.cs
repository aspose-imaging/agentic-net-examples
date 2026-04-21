using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\resized.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired maximum dimensions
        int targetWidth = 800;
        int targetHeight = 600;

        // Load BMP image, compute proportional size, resize, and save
        using (BmpImage image = (BmpImage)Image.Load(inputPath))
        {
            float widthScale = (float)targetWidth / image.Width;
            float heightScale = (float)targetHeight / image.Height;
            float scale = Math.Min(widthScale, heightScale);

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            image.Resize(newWidth, newHeight); // default NearestNeighbourResample

            BmpOptions options = new BmpOptions();
            image.Save(outputPath, options);
        }
    }
}