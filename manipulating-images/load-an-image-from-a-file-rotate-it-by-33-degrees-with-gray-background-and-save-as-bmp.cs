using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output/output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load, rotate, and save the image
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Rotate 33 degrees, resize proportionally, gray background
            image.Rotate(33f, true, Aspose.Imaging.Color.Gray);

            // Save as BMP
            BmpOptions options = new BmpOptions() { Source = new FileCreateSource(outputPath, false) };
            image.Save(outputPath, options);
        }
    }
}