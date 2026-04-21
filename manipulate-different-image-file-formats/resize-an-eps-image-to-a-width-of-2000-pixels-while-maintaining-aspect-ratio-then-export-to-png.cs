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
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Load the EPS image, resize while keeping aspect ratio, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new height to maintain aspect ratio for a width of 2000 pixels
            int newWidth = 2000;
            int newHeight = (int)Math.Round((double)image.Height * newWidth / image.Width);

            // Resize using Mitchell cubic interpolation
            image.Resize(newWidth, newHeight, ResizeType.Mitchell);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}