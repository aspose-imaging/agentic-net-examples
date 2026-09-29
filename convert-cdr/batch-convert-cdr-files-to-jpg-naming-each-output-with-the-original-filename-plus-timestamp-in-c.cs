// HOW-TO: Batch Convert CDR Files to JPG with Timestamped Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchCdrToJpg
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "InputCdrFiles";
                string outputDirectory = "OutputJpgFiles";

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all CDR files in the input directory
                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in cdrFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Build output file name with timestamp
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load CDR and save as JPG
                    using (Image image = Image.Load(inputPath))
                    {
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a folder of CorelDRAW (.cdr) designs into web‑ready JPEG images for publishing.
 * 2. When you want each exported JPEG to retain the original name plus a unique timestamp to avoid overwriting previous versions.
 * 3. When a server‑side C# service must process incoming CDR assets and store them in a separate output directory for downstream workflows.
 * 4. When you are building a migration script that converts legacy vector files to raster format while preserving file organization.
 * 5. When you require a simple, exception‑handled batch routine that loads, converts, and saves images using Aspose.Imaging without manual intervention.
 */
