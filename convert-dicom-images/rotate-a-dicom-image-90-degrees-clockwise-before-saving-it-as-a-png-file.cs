using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.dcm";
            string outputPath = @"C:\Temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save as PNG
                dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When a radiology web portal needs to display DICOM scans in the correct orientation on browsers that only support PNG, a developer can rotate the image 90° clockwise and convert it to PNG.
 * 2. When generating printable reports from medical imaging systems, a developer may need to align portrait‑oriented DICOM slices by rotating them and saving as PNG for inclusion in PDF documents.
 * 3. When integrating a DICOM viewer into a C# desktop application that uses standard image controls, the code can rotate the scan and export it as PNG so the UI can render it without additional plugins.
 * 4. When preprocessing DICOM files for machine‑learning pipelines that accept PNG inputs, a developer can correct orientation by rotating 90° clockwise before saving the images.
 * 5. When archiving DICOM images in a file system that requires consistent orientation and a universal format, a developer can rotate the image and store it as a PNG for easy retrieval and sharing.
 */