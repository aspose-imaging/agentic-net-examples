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
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding (example parameters)
                dicomImage.BinarizeBradley(5, 10);

                // Resize to 640x480 using bilinear resampling
                dicomImage.Resize(640, 480, ResizeType.BilinearResample);

                // Save the processed image as PNG
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
 * 1. When a medical imaging application needs to convert DICOM radiology scans into high‑contrast PNG thumbnails for quick web preview, this code loads the DICOM, applies Bradley adaptive thresholding, resizes to 640×480, and saves as PNG.
 * 2. When a telemedicine platform wants to generate standardized, low‑resolution PNG snapshots from various DICOM files for inclusion in patient reports, the code performs binarization, resizing, and format conversion in C# using Aspose.Imaging.
 * 3. When a research tool must preprocess DICOM ultrasound images by enhancing edges with adaptive thresholding and scaling them to a uniform 640×480 size before feeding them into a machine‑learning model, this snippet provides the required steps.
 * 4. When a hospital’s PACS integration needs to export DICOM images as PNG files with consistent dimensions for display on mobile devices, the code demonstrates how to load, binarize with Bradley, resize, and save using Aspose.Imaging for .NET.
 * 5. When a developer is building a batch‑processing utility that converts a folder of DICOM scans into PNG assets with improved contrast and fixed resolution for archival or UI rendering, this example shows the essential C# workflow.
 */