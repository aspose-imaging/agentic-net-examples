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

                // Load the DICOM image
                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    // Iterate through each page (handles single- and multi-page DICOM files)
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build the output PNG file name preserving the original name
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputFileName = $"{baseName}.{page.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
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
 * 1. When a radiology software needs to export a batch of DICOM scans to PNG files for integration with web‑based viewers or reporting tools.
 * 2. When a medical research team wants to convert all DICOM images in a folder to PNG while preserving original filenames for easy correlation with patient data.
 * 3. When an imaging pipeline must generate thumbnail PNGs from multi‑frame DICOM files for a PACS archive index.
 * 4. When a hospital IT department automates nightly conversion of newly received DICOM studies to PNG to feed a machine‑learning model that only accepts standard image formats.
 * 5. When a developer builds a cross‑platform C# utility that processes a directory of DICOM files and saves each page as a separate PNG for use in electronic health record (EHR) systems.
 */