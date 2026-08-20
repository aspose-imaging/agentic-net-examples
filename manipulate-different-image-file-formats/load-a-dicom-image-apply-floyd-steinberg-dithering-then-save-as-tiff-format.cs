// HOW-TO: Convert DICOM To TIFF With Floyd Steinberg Dithering In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths (relative)
                string inputPath = Path.Combine("Input", "sample.dicom");
                string outputPath = Path.Combine("Output", "sample.tiff");

                // Verify the input DICOM file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;

                    // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                    dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                    // Save the processed image as TIFF
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to transform high‑resolution medical DICOM scans into 1‑bit TIFF files for archival or printing while preserving visual detail through Floyd‑Steinberg dithering.
 * 2. When a radiology application must generate low‑size black‑and‑white TIFF images from DICOM data for compatibility with legacy PACS systems.
 * 3. When you are building a C# tool that converts DICOM images to TIFF format and applies error‑diffusion dithering to improve contrast on monochrome displays.
 * 4. When you need to automate batch processing of DICOM files, applying dithering and saving them as TIFF to meet regulatory documentation standards.
 * 5. When a healthcare software project requires converting DICOM images to TIFF with a 1‑bit palette to embed them in PDF reports without losing diagnostic information.
 */
