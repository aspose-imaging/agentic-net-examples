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
        // Hardcoded input and output paths
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/output.tif";

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
            // Load DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Adjust brightness (range -255 to 255)
                dicomImage.AdjustBrightness(30);

                // Adjust contrast (range -100 to 100)
                dicomImage.AdjustContrast(20f);

                // Prepare TIFF save options
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Save the processed image as TIFF
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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF for archival while adjusting brightness and contrast to improve visual quality.
 * 2. When a radiology workflow requires batch processing of DICOM files in C# using Aspose.Imaging to apply brightness/contrast corrections before sending them to a PACS system that only accepts TIFF.
 * 3. When a healthcare research tool must load large DICOM images, modify their visual parameters, and save them as TIFF with efficient memory usage to avoid out‑of‑memory errors.
 * 4. When a desktop utility lets users preview DICOM X‑ray images, enhance them by tweaking brightness and contrast, and export the result as a standard TIFF file for inclusion in reports.
 * 5. When an integration service converts DICOM images received from imaging devices into TIFF format for downstream image analysis pipelines that expect TIFF input and require consistent brightness and contrast settings.
 */