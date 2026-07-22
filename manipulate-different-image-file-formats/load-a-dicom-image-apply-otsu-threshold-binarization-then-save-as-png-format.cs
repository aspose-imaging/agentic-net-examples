using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\sample.dicom";
            string outputPath = "c:\\temp\\sample.BinarizeOtsu.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image, apply Otsu binarization, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.BinarizeOtsu();
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
 * 1. When a radiology application must convert DICOM scans into high‑contrast black‑and‑white PNG images for quick visual review, developers can use this code to load the DICOM file, apply Otsu binarization, and save the result.
 * 2. When a healthcare data pipeline needs to extract binary masks from CT or MRI DICOM images for downstream AI analysis, the snippet demonstrates how to perform Otsu thresholding in C# with Aspose.Imaging and output PNG files.
 * 3. When a medical device manufacturer wants to generate printable PNG copies of DICOM images with automatic contrast enhancement for patient reports, this example shows the required steps using Aspose.Imaging’s BinarizeOtsu method.
 * 4. When a research project requires batch processing of DICOM files into binarized PNG thumbnails for a web‑based image gallery, developers can adapt this code to load each DICOM, apply Otsu threshold, and save PNGs.
 * 5. When a hospital IT system needs to archive DICOM images as lossless PNGs with binary segmentation for long‑term storage, the provided C# example illustrates the complete workflow from loading to saving.
 */