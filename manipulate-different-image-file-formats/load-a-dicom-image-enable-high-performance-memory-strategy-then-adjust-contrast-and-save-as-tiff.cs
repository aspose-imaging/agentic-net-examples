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
            string inputPath = "input.dcm";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure high‑performance memory strategy
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 256 * 1024 // 256 KB buffer size
            };

            // Load DICOM image using a file stream and the load options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Adjust contrast (value range: -100 to 100)
                dicomImage.AdjustContrast(50f);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the adjusted image as TIFF
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
 * 1. When a medical imaging application must convert DICOM scans to TIFF files for long‑term storage while boosting contrast and using a high‑performance memory strategy in C#.
 * 2. When a radiology workflow needs to batch‑process large DICOM images, apply a contrast boost, and export them as TIFFs for compatibility with legacy analysis tools.
 * 3. When a healthcare IT system integrates Aspose.Imaging to read DICOM files from a file stream, enhance visibility of details, and save the result as a TIFF for reporting purposes.
 * 4. When a developer builds a diagnostic viewer that loads high‑resolution DICOM images with optimized buffering, adjusts contrast on the fly, and outputs TIFFs for sharing with clinicians.
 * 5. When a PACS migration script must efficiently read DICOM files, improve image contrast, and generate TIFF copies for archival archives using .NET and Aspose.Imaging.
 */