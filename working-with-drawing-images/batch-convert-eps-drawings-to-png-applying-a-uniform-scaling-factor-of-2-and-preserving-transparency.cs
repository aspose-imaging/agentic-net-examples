// HOW-TO: Batch Convert EPS to PNG with Double Size and Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image epsImage = Aspose.Imaging.Image.Load(inputPath))
                {
                    int newWidth = epsImage.Width * 2;
                    int newHeight = epsImage.Height * 2;

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = newWidth,
                            PageHeight = newHeight,
                            BackgroundColor = Aspose.Imaging.Color.Transparent
                        }
                    };

                    epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate high‑resolution PNG thumbnails from a folder of vector EPS logos while keeping their transparent background.
 * 2. When an e‑commerce platform must convert supplier EPS artwork to double‑sized PNG images for product listings without losing transparency.
 * 3. When a publishing workflow requires automated batch conversion of EPS illustrations to PNG files at twice the original dimensions for print‑ready PDFs.
 * 4. When a mobile app backend has to preprocess EPS icons into larger PNG assets to match device screen densities while preserving alpha channels.
 * 5. When a GIS system needs to rasterize multiple EPS map layers into transparent PNG tiles at double resolution for web mapping.
 */
