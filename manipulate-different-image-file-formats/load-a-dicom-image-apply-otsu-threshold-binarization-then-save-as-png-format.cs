// HOW-TO: Convert DICOM to PNG with Otsu Binarization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample.BinarizeOtsu.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast the generic Image to DicomImage
                DicomImage dicomImage = (DicomImage)image;

                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

                // Save the binarized image as PNG
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
 * 1. When a medical imaging application needs to extract binary masks from DICOM scans for analysis, developers can load the DICOM, apply Otsu thresholding, and save the result as a PNG.
 * 2. When integrating DICOM data into a web portal that only supports PNG images, developers can convert and binarize the image in one step.
 * 3. When preparing DICOM images for machine‑learning preprocessing, developers may need a clean black‑and‑white PNG representation created via Otsu binarization.
 * 4. When generating printable reports that require high‑contrast images, developers can transform DICOM files into binarized PNGs for better readability.
 * 5. When automating a batch workflow that extracts regions of interest from radiology files, developers can use this code to threshold and export each DICOM as a PNG mask.
 */
