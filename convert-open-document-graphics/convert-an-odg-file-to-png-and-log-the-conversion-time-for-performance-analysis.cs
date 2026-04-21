using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        // Start timing the conversion
        Stopwatch sw = Stopwatch.StartNew();

        // Load the ODG image and save it as PNG
        using (Image image = Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }

        // Stop timing and report duration
        sw.Stop();
        Console.WriteLine($"Conversion completed in {sw.ElapsedMilliseconds} ms.");
    }
}