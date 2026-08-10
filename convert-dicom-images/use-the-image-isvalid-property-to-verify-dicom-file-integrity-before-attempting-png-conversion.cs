// HOW-TO: Check DICOM File Validity and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                using (var pngOptions = new PngOptions())
                {
                    dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a healthcare application must use the Image.IsValid property to confirm a DICOM image isn’t corrupted before creating a PNG thumbnail.
 * 2. When a PACS integration needs to validate incoming DICOM files with Image.IsValid and then store them as PNGs for web preview.
 * 3. When a research pipeline processes large DICOM datasets, checks each file’s validity using Image.IsValid, and converts only the valid scans to PNG for analysis.
 * 4. When a mobile app downloads DICOM files, runs Image.IsValid to ensure integrity, and converts the verified images to PNG for UI rendering.
 * 5. When an automated reporting workflow extracts diagnostic images from DICOM archives, verifies each file with Image.IsValid, and saves the confirmed images as PNGs for inclusion in reports.
 */
