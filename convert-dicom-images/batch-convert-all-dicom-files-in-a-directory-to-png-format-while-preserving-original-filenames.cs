// HOW-TO: Batch Convert DICOM Files to PNG with Original Filenames in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputDicom";
            string outputDirectory = @"C:\OutputPng";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DICOM file as a stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load the DICOM image
                    using (DicomImage dicomImage = new DicomImage(stream))
                    {
                        // Process each page in the DICOM image
                        foreach (DicomPage dicomPage in dicomImage.DicomPages)
                        {
                            // Build the output file name (preserve original name, add page index if multi‑page)
                            string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
                            string outputFileName = $"{baseFileName}.{dicomPage.Index}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            dicomPage.Save(outputPath, new PngOptions());
                        }
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
 * 1. When a radiology department needs to export a whole folder of DICOM scans as PNG images for integration with a web‑based viewer.
 * 2. When a research project requires converting multi‑frame DICOM series into separate PNG files while keeping the original study identifiers.
 * 3. When an automated pipeline must generate thumbnail PNGs from incoming DICOM files for quick preview in a medical records system.
 * 4. When a developer wants to archive DICOM images as lossless PNGs on a file server without altering the original file names.
 * 5. When a healthcare app needs to batch process patient scans and store each DICOM page as an individual PNG for downstream AI analysis.
 */
