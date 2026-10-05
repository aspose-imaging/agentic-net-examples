// HOW-TO: Batch Convert BMP Files To PNG Using Multithreaded C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
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
                    using (PngOptions options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly convert a large collection of legacy BMP images to PNG for web delivery while preserving original filenames.
 * 2. When an automated build or deployment pipeline must process image assets in parallel to reduce conversion time on a multi‑core server.
 * 3. When a desktop application imports user‑provided BMP screenshots and stores them as lossless PNGs for archival purposes.
 * 4. When a migration script moves graphic assets from an old Windows application to a modern platform that only supports PNG.
 * 5. When a cloud function or background service needs to batch‑process uploaded BMP files into PNG without blocking the main thread.
 */
