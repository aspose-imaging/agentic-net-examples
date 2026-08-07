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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image and convert to PNG
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a hospital’s PACS system needs to validate incoming DICOM scans for corruption before converting them to PNG thumbnails for web viewers.
 * 2. When a research lab automates the preprocessing of radiology images and wants to skip any malformed DICOM files to avoid runtime errors during batch PNG export.
 * 3. When a telemedicine app receives patient imaging files and must ensure each DICOM file is valid before generating PNG snapshots for mobile display.
 * 4. When a medical device manufacturer integrates a C# service that checks the integrity of DICOM output using Image.IsValid before storing PNG versions in a cloud archive.
 * 5. When a health‑IT consultant builds a diagnostic reporting tool that loads DICOM files, verifies them with Image.IsValid, and then saves them as PNG for inclusion in PDF reports.
 */