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
            string inputDir = @"C:\InputDicom";
            string outputDir = @"C:\OutputPng";

            // List of DICOM files to process (hardcoded)
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "image1.dcm"),
                Path.Combine(inputDir, "image2.dcm"),
                Path.Combine(inputDir, "image3.dcm")
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;

                    // Adjust brightness by 10 units
                    dicomImage.AdjustBrightness(10);

                    // Prepare output PNG path
                    string outputPath = Path.Combine(
                        outputDir,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
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
 * 1. When a radiology software needs to convert a batch of DICOM scans to PNG thumbnails while increasing brightness for better visual inspection.
 * 2. When a medical research project requires automated preprocessing of multiple DICOM images to enhance contrast before feeding them into a machine‑learning model that accepts PNG inputs.
 * 3. When a hospital IT team wants to generate patient‑friendly PNG snapshots from DICOM files and apply a uniform brightness boost to improve readability on web portals.
 * 4. When a developer builds a C# utility to archive DICOM studies as lossless PNG files with a consistent brightness offset for consistent archival quality.
 * 5. When a diagnostic imaging workflow automates the conversion of DICOM images to PNG format with a ten‑unit brightness adjustment to standardize display across different viewing applications.
 */