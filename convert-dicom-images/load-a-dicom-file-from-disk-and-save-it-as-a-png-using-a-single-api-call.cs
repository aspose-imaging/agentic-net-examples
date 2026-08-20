// HOW-TO: Convert DICOM File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output\\converted.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image and save as PNG in a single Save call
            using (var dicomImage = (DicomImage)Image.Load(inputPath))
            {
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
 * 1. When a medical imaging application needs to display DICOM scans in a web browser that only supports PNG.
 * 2. When a hospital system must export patient radiology images to a format compatible with standard image viewers.
 * 3. When a developer wants to batch‑convert DICOM studies to PNG for inclusion in reports or presentations.
 * 4. When integrating DICOM data into a C# desktop app that processes images using common .NET libraries.
 * 5. When creating thumbnails of DICOM images for a PACS viewer without writing custom conversion code.
 */
