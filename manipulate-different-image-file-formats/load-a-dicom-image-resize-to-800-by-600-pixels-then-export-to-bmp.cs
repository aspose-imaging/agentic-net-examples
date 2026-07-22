using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dicom";
        string outputPath = "resized.bmp";

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

            // Load DICOM image from file stream
            using (var stream = File.OpenRead(inputPath))
            using (var dicomImage = new DicomImage(stream))
            {
                // Resize to 800x600 using bilinear resampling
                dicomImage.Resize(800, 600, ResizeType.BilinearResample);

                // Save as BMP
                dicomImage.Save(outputPath, new BmpOptions());
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
 * 1. When a medical imaging application needs to convert high‑resolution DICOM scans into smaller BMP thumbnails for quick preview in a patient portal.
 * 2. When a radiology workflow requires batch processing of DICOM files to a uniform 800×600 size before embedding them into a PDF report.
 * 3. When a healthcare data‑integration service must transform DICOM images into BMP format for compatibility with legacy Windows imaging tools.
 * 4. When a telemedicine platform wants to downscale DICOM X‑ray images to reduce bandwidth while preserving visual quality for remote diagnosis.
 * 5. When a research project needs to extract DICOM images, resize them, and save as BMP to feed into a machine‑learning model that only accepts BMP inputs.
 */