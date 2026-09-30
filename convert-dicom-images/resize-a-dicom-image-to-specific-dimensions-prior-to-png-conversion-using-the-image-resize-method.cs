// HOW-TO: Resize DICOM Image to Specific Dimensions and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int targetWidth = 800;
            int targetHeight = 600;

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                dicom.Resize(targetWidth, targetHeight);
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                dicom.Save(outputPath, pngOptions);
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
 * 1. When a healthcare application needs to generate smaller PNG thumbnails from large DICOM scans for quick preview in a web portal.
 * 2. When a radiology workflow must convert DICOM files to PNG format with a fixed size to embed them in PDF reports.
 * 3. When a mobile app requires resized PNG images extracted from DICOM studies to reduce bandwidth and improve loading speed.
 * 4. When an electronic health record system needs to standardize image dimensions before storing DICOM‑derived PNGs in a database.
 * 5. When a machine‑learning pipeline preprocesses DICOM images by resizing them to 800×600 pixels and saving as PNG for model training.
 */
