using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output_resized.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, resize using a specific ResizeType, and save
        using (Image image = Image.Load(inputPath))
        {
            // Example: resize to 800x600 using CatmullRom interpolation
            int newWidth = 800;
            int newHeight = 600;
            image.Resize(newWidth, newHeight, ResizeType.CatmullRom);

            // Save the resized image
            image.Save(outputPath);
        }
    }
}