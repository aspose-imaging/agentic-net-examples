// HOW-TO: Batch Convert DICOM to TIFF with Otsu Threshold in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tiff";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    // Apply Otsu threshold binarization
                    dicomImage.BinarizeOtsu();

                    // Save as TIFF
                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        dicomImage.Save(outputPath, tiffOptions);
                    }
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
 * 1. When a medical imaging system needs to process a folder of DICOM scans, apply automatic Otsu binarization, and store the results as TIFF files for archival or further analysis.
 * 2. When a radiology workflow requires converting raw DICOM images to a widely supported format like TIFF while enhancing contrast through thresholding for downstream AI models.
 * 3. When a developer builds a batch processing tool that reads multiple DICOM files from a directory, applies binary segmentation, and outputs ready‑to‑print TIFF images for reporting.
 * 4. When integrating Aspose.Imaging into a C# application to automate the transformation of DICOM datasets into TIFF for compatibility with legacy PACS viewers that only support TIFF.
 * 5. When creating a script to ensure all DICOM images in a study are uniformly thresholded and saved as lossless TIFFs for regulatory compliance and long‑term storage.
 */
