using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output\\resized.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Calculate new dimensions (half size)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize the animation
            image.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

            // Save as APNG
            image.Save(outputPath, new ApngOptions());
        }
    }
}