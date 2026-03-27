using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample.png";

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

        // Load ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Prepare PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as PNG
            image.Save(outputPath, pngOptions);
        }

        sw.Stop();
        Console.WriteLine($"Conversion completed in {sw.Elapsed.TotalMilliseconds} ms.");
    }
}