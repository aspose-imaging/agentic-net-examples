// HOW-TO: Bulk Convert DICOM Files to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

namespace DicomBulkConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "C:\\DicomInput";
                string outputDirectory = "C:\\DicomOutput";

                // Ensure base output directory exists
                Directory.CreateDirectory(outputDirectory);

                string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

                foreach (string inputPath in dicomFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (DicomImage image = (DicomImage)Image.Load(inputPath))
                    {
                        var options = new PngOptions();
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
}

/*
 * Real-World Use Cases:
 * 1. When a hospital needs to export thousands of DICOM scans to PNG for integration with a web‑based viewer.
 * 2. When a research lab wants to batch‑convert medical images to a lossless format for machine‑learning preprocessing.
 * 3. When a PACS administrator must generate thumbnail PNGs from DICOM studies for quick preview in a reporting tool.
 * 4. When a developer automates the migration of legacy DICOM archives to a cloud storage system that only accepts PNG files.
 * 5. When a software vendor creates a command‑line utility to transform DICOM images into PNG for inclusion in patient education PDFs.
 */
