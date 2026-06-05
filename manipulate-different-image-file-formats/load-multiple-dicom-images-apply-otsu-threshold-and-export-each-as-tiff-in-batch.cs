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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Retrieve all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare the output TIFF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image, apply Otsu threshold, and save as TIFF
                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    dicomImage.BinarizeOtsu();

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a radiology department needs to convert a batch of DICOM scans into high‑contrast TIFF files for archival or printing, this code can automate the process.
 * 2. When a medical research team wants to preprocess thousands of DICOM images with Otsu binarization before feeding them into a machine‑learning pipeline, the script provides a fast C# solution.
 * 3. When a hospital’s PACS integration requires exporting DICOM images as TIFFs for compatibility with legacy imaging software, the code handles bulk conversion and thresholding.
 * 4. When a pathology lab must generate black‑and‑white TIFF slides from DICOM microscopy images for quality‑control documentation, the program applies Otsu threshold automatically.
 * 5. When a health‑tech startup needs to batch‑process DICOM files into TIFF format for cloud storage while preserving diagnostic details, this C# example streamlines the workflow.
 */