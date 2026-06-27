using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Dicom;

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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage for DICOM-specific operations
                DicomImage dicomImage = (DicomImage)image;

                // Retrieve resolution metadata
                double horizontalResolution = dicomImage.HorizontalResolution;
                double verticalResolution = dicomImage.VerticalResolution;

                // Adjust gamma based on resolution (example logic)
                float gamma = (horizontalResolution > 300 || verticalResolution > 300) ? 1.2f : 1.0f;
                dicomImage.AdjustGamma(gamma);

                // Save the adjusted image as TIFF
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
 * 1. A radiology software developer needs to convert high‑resolution DICOM scans to TIFF for archival systems while automatically brightening images with a gamma boost when the scan resolution exceeds 300 dpi.
 * 2. A medical research application must load DICOM ultrasound files, detect their pixel density, apply a resolution‑based gamma correction, and export the results as TIFF for compatibility with image analysis tools.
 * 3. An electronic health record (EHR) integration service uses this code to ingest DICOM X‑ray images, adjust their visual contrast according to horizontal or vertical resolution, and store the processed images as TIFF for display on web portals.
 * 4. A telemedicine platform processes incoming DICOM CT images, applies a gamma tweak when the images are captured at high resolution, and saves them as TIFF to ensure consistent rendering across different client devices.
 * 5. A healthcare data migration script reads DICOM mammography files, evaluates their DPI, performs a conditional gamma adjustment, and writes the output as TIFF to meet the target system’s file‑format requirements.
 */