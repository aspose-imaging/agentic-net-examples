using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "templates/sample.png";
        string outputPath = "output/sample_grayscale.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image using Aspose.Imaging.Image.Load
        using (Image image = Image.Load(inputPath))
        {
            // Example processing: convert to grayscale (optional)
            if (image is Aspose.Imaging.FileFormats.Png.PngImage pngImage)
            {
                pngImage.Grayscale();
            }

            // Save the processed image to the output path
            image.Save(outputPath);
        }
    }
}