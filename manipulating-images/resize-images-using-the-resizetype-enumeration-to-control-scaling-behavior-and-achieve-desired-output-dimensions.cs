using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Resize the image to half its original dimensions using Bilinear resampling
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;
            image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save the resized image to the output path
            image.Save(outputPath);
        }
    }
}