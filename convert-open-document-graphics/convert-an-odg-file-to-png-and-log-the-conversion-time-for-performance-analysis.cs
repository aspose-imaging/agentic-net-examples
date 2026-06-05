using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with ODG rasterization settings
                PngOptions pngOptions = new PngOptions();

                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size,
                    // Optional: set background color for transparent areas
                    BackgroundColor = Color.White
                };

                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }

            sw.Stop();
            Console.WriteLine($"Conversion completed in {sw.Elapsed.TotalMilliseconds} ms.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}