using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\source.eps";
        string outputPath = @"C:\Images\result.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new height to preserve aspect ratio for a width of 2000 pixels
            int newWidth = 2000;
            int newHeight = (int)((double)image.Height * newWidth / image.Width);

            // Resize using a high‑quality interpolation method
            image.Resize(newWidth, newHeight, ResizeType.Mitchell);

            // Save the resized image as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}