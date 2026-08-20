// HOW-TO: Apply Bradley Adaptive Threshold to DICOM and Resize to PNG in C# (Aspose.Imaging for .NET)
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
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive threshold (brightnessDifference=5, windowSize=10)
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
 * 1. When you need to convert a medical DICOM scan into a high‑contrast PNG thumbnail for web display.
 * 2. When you want to preprocess radiology images by binarizing them with Bradley adaptive threshold before further analysis.
 * 3. When you must generate a uniformly sized PNG preview (640×480) from variable‑resolution DICOM files.
 * 4. When you are building a C# application that extracts DICOM images, applies contrast enhancement, and saves them in a common image format.
 * 5. When you require automated batch processing of DICOM files to produce PNG assets for reporting or archiving.
 */
