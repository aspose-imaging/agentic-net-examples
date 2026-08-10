// HOW-TO: Batch Convert EMF Files to PNG at 300 DPI with Lossless Compression in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

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

                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        PngCompressionLevel = PngCompressionLevel.ZipLevel0
                    };

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically convert a folder of vector EMF drawings into high‑resolution PNG images for web publishing.
 * 2. When you must preserve the original quality by rasterizing EMF files at 300 DPI and using lossless PNG compression in a .NET batch process.
 * 3. When a reporting system generates charts as EMF files and you want to export them to PNG for inclusion in PDF reports.
 * 4. When you are building a migration tool that moves legacy EMF assets to a modern image format without manual intervention.
 * 5. When you need to create thumbnail previews of EMF files at a specific resolution for a file‑management application.
 */
