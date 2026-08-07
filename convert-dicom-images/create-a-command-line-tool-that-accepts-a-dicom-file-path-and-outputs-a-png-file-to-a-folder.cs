using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file path and output folder path
        string inputPath = @"C:\temp\input.dcm";
        string outputFolder = @"C:\temp\output\";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page in the DICOM image
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output PNG file path for the current page
                        string outputPath = Path.Combine(outputFolder, $"page_{dicomPage.Index}.png");

                        // Ensure the output directory exists before saving
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a PNG image
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology department needs to export DICOM scans as PNG files for inclusion in patient reports or presentations.
 * 2. When a medical imaging researcher wants to batch‑convert DICOM image series to PNG for use in machine‑learning pipelines written in C#.
 * 3. When a hospital IT team must provide a simple command‑line utility to extract individual DICOM frames as PNGs for integration with electronic health record systems.
 * 4. When a developer is building a cross‑platform diagnostic web app and needs to pre‑process DICOM files into PNG thumbnails on a Windows server.
 * 5. When a quality‑control engineer requires automated conversion of DICOM files to PNG to compare visual output against reference images during software testing.
 */