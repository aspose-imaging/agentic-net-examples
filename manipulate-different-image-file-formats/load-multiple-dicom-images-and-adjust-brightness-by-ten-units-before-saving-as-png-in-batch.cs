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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputDicom\";
            string outputDir = @"C:\OutputPng\";

            // List of DICOM files to process
            string[] dicomFiles = new[]
            {
                "image1.dcm",
                "image2.dcm",
                "image3.dcm"
            };

            foreach (string fileName in dicomFiles)
            {
                // Build full paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputFileName = Path.ChangeExtension(fileName, ".png");
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image, adjust brightness, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;
                    dicomImage.AdjustBrightness(10); // increase brightness by ten units
                    dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When a radiology department needs to convert a set of DICOM scans to PNG thumbnails with increased brightness for quick visual review in a web portal.
 * 2. When a medical imaging software vendor wants to preprocess patient CT images by batch‑adjusting brightness before exporting them to PNG for inclusion in printed reports.
 * 3. When a research lab automates the preparation of DICOM MRI datasets for machine‑learning pipelines that require PNG inputs with standardized brightness levels.
 * 4. When a hospital’s IT team creates a nightly job that loads multiple DICOM files, brightens them by ten units, and stores the results as PNG files for archival in a PACS‑compatible format.
 * 5. When a developer builds a C# utility that reads DICOM images from a folder, applies a uniform brightness boost, and saves them as PNGs to be used in a mobile health‑care application.
 */