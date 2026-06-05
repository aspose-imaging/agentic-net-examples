using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.dicom";
            string outputPath = @"C:\Images\result.png";

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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding
                // Example parameters: brightnessDifference = 5, windowSize = 10
                dicomImage.BinarizeBradley(5, 10);

                // Resize to 640x480 using Bilinear resampling
                dicomImage.Resize(640, 480, ResizeType.BilinearResample);

                // Save as PNG
                dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When a radiology web portal needs to convert high‑resolution DICOM scans into lightweight PNG thumbnails with enhanced contrast for quick preview, a developer can use this code.
 * 2. When a medical research application must batch‑process DICOM images to produce binary masks and uniform 640×480 PNG files for machine‑learning model training, this snippet provides the necessary steps.
 * 3. When a hospital’s PACS integration requires on‑the‑fly conversion of DICOM X‑ray images to PNG format with adaptive thresholding for better visibility on mobile devices, the code can be employed.
 * 4. When a tele‑medicine solution needs to generate standardized PNG snapshots from DICOM files for inclusion in patient reports, applying Bradley adaptive threshold and resizing ensures consistent quality.
 * 5. When a diagnostic imaging workflow automates the creation of printable PNG copies of DICOM images with enhanced edge detection and fixed dimensions for archival documentation, this example shows how to achieve it.
 */