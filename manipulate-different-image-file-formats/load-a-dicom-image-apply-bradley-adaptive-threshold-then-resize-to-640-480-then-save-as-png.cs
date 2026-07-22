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
            string inputPath = @"C:\Images\input.dcm";
            string outputPath = @"C:\Images\output.png";

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

                // Apply Bradley adaptive thresholding (example parameters: brightnessDifference=5, windowSize=10)
                dicomImage.BinarizeBradley(5, 10);

                // Resize to 640x480 using bilinear resampling
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
 * 1. When a medical imaging application needs to convert a DICOM radiology scan into a high‑contrast PNG thumbnail for quick preview in a web portal.
 * 2. When a hospital PACS system must generate standardized 640×480 PNG images from DICOM files for integration with electronic health record (EHR) viewers that only support common raster formats.
 * 3. When a research tool processes DICOM ultrasound images, applies Bradley adaptive threshold to enhance tissue boundaries, and resizes them for inclusion in a machine‑learning dataset.
 * 4. When a telemedicine platform wants to extract a DICOM X‑ray, binarize it for better visual clarity, and deliver a lightweight PNG to mobile devices with limited bandwidth.
 * 5. When a diagnostic software needs to batch‑process DICOM files, apply adaptive binarization, resize to a fixed resolution, and store the results as PNG for archival or reporting purposes.
 */