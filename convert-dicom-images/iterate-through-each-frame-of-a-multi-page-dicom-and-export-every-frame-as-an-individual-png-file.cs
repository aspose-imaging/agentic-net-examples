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
            string inputPath = @"c:\temp\multiframe.dicom";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for PNG files
            string outputDir = @"c:\temp\output";

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDir);

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page (frame) of the multi‑page DICOM
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"frame.{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the current page as a PNG image
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
 * 1. When a radiology application must extract each slice from a multi‑frame DICOM study and save them as separate PNG files for web preview or reporting.
 * 2. When a medical‑research pipeline needs to convert every frame of a multi‑page DICOM MRI series into PNG images for machine‑learning model training in C#.
 * 3. When a hospital PACS integration requires batch processing of DICOM files to generate thumbnail PNGs for each frame to display in a patient portal.
 * 4. When a diagnostic device manufacturer wants to automate the conversion of multi‑frame DICOM ultrasound recordings into individual PNG frames for quality‑control documentation using Aspose.Imaging for .NET.
 * 5. When a clinical data‑archiving tool needs to programmatically read a DICOM file stream, iterate over its DicomPages, and export each page as a PNG to a specified folder for downstream analysis.
 */