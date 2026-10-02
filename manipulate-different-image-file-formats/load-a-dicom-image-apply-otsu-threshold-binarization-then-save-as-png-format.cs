// HOW-TO: Convert DICOM to PNG with Otsu Threshold Binarization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.BinarizeOtsu();

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application needs to turn grayscale DICOM scans into high‑contrast black‑and‑white PNGs for web display.
 * 2. When a radiology workflow requires automated binarization of DICOM images to highlight regions of interest before archiving them as PNG files.
 * 3. When a research project converts DICOM datasets into PNG format for use with machine‑learning models that expect binary images.
 * 4. When a hospital information system generates printable PNG reports from DICOM scans by applying Otsu’s threshold to improve readability.
 * 5. When a developer integrates Aspose.Imaging into a C# service that processes incoming DICOM files and outputs PNG thumbnails with automatic thresholding.
 */
