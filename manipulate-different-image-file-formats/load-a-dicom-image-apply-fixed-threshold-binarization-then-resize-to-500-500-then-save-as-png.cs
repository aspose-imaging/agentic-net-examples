// HOW-TO: Convert DICOM to PNG with Fixed Threshold Binarization and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                using (var dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
                {
                    dicom.BinarizeFixed(128);
                    dicom.Resize(500, 500, ResizeType.NearestNeighbourResample);
                    var pngOptions = new PngOptions
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
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to transform high‑resolution DICOM scans into smaller, black‑and‑white PNG thumbnails for quick web preview.
 * 2. When a radiology workflow requires converting DICOM files to PNG while applying a fixed threshold to highlight bone structures before archiving.
 * 3. When a healthcare data pipeline must standardize images by resizing DICOM images to 500 × 500 pixels and saving them as PNG for machine‑learning model input.
 * 4. When a developer wants to generate printable PNG copies of DICOM X‑ray images with consistent binarization for diagnostic reports.
 * 5. When integrating Aspose.Imaging in a C# service that extracts DICOM images, applies binary thresholding, resizes them, and stores the results as PNG for cross‑platform viewing.
 */
