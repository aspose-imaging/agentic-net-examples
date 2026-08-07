using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific properties
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The input file is not a valid DICOM image.");
                    return;
                }

                // Prepare PNG options and copy XMP metadata from the DICOM image
                var pngOptions = new PngOptions
                {
                    XmpData = dicomImage.XmpData // preserve original metadata
                };

                // Save as PNG with the transferred metadata
                dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a medical imaging application must convert DICOM scans to PNG for web viewing while preserving patient and study metadata for audit trails.
 * 2. When a radiology workflow needs to generate thumbnail PNGs from DICOM files for integration into electronic health record (EHR) systems without losing XMP metadata.
 * 3. When a research project requires batch conversion of DICOM images to PNG for machine‑learning preprocessing while keeping original acquisition parameters embedded.
 * 4. When a hospital IT team wants to archive DICOM images as lossless PNGs on a file server and retain traceability by copying the DICOM XMP metadata.
 * 5. When a developer builds a diagnostic reporting tool that extracts DICOM images, converts them to PNG for inclusion in PDF reports, and needs the original metadata for regulatory compliance.
 */