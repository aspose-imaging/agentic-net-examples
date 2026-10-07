// HOW-TO: Log Start and End Timestamps for Batch Image Processing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

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

                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Console.WriteLine($"Processing started: {DateTime.Now:O} - {inputPath}");

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath);
                }

                Console.WriteLine($"Processing completed: {DateTime.Now:O} - {outputPath}");
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
 * 1. When you need to audit how long each image conversion takes in a nightly batch job that reads files from an Input folder and saves them to an Output folder using Aspose.Imaging.
 * 2. When you want to generate a simple console log that records the exact start and finish times for processing JPEG, PNG, or TIFF files in a C# application.
 * 3. When you must ensure that missing input files are reported and processing timestamps are captured for troubleshooting in an automated image pipeline.
 * 4. When you are building a lightweight monitoring solution that tracks processing duration for each image without adding external logging frameworks.
 * 5. When you require a quick way to create input and output directories, process all supported image formats, and log timestamps for compliance reporting.
 */
