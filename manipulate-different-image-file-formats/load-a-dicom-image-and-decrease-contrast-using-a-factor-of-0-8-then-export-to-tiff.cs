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
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output\\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Decrease contrast (negative value reduces contrast)
                dicomImage.AdjustContrast(-20f);

                // Set up TIFF save options
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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF for archival while reducing contrast to improve visual clarity for radiologists.
 * 2. When a healthcare data pipeline processes DICOM files and must export them as TIFF images with lowered contrast to meet a hospital’s image‑display standards.
 * 3. When a research project requires batch conversion of DICOM MRI images to TIFF format and needs to uniformly decrease contrast to enhance feature detection in downstream analysis.
 * 4. When a PACS integration tool must transform incoming DICOM files into TIFF for compatibility with third‑party viewers, applying a contrast reduction to match the viewer’s default settings.
 * 5. When a diagnostic software component needs to load a DICOM image, adjust its contrast by a factor of 0.8, and save the result as a TIFF file for inclusion in patient reports.
 */