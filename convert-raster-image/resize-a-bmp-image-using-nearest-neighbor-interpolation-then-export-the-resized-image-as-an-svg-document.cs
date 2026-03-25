using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.bmp";
        string resizedBmpPath = @"C:\Images\output\resized.bmp";
        string resizedSvgPath = @"C:\Images\output\resized.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(resizedBmpPath));
        Directory.CreateDirectory(Path.GetDirectoryName(resizedSvgPath));

        // Load the BMP image, resize using nearest‑neighbor (default), and save as BMP and SVG
        using (Image image = Image.Load(inputPath))
        {
            // Desired dimensions for the resized image
            int newWidth = image.Width / 2;   // example: half the original width
            int newHeight = image.Height / 2; // example: half the original height

            // Resize with default NearestNeighbourResample
            image.Resize(newWidth, newHeight);

            // Save the resized raster image as BMP
            image.Save(resizedBmpPath);

            // Save the same resized image as SVG
            image.Save(resizedSvgPath, new SvgOptions());
        }
    }
}