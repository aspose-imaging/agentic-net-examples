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

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image, resize it, and save as high‑resolution PNG
        using (Image image = Image.Load(inputPath))
        {
            // Resize to desired dimensions using a high‑quality interpolation method
            image.Resize(2000, 2000, ResizeType.Mitchell);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}