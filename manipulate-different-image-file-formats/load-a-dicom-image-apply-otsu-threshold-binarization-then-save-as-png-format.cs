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
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\sample.dicom";
            string outputPath = @"c:\temp\sample.BinarizeOtsu.png";

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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

                // Save the result as PNG
                dicomImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert DICOM radiology scans into high‑contrast black‑and‑white PNG files for web display or reporting.
 * 2. When a developer is building a batch‑processing tool that extracts DICOM images, applies Otsu threshold binarization to highlight structures, and stores the results as PNG for archival.
 * 3. When a diagnostic software integrates C# code to preprocess DICOM images for machine‑learning models that require binary input images in PNG format.
 * 4. When a hospital IT system must generate printable PNG copies of DICOM studies with automatic Otsu binarization for inclusion in patient discharge summaries.
 * 5. When a research project needs to programmatically load DICOM files, perform Otsu binarization to segment regions of interest, and save the output as PNG for further analysis in non‑medical image tools.
 */