// HOW-TO: Batch Convert CDR Files to JPG With Timestamped Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputCdr";
        string outputDirectory = @"C:\OutputJpg";

        try
        {
            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file name with timestamp
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_{timestamp}.jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Save as JPEG
                    JpegOptions jpegOptions = new JpegOptions();
                    cdrImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to archive a folder of CorelDRAW (.cdr) drawings as JPEG images and ensure each file has a unique timestamped name for version tracking.
 * 2. When an automated build process must generate web‑ready thumbnails from CDR assets and store them with timestamps to avoid filename collisions.
 * 3. When a migration script converts legacy CDR design files to JPEG format for a content management system that requires timestamped filenames for audit trails.
 * 4. When a desktop application processes user‑uploaded CDR files in bulk, saving them as JPEGs with timestamps to preserve the original filenames while indicating conversion time.
 * 5. When a scheduled job periodically converts newly added CDR files to JPEG and appends a timestamp to each output to support incremental backups.
 */
