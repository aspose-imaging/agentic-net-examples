// HOW-TO: Batch Convert PNG Images to JPEG with 64‑Alpha Overlay in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (RasterImage background = (RasterImage)Image.Load(inputPath))
                {
                    // Create temporary overlay image
                    string tempOverlayPath = Path.GetTempFileName();
                    Source overlaySource = new FileCreateSource(tempOverlayPath, false);
                    JpegOptions overlayOptions = new JpegOptions() { Source = overlaySource };
                    using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, background.Width, background.Height))
                    {
                        // Fill overlay with solid black
                        Aspose.Imaging.Color overlayColor = Aspose.Imaging.Color.FromArgb(255, 0, 0, 0);
                        Graphics graphics = new Graphics(overlay);
                        graphics.Clear(overlayColor);

                        // Blend overlay onto background with 64 alpha
                        background.Blend(new Point(0, 0), overlay, 64);
                    }
                    // Delete temporary overlay file
                    if (File.Exists(tempOverlayPath))
                    {
                        try { File.Delete(tempOverlayPath); } catch { }
                    }

                    // Save result as JPEG
                    JpegOptions jpegOptions = new JpegOptions()
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };
                    background.Save(outputPath, jpegOptions);
                }
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
 * 1. When you need to automatically add a semi‑transparent watermark to a collection of PNG graphics and output them as JPEG files for web publishing.
 * 2. When a photo‑editing tool must process dozens of product‑shot PNGs, apply a 64‑alpha overlay for branding, and save the results in a smaller JPEG format.
 * 3. When an e‑commerce platform wants to generate thumbnail JPEGs from high‑resolution PNG assets while applying a consistent translucent overlay.
 * 4. When a batch script has to convert PNG icons to JPEG previews with a 64‑alpha overlay for inclusion in a mobile app’s asset bundle.
 * 5. When a reporting system requires converting PNG charts to JPEG images with a light overlay to match a corporate visual style.
 */
