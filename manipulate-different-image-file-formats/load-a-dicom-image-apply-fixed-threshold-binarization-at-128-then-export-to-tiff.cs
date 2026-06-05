using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image, apply fixed threshold binarization, and save as TIFF
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                dicomImage.BinarizeFixed(128); // Apply threshold at 128

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

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert DICOM scans to a universally viewable TIFF format while applying a fixed threshold of 128 to create a binary image for easier analysis.
 * 2. When a radiology workflow requires batch processing of DICOM files to generate high‑contrast black‑and‑white TIFF copies for archival or printing on legacy equipment.
 * 3. When a developer is building a C# tool that extracts diagnostic images from PACS, binarizes them at a specific intensity level, and saves them as TIFF for integration with third‑party image analysis libraries.
 * 4. When a healthcare data pipeline must transform DICOM images into a lossless TIFF format with fixed‑threshold binarization to reduce file size before transmitting to remote diagnostic centers.
 * 5. When a research project needs to programmatically load DICOM ultrasound images, apply a 128‑level threshold to highlight structures, and export the result as TIFF for inclusion in scientific publications.
 */