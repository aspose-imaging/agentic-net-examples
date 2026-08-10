// HOW-TO: Limit Parallel Image Conversion to PNG with Controlled Memory Usage in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
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

            string[] files = Directory.GetFiles(inputDirectory);

            // Limit concurrency to avoid excessive memory consumption
            var parallelOptions = new System.Threading.Tasks.ParallelOptions
            {
                MaxDegreeOfParallelism = 4 // adjust as needed
            };

            System.Threading.Tasks.Parallel.ForEach(files, parallelOptions, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (var options = new PngOptions())
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
 * 1. When processing a large folder of mixed‑format images on a server and you need to convert them to PNG without exhausting RAM.
 * 2. When building a desktop utility that batch‑converts user‑uploaded photos to PNG while keeping CPU usage predictable.
 * 3. When automating image preparation for a web application and must limit the number of simultaneous conversions to stay within memory limits.
 * 4. When migrating legacy image assets to a standardized PNG format in a CI pipeline and want to avoid out‑of‑memory crashes.
 * 5. When creating a background service that watches a directory and converts new files to PNG, using a fixed parallelism level to ensure stable performance.
 */
