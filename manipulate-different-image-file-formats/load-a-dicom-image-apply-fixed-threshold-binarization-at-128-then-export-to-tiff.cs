// HOW-TO: Convert DICOM to TIFF With Fixed Threshold Binarization In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.BinarizeFixed(128);
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a medical imaging application needs to transform DICOM scans into high‑contrast black‑and‑white TIFF files for archival or further analysis.
 * 2. When a radiology workflow requires applying a fixed 128‑level threshold to highlight structures before sending images to a PACS system that only accepts TIFF.
 * 3. When a C# program must batch‑process DICOM X‑ray images into binarized TIFFs for use in machine‑learning models that expect binary input.
 * 4. When a developer wants to generate printable, lossless TIFF copies of DICOM images with consistent thresholding for quality‑controlled reports.
 * 5. When integrating Aspose.Imaging into a .NET service that converts incoming DICOM files to TIFF while simplifying the image to a binary mask for downstream image‑processing pipelines.
 */
