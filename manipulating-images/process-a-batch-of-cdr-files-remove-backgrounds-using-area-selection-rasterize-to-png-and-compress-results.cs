// HOW-TO: Batch Remove Background from CDR Files and Convert to Compressed PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    VectorImage vector = cdr as VectorImage;
                    if (vector != null)
                    {
                        vector.RemoveBackground(new RemoveBackgroundSettings());
                    }

                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                        Source = new FileCreateSource(outputPath, false),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.Transparent,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    cdr.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically strip logos or watermarks from a collection of CorelDRAW (.cdr) designs before publishing them as web‑ready PNG images.
 * 2. When a printing service must prepare client‑provided CDR artwork for e‑commerce catalogs by removing backgrounds and delivering high‑compression PNG thumbnails.
 * 3. When a desktop application processes user‑uploaded CDR files, cleans the canvas, and stores lightweight PNG previews for fast loading in a gallery view.
 * 4. When a batch conversion tool is required to convert legacy CDR assets to transparent PNGs with maximum zip compression for mobile app assets.
 * 5. When an automated build pipeline needs to generate optimized PNG sprites from multiple CDR source files while eliminating background layers.
 */
