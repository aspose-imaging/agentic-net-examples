using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

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

/*
 * Real-World Use Cases:
 * 1. When a healthcare application must batch‑process DICOM radiology images, apply Otsu binarization to enhance contrast, and save the results as TIFF files for compatibility with downstream analysis tools.
 * 2. When a research project needs to convert raw DICOM scans into lossless TIFF format while automatically performing Otsu thresholding to prepare the images for machine‑learning segmentation.
 * 3. When a PACS integration requires generating printable TIFF copies of DICOM studies with enhanced contrast using Otsu’s method for radiologists reviewing hard‑copy reports.
 * 4. When a diagnostic imaging workflow has to extract DICOM pixel data, apply Otsu threshold to create binary masks, and store the processed images as TIFF for archival in a document management system.
 * 5. When a C# developer wants to automate the transformation of DICOM files into TIFF format with built‑in Otsu binarization to simplify image preprocessing before applying computer‑vision algorithms.
 */