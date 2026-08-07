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
            string inputPath = "c:\\temp\\multiframe.dicom";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page (frame) in the DICOM image
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Construct output PNG file path for the current page
                        string outputPath = Path.Combine("c:\\temp\\", $"frame.{dicomPage.Index}.png");

                        // Ensure the output directory exists
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
 * 1. When a radiology software needs to extract each slice from a multi‑frame DICOM study and store them as separate PNG files for web preview or reporting.
 * 2. When a medical imaging workflow requires converting DICOM frames to PNG so that non‑DICOM viewers can display individual images on a hospital intranet.
 * 3. When a research project wants to batch‑process every frame of a multi‑slice MRI DICOM file in C# and save them as lossless PNGs for machine‑learning model training.
 * 4. When a PACS integration needs to archive each DICOM frame as a PNG thumbnail to embed in electronic health record (EHR) notes.
 * 5. When a developer builds a diagnostic mobile app that downloads a multi‑page DICOM and must render each frame as a PNG for offline viewing on iOS or Android devices.
 */