using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load, resize, and save the image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Resize to half the original dimensions using nearest neighbour resampling
            image.Resize(image.Width / 2, image.Height / 2, Aspose.Imaging.ResizeType.NearestNeighbourResample);
            // Save as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}