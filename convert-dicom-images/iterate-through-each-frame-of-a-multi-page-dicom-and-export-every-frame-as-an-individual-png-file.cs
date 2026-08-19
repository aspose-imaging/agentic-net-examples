// HOW-TO: Extract Each Frame From Multi‑Page DICOM and Save As PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DICOM file path
            string inputPath = @"C:\Temp\multiframe.dcm";
            // Hardcoded output directory
            string outputDir = @"C:\Temp\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open file stream for DICOM image
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DICOM image from stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file path for this page
                        string outputPath = Path.Combine(outputDir, $"frame.{dicomPage.Index}.png");

                        // Ensure directory for this file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert every slice of a multi‑frame medical DICOM study into separate PNG images for analysis or reporting.
 * 2. When a PACS integration requires exporting individual DICOM frames to a web‑friendly format for preview in a browser.
 * 3. When building a batch‑processing tool that extracts each frame from a DICOM file to feed into a machine‑learning pipeline that expects PNG inputs.
 * 4. When creating archival copies of each DICOM frame as lossless PNG files to comply with regulatory documentation standards.
 * 5. When developing a diagnostic application that displays each DICOM slice as a separate PNG thumbnail in a gallery view.
 */
