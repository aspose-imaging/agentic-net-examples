using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.dicom";
        string outputPath = @"C:\Images\Result\sample_resized.png";

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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply fixed threshold binarization (threshold value 127)
                dicomImage.BinarizeFixed(127);

                // Resize to 500x500 using nearest neighbour resampling
                dicomImage.Resize(500, 500, ResizeType.NearestNeighbourResample);

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
 * 1. When a radiology web portal needs to show high‑contrast PNG thumbnails of DICOM scans, developers can load the DICOM, apply a fixed‑threshold binarization, resize to 500 × 500, and save as PNG.
 * 2. When preparing training data for a medical image machine‑learning model, a developer can use this C# code with Aspose.Imaging to convert DICOM files into binary 500 × 500 PNG images.
 * 3. When generating printable reports that require simplified black‑and‑white versions of DICOM images, this snippet lets a .NET application binarize, resize, and export the image as a PNG.
 * 4. When integrating a hospital PACS system with a third‑party viewer that only supports PNG, developers can transform DICOM images into 500 × 500 binary PNGs by applying fixed‑threshold binarization using Aspose.Imaging for .NET.
 * 5. When building a mobile health app that displays compact, high‑contrast thumbnails of DICOM X‑ray images, this code provides a quick way to load, binarize, resize to 500 × 500, and save the result as a PNG.
 */