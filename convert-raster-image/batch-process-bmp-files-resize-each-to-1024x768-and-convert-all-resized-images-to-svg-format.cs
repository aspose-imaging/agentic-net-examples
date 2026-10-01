// HOW-TO: Batch Resize BMP Images to 1024x768 and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Resize(1024, 768);
                    using (SvgOptions options = new SvgOptions())
                    {
                        image.Save(outputPath, options);
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
 * 1. When you need to automatically shrink a collection of legacy BMP graphics to a standard web‑friendly resolution before converting them to scalable SVG files for responsive design.
 * 2. When a desktop application must process user‑uploaded BMP screenshots, resize them to 1024×768, and store them as SVGs to reduce file size and enable infinite scaling.
 * 3. When migrating an old asset library of BMP icons to vector format, you can batch resize each icon and save it as SVG for use in modern UI frameworks.
 * 4. When generating printable PDFs from BMP drawings, you first resize the images to a consistent size and convert them to SVG to preserve quality at any zoom level.
 * 5. When building an automated build pipeline that prepares BMP assets for a web game, the code resizes each image to the required resolution and outputs SVGs for fast rendering in browsers.
 */
