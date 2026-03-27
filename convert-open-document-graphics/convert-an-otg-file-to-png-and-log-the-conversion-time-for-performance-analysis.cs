using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.otg";
        string outputPath = "output\\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Measure conversion time
        Stopwatch sw = Stopwatch.StartNew();

        // Load OTG image and save as PNG using rasterization options
        using (Image image = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions();
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };
            pngOptions.VectorRasterizationOptions = otgRasterOptions;

            image.Save(outputPath, pngOptions);
        }

        sw.Stop();
        Console.WriteLine($"Conversion completed in {sw.ElapsedMilliseconds} ms.");
    }
}