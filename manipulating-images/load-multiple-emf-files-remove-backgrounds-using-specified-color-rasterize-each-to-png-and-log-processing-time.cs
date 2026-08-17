// HOW-TO: Batch Convert EMF to PNG with Background Removal and Timing in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input EMF files (modify as needed)
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.emf",
                @"C:\Images\sample2.emf",
                @"C:\Images\sample3.emf"
            };

            // Desired background color to remove (example: white)
            var backgroundColorToRemove = Aspose.Imaging.Color.White;

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path (same folder, same name with .png)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure processing time
                var stopwatch = Stopwatch.StartNew();

                // Load EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to EmfImage for background operations
                    var emfImage = (EmfImage)image;

                    // Set the background color that should be treated as background
                    emfImage.BackgroundColor = backgroundColorToRemove;

                    // Remove the background (makes it transparent)
                    emfImage.RemoveBackground();

                    // Prepare rasterization options for PNG output
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Aspose.Imaging.Color.Transparent
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save rasterized PNG
                    emfImage.Save(outputPath, pngOptions);
                }

                stopwatch.Stop();
                Console.WriteLine($"Processed '{inputPath}' -> '{outputPath}' in {stopwatch.ElapsedMilliseconds} ms");
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
 * 1. When you need to convert a set of vector EMF diagrams into web‑ready PNG images while making the white page background transparent.
 * 2. When an automated build process must generate PNG thumbnails from EMF icons and ensure the background color is removed for seamless UI integration.
 * 3. When a reporting tool exports charts as EMF files and you want to rasterize them to PNG with transparent backgrounds for inclusion in PDF reports.
 * 4. When performance monitoring is required while batch processing EMF files, so you log the time taken for each conversion to optimize the workflow.
 * 5. When migrating legacy Windows Metafile assets to a modern format, you need to programmatically strip unwanted backgrounds and save them as PNG using C# and Aspose.Imaging.
 */
