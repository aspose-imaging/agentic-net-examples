// HOW-TO: Batch Convert DICOM Files to PNG with Original Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "InputDicom";
            string outputDirectory = "OutputPng";

            Directory.CreateDirectory(outputDirectory);

            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in dicomFiles)
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
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a hospital needs to export a folder of DICOM scans to PNG for easy viewing in web browsers.
 * 2. When a research lab wants to create thumbnail previews of thousands of DICOM images for a machine‑learning dataset.
 * 3. When a PACS administrator must archive radiology images as lossless PNG files while keeping the original file names.
 * 4. When a developer integrates Aspose.Imaging into a C# application to automate conversion of medical images for a reporting tool.
 * 5. When a QA team validates that all DICOM files in a directory can be successfully rendered as PNG without manual intervention.
 */
