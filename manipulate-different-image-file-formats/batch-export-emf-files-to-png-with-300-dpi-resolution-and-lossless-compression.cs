using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

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

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    using (var pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = vectorOptions;
                        pngOptions.PngCompressionLevel = PngCompressionLevel.ZipLevel9;
                        pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When a developer needs to convert a large collection of Windows Metafile (EMF) diagrams into high‑resolution PNG images for inclusion in PDF reports or web documentation, they can use this batch export code.
 * 2. When a legacy engineering application stores schematics as EMF files and the team must archive them as lossless PNGs at 300 DPI for long‑term preservation, the code automates the process.
 * 3. When an e‑learning platform requires vector‑based illustrations to be rendered as pixel‑perfect PNG assets for responsive HTML5 courses, the developer can run this routine to rasterize the EMFs with a white background and maximum compression.
 * 4. When a CI/CD pipeline needs to generate preview thumbnails of EMF icons for a UI design system, the batch converter creates consistent PNG previews without manual intervention.
 * 5. When a print shop receives client artwork in EMF format and must supply print‑ready PNG files at 300 DPI with lossless compression for high‑quality proofs, this C# script handles the conversion in bulk.
 */