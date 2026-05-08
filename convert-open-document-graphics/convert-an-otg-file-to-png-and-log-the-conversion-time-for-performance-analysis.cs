using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Load OTG image and save as PNG with rasterization options
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options
                PngOptions pngOptions = new PngOptions();

                // Set vector rasterization options for OTG
                OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size // Preserve original size
                };
                pngOptions.VectorRasterizationOptions = otgRaster;

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }

            stopwatch.Stop();
            Console.WriteLine($"Conversion time: {stopwatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}