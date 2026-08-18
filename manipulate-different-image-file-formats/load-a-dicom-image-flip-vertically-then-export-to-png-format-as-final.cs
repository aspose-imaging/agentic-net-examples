// HOW-TO: How To Flip A DICOM Image Vertically And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.dcm";
        string outputPath = "sample_flipped.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Flip the image vertically
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Save the result as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to display a DICOM scan in a different orientation, developers can flip the image vertically and convert it to PNG for web viewing.
 * 2. When integrating DICOM files into a patient portal, you may need to transform the image to a widely supported PNG format after correcting its orientation.
 * 3. When preparing radiology images for machine‑learning pipelines that require PNG inputs, flipping the DICOM vertically ensures consistent orientation across the dataset.
 * 4. When generating printable reports from DICOM studies, converting the flipped image to PNG simplifies embedding the graphic in PDF or Word documents.
 * 5. When troubleshooting orientation issues in a PACS viewer, developers can use this code to quickly flip and export a DICOM slice to PNG for side‑by‑side comparison.
 */
