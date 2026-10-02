// HOW-TO: Batch Rename and Convert EMF Files to Sequential PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");
            int index = 1;

            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, $"{index}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(file))
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.Source = new FileCreateSource(outputPath, false);
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        image.Save(outputPath, pngOptions);
                    }
                }

                index++;
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
 * 1. When you need to process a large set of vector EMF drawings and generate numbered PNG thumbnails for a web gallery.
 * 2. When an automated build creates EMF reports that must be renamed and converted to PNG for inclusion in PDF documentation.
 * 3. When a migration script must replace legacy EMF assets with PNG images while preserving order for a mobile app.
 * 4. When a server‑side service has to read EMF files from an input folder, rasterize them, and save them as sequentially numbered PNG files for downstream processing.
 * 5. When a desktop utility must batch rename and convert EMF icons into PNG sprites with consistent naming for a game UI.
 */
