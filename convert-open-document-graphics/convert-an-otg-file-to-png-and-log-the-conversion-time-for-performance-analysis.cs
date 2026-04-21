using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.png";

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

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with OTG rasterization settings
            PngOptions pngOptions = new PngOptions();
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                PageSize = image.Size // Preserve original size
            };
            pngOptions.VectorRasterizationOptions = otgRasterization;

            // Save as PNG
            image.Save(outputPath, pngOptions);
        }

        sw.Stop();
        Console.WriteLine($"Conversion completed in {sw.ElapsedMilliseconds} ms.");
    }
}