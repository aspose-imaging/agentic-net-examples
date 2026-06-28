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
            string inputPath = "c:\\temp\\sample.dcm";
            string outputPath = "c:\\temp\\sample_processed.bmp";

            // Verify input file exists
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
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive threshold (brightnessDifference = 5, windowSize = 10)
                dicomImage.BinarizeBradley(5, 10);

                // Rotate the image 180 degrees
                dicomImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Save the processed image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to convert DICOM scans to BMP for display on legacy Windows systems after enhancing contrast with Bradley adaptive threshold and correcting orientation.
 * 2. When a radiology workflow requires preprocessing DICOM X‑ray images by binarizing them, rotating 180°, and exporting to BMP for integration with third‑party reporting tools that only accept BMP.
 * 3. When a developer builds a C# utility that batch‑processes DICOM files, applies adaptive thresholding to highlight structures, flips the image upside down, and saves as BMP for archival in a non‑DICOM PACS.
 * 4. When a diagnostic software needs to prepare DICOM ultrasound frames for OCR by converting them to high‑contrast BMP after Bradley binarization and 180° rotation.
 * 5. When a healthcare IT team automates the generation of printable BMP copies of DICOM images with standardized orientation and binary contrast for inclusion in patient discharge documents.
 */