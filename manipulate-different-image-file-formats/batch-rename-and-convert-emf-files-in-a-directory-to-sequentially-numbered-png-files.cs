// HOW-TO: Batch Rename and Convert EMF Files to Sequential PNGs in C# (Aspose.Imaging for .NET)
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

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");
            int index = 1;

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, $"image_{index}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to process a folder of vector EMF drawings and generate numbered PNG thumbnails for a web gallery.
 * 2. When an automated build script must rename and rasterize EMF icons into PNG assets with consistent naming for a mobile app.
 * 3. When migrating legacy EMF reports to a modern system that only accepts PNG images and requires sequential file names.
 * 4. When creating batch image conversion tools that read EMF files from an input directory and output PNGs for further processing in machine‑learning pipelines.
 * 5. When preparing documentation assets by converting multiple EMF diagrams to PNG format and naming them automatically for inclusion in PDF manuals.
 */
