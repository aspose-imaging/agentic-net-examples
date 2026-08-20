// HOW-TO: Log Start and End Times While Converting EPS to PNG in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var filePath in files)
            {
                if (!filePath.EndsWith(".eps", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Console.WriteLine($"Processing {filePath} started at {DateTime.Now}");

                using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(filePath))
                {
                    using (var options = new PngOptions())
                    {
                        image.Save(outputPath, options);
                    }
                }

                Console.WriteLine($"Processing {filePath} finished at {DateTime.Now}");
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
 * 1. When you need to batch‑convert a folder of EPS vector files to PNG images while recording the exact processing time for each file for performance monitoring.
 * 2. When an automated image pipeline must generate an audit log of start and finish timestamps for every EPS conversion to meet compliance or debugging requirements.
 * 3. When you want to measure and compare the conversion speed of different EPS files using Aspose.Imaging in a C# application.
 * 4. When a reporting tool requires timestamps of image generation to synchronize graphics with other data sources in a .NET workflow.
 * 5. When you are building a scheduled service that processes incoming EPS assets and needs to log processing durations for alerting on unusually long conversions.
 */
