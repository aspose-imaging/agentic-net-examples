// HOW-TO: Batch Convert EMF Files to Progressive JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

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

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        VectorRasterizationOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically transform a collection of vector EMF drawings into web‑optimized progressive JPEG images using C#.
 * 2. When a reporting system generates charts as EMF files and you must deliver them as smaller, progressively loading JPEGs for faster page rendering.
 * 3. When migrating legacy Windows Metafile assets to a modern image format while preserving page size and enabling progressive download in a .NET batch job.
 * 4. When creating a thumbnail gallery where each EMF illustration is rasterized at its original dimensions and saved as a progressive JPEG for better user experience.
 * 5. When integrating Aspose.Imaging into an automated build pipeline to convert design assets from EMF to progressive JPEG without manual intervention.
 */
