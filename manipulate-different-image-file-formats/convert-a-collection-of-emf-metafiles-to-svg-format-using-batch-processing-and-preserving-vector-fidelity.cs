// HOW-TO: Batch Convert EMF Files to SVG with Vector Fidelity in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (SvgOptions options = new SvgOptions())
                    {
                        var rasterOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                        options.VectorRasterizationOptions = rasterOptions;
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
 * 1. When you need to migrate a library of legacy EMF diagrams to web‑compatible SVG files while keeping the original vector quality.
 * 2. When you want to automate the conversion of all EMF icons in a folder to scalable SVG assets for a responsive UI.
 * 3. When you are preparing print‑ready graphics and must preserve exact dimensions by converting EMF to SVG in a batch process.
 * 4. When a CI/CD pipeline must generate SVG versions of EMF charts for documentation generation without manual intervention.
 * 5. When you are building a cross‑platform application that requires vector images in SVG format and you have existing EMF resources to convert programmatically.
 */
