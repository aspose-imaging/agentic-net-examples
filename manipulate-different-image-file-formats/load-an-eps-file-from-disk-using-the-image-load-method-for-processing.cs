using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
        {
            outputDir = "."; // current directory
        }
        Directory.CreateDirectory(outputDir);

        // Load EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Optional: cast to EpsImage if EPS‑specific properties are needed
            // var epsImage = (EpsImage)image;

            // Save as PNG (demonstrates processing)
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}