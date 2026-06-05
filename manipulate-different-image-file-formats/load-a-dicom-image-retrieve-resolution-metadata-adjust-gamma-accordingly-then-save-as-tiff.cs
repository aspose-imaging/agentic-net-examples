using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        try
        {
            // Load the DICOM image
            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                // Retrieve resolution metadata
                double horizontalDpi = dicomImage.HorizontalResolution;
                double verticalDpi = dicomImage.VerticalResolution;

                // Determine gamma based on resolution (example logic)
                float gamma = 1.0f;
                if (horizontalDpi > 300 || verticalDpi > 300)
                {
                    gamma = 1.2f;
                }
                else if (horizontalDpi < 150 && verticalDpi < 150)
                {
                    gamma = 0.8f;
                }

                // Apply gamma correction
                dicomImage.AdjustGamma(gamma);

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
 * 1. When a medical imaging application must convert high‑resolution DICOM scans to TIFF files while automatically adjusting gamma based on the image’s DPI to improve visual contrast.
 * 2. When a radiology workflow needs to batch‑process DICOM X‑ray images, read their horizontal and vertical resolution, apply resolution‑dependent gamma correction, and store the results as lossless TIFF for archival.
 * 3. When a C# developer is building a diagnostic viewer that imports DICOM images, extracts resolution metadata, tweaks brightness via gamma adjustment, and exports the adjusted image to a widely supported TIFF format.
 * 4. When a healthcare data integration service has to ensure that low‑resolution DICOM ultrasound frames are brightened (gamma < 1) and high‑resolution CT slices are slightly darkened (gamma > 1) before saving them as TIFF for downstream analysis.
 * 5. When an imaging pipeline requires reading DICOM files, determining if the DPI exceeds 300 dpi, applying a 1.2 gamma boost, otherwise reducing gamma for low‑dpi images, and then saving the processed output as a TIFF using Aspose.Imaging for .NET.
 */