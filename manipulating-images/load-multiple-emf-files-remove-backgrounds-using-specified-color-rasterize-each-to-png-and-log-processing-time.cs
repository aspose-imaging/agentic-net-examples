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
                @"C:\Images\sample1.emf",
                @"C:\Images\sample2.emf"
            };

            // Desired background color for rasterization
            var backgroundColor = Aspose.Imaging.Color.White;

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path (same folder, same name with .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure processing time
                var stopwatch = Stopwatch.StartNew();

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage for specific operations
                    var emfImage = (EmfImage)image;

                    // Optional: remove existing background (if needed)
                    // emfImage.RemoveBackground();

                    // Set up rasterization options with background color
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        BackgroundColor = backgroundColor,
                        PageSize = emfImage.Size
                    };

                    // Set up PNG save options
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

/*
 * Real-World Use Cases:
 * 1. When a .NET application must convert a batch of vector EMF logos to raster PNG thumbnails while ensuring a white background and measuring conversion speed.
 * 2. When an automated reporting tool needs to replace transparent backgrounds in EMF charts with a solid color before exporting them as PNG images for web publishing.
 * 3. When a document‑generation service processes multiple EMF diagrams, removes any existing background, rasterizes them to PNG, and logs the time taken for performance monitoring.
 * 4. When a Windows desktop utility validates the existence of EMF files, converts them to PNG with a specified background color, and stores the results in the same folder for downstream image processing.
 * 5. When a CI/CD pipeline for a graphics‑intensive project benchmarks the rasterization of EMF assets to PNG using Aspose.Imaging and records the elapsed time for each file.
 */