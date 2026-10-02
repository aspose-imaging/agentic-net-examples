// HOW-TO: Convert DICOM Medical Image to 16‑Bit Grayscale PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    BitDepth = 16,
                    ColorType = PngColorType.Grayscale,
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
 * 1. When a radiology software needs to export DICOM scans as high‑resolution 16‑bit PNG files for detailed visual analysis.
 * 2. When a research project requires converting medical images to a lossless grayscale format compatible with image‑processing libraries.
 * 3. When a developer must generate PNG thumbnails from DICOM files while preserving the original pixel depth for quantitative measurements.
 * 4. When integrating a C# application with a PACS system and the downstream workflow expects PNG rather than DICOM.
 * 5. When building a machine‑learning pipeline that consumes 16‑bit PNG images derived from DICOM scans for training algorithms.
 */
