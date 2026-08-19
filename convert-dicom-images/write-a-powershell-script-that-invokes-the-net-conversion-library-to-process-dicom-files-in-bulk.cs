// HOW-TO: Bulk Convert DICOM Files To PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add DICOM files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                using (var options = new PngOptions())
                {
                    image.Save(outputPath, options);
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

/*
 * Real-World Use Cases:
 * 1. When a hospital needs to export thousands of DICOM scans to PNG for integration with a web‑based viewer.
 * 2. When a research lab wants to batch‑convert medical images to a lossless format for machine‑learning preprocessing.
 * 3. When a developer must automate the creation of thumbnail PNGs from DICOM files for a PACS archive UI.
 * 4. When a radiology software vendor requires a command‑line tool to transform incoming DICOM studies into PNG for reporting tools.
 * 5. When an IT team needs to ensure all DICOM files in a folder are safely converted to PNG before archiving them to a cloud storage service.
 */
