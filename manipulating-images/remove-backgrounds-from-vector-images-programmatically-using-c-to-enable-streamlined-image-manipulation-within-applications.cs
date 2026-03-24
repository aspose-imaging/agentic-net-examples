using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector type
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground();
            }

            // Save the processed image as PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}