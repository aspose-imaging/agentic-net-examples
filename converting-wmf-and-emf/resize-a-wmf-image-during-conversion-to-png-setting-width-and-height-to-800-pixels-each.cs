using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample_resized.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image, resize to 800x800, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Resize to the required dimensions (default nearest neighbour resample)
            image.Resize(800, 800);

            // Save as PNG using default options
            image.Save(outputPath, new PngOptions());
        }
    }
}