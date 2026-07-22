using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image, apply fixed threshold binarization, and save as TIFF
            using (Image image = Image.Load(inputPath))
            {
                var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;
                dicomImage.BinarizeFixed(128);

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a hospital IT system needs to convert radiology DICOM scans into high‑contrast black‑and‑white TIFF files for integration with legacy PACS viewers that only support TIFF.
 * 2. When a research lab wants to preprocess MRI DICOM images by applying a fixed threshold of 128 to create binary masks before statistical analysis in C#.
 * 3. When a medical billing service must generate printable TIFF copies of DICOM X‑ray images with consistent binarization for inclusion in insurance claim documents.
 * 4. When a telemedicine platform requires automated conversion of incoming DICOM ultrasound images to TIFF format with fixed‑threshold binarization to reduce file size for faster network transmission.
 * 5. When a forensic imaging tool needs to load DICOM CT scans, apply a 128‑level binary threshold to highlight bone structures, and save the result as a TIFF for use in courtroom presentations.
 */