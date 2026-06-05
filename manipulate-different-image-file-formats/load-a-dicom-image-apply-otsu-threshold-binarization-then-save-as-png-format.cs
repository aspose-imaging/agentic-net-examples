using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.BinarizeOtsu.png";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
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
 * 1. When a medical imaging application needs to convert DICOM scans to high‑contrast PNG files for web display, developers can use Aspose.Imaging’s Otsu binarization in C#.
 * 2. When a radiology workflow requires extracting binary masks from DICOM X‑ray images to feed into a machine‑learning model, the code loads the DICOM, applies Otsu threshold, and saves the result as PNG.
 * 3. When a hospital’s PACS integration must generate printable black‑and‑white PNG copies of DICOM images for patient reports, this C# snippet provides the necessary conversion.
 * 4. When a research project wants to preprocess DICOM MRI slices by automatically thresholding them and storing the results as lossless PNGs for archival, the example demonstrates the required steps.
 * 5. When a desktop utility must batch‑process DICOM files, apply Otsu binarization to enhance contrast, and output PNG images for use in electronic health record systems, this code shows how to achieve it.
 */