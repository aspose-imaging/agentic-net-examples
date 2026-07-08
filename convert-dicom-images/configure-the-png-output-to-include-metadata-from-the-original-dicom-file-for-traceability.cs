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
                // Cast to DicomImage to access DICOM‑specific properties
                DicomImage dicomImage = image as DicomImage;
                if (dicomImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid DICOM image.");
                    return;
                }

                // Prepare PNG options and copy metadata from the DICOM image
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true,               // Preserve metadata during export
                    XmpData = dicomImage.XmpData       // Transfer XMP metadata
                };

                // Save as PNG with the prepared options
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
 * 1. When a radiology PACS system needs to export DICOM scans as PNG thumbnails while preserving patient and study metadata for audit trails.
 * 2. When a medical research application converts DICOM images to PNG for web display but must retain XMP metadata to link back to the original study.
 * 3. When a healthcare mobile app generates PNG snapshots from DICOM files for offline viewing and requires embedded metadata for regulatory compliance.
 * 4. When a hospital's document management workflow transforms DICOM files into PNG format for archival in a non‑DICOM repository while keeping traceability information.
 * 5. When a diagnostic AI pipeline extracts PNG images from DICOM datasets for model training and needs to carry over metadata to maintain data provenance.
 */