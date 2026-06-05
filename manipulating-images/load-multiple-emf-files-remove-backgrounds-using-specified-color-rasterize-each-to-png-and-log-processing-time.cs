using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input EMF files
            string[] inputFiles = new[]
            {
                @"C:\Images\input1.emf",
                @"C:\Images\input2.emf"
            };

            // Color to use when removing background (example: white)
            var backgroundRemovalColor = Aspose.Imaging.Color.White;

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure processing time
                var stopwatch = Stopwatch.StartNew();

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage for background operations
                    var emfImage = image as EmfImage;
                    if (emfImage == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                        continue;
                    }

                    // Set background color (if needed) and remove background
                    emfImage.BackgroundColor = backgroundRemovalColor;
                    emfImage.HasBackgroundColor = true;
                    emfImage.RemoveBackground();

                    // Prepare rasterization options for PNG output
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = backgroundRemovalColor
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save rasterized PNG
                    emfImage.Save(outputPath, pngOptions);
                }

                stopwatch.Stop();
                Console.WriteLine($"Processed '{inputPath}' to '{outputPath}' in {stopwatch.ElapsedMilliseconds} ms.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}