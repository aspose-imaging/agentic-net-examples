using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of EMF input files
            string[] inputFiles = new[]
            {
                @"C:\Images\Input1.emf",
                @"C:\Images\Input2.emf",
                @"C:\Images\Input3.emf"
            };

            // Desired background color to remove (e.g., white)
            Color backgroundColor = Color.White;

            foreach (string inputPath in inputFiles)
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
                Stopwatch sw = Stopwatch.StartNew();

                // Load EMF image
                using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
                {
                    // Set background color information
                    emfImage.HasBackgroundColor = true;
                    emfImage.BackgroundColor = backgroundColor;

                    // Remove background
                    emfImage.RemoveBackground();

                    // Prepare rasterization options for PNG output
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Color.Transparent // ensure transparent background in PNG
                    };

                    // PNG save options with vector rasterization
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save rasterized PNG
                    emfImage.Save(outputPath, pngOptions);
                }

                sw.Stop();
                Console.WriteLine($"Processed '{Path.GetFileName(inputPath)}' in {sw.ElapsedMilliseconds} ms, saved to '{outputPath}'.");
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
 * 1. When a developer needs to batch‑convert legacy EMF vector graphics from a design repository into web‑ready PNG files with transparent backgrounds for inclusion in HTML pages.
 * 2. When an automated reporting tool must strip white paper backgrounds from EMF charts before embedding them as PNG images in PDF invoices.
 * 3. When a Windows desktop application generates EMF icons that must be exported as PNG thumbnails with no background for display in a mobile app gallery.
 * 4. When a migration script processes multiple EMF logos stored on a file server, removes their background color, and logs the processing time to monitor performance.
 * 5. When a CI/CD pipeline validates that EMF assets are correctly rasterized to PNG with transparent backgrounds and records the elapsed time for each conversion to detect regressions.
 */