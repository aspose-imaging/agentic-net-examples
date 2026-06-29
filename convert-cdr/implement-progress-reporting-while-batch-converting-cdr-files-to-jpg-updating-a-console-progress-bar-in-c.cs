using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
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

            // Get all CDR files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (var inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var image = Image.Load(inputPath, new LoadOptions
                {
                    ProgressEventHandler = info => Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}")
                }))
                {
                    using (var jpegOptions = new JpegOptions
                    {
                        Quality = 90,
                        ProgressEventHandler = info => Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}")
                    })
                    {
                        image.Save(outputPath, jpegOptions);
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
 * 1. When a graphic design studio needs to convert a large collection of CorelDRAW (.cdr) assets to web‑ready JPEGs while showing users the conversion progress in a console application.
 * 2. When an automated build pipeline must generate thumbnail previews of CDR files for a digital asset management system and requires real‑time progress feedback to monitor batch processing.
 * 3. When a Windows service processes incoming CDR submissions from clients, converts them to JPEG for archival, and logs the conversion status using Aspose.Imaging’s progress events.
 * 4. When a data migration script moves legacy CDR illustrations to a cloud storage bucket in JPEG format and needs a console progress bar to estimate remaining time for thousands of files.
 * 5. When a QA engineer validates the integrity of batch‑converted images by tracking each file’s load and save progress during CDR‑to‑JPG conversion in a C# test harness.
 */