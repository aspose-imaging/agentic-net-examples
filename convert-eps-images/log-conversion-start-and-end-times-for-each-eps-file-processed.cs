using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

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

            foreach (var inputPath in files)
            {
                if (!inputPath.EndsWith(".eps", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Console.WriteLine($"Processing {inputPath} started at {DateTime.Now}");

                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    var options = new PngOptions();
                    image.Save(outputPath, options);
                }

                Console.WriteLine($"Processing {inputPath} finished at {DateTime.Now}");
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
 * 1. When a print shop needs to batch‑convert customer EPS artwork to PNG for web previews and must record how long each file takes to process for performance monitoring.
 * 2. When an automated CI/CD pipeline generates PNG thumbnails from EPS design assets and logs start/end timestamps to detect slow conversions that could delay builds.
 * 3. When a digital asset management system imports EPS logos and stores conversion timestamps in logs to audit processing times and troubleshoot bottlenecks.
 * 4. When a SaaS platform offers on‑the‑fly EPS to PNG conversion and records processing times per request to enforce service‑level agreements.
 * 5. When a developer creates a scheduled Windows service that scans an input folder for EPS files, converts them to PNG, and logs start and finish times to generate daily performance reports.
 */