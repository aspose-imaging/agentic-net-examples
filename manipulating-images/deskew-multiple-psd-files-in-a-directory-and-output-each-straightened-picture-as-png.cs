// HOW-TO: Batch Deskew PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add PSD files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PSD files
            string[] files = Directory.GetFiles(inputDir, "*.psd");

            foreach (string inputPath in files)
            {
                // Validate each input file
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output PNG path
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load PSD as raster image and deskew
                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.NormalizeAngle(false, Color.LightGray);

                    // Save as PNG
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically straighten scanned Photoshop documents in a folder and convert them to web‑friendly PNGs using C#.
 * 2. When a graphics pipeline must process multiple PSD layers, correct their rotation, and output lossless PNGs for further editing.
 * 3. When an e‑commerce site requires batch conversion of uploaded PSD product mockups into correctly oriented PNG thumbnails.
 * 4. When a digital archiving tool has to normalize the angle of legacy PSD files before storing them as PNG images for searchable archives.
 * 5. When a Windows service has to monitor a directory, deskew any new PSD files, and save the corrected images as PNGs for downstream processing.
 */
