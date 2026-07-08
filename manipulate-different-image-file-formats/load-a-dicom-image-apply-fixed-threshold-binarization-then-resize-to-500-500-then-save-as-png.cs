using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

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

            // Load the DICOM image, apply binarization, resize, and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply fixed‑threshold binarization (threshold value 127)
                dicomImage.BinarizeFixed(127);

                // Resize to 500×500 using bilinear resampling
                dicomImage.Resize(500, 500, ResizeType.BilinearResample);

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
 * 1. When a medical imaging application must convert a DICOM X‑ray scan to a high‑contrast black‑and‑white PNG thumbnail of 500×500 pixels for quick preview in a web portal.
 * 2. When a radiology workflow needs to extract a DICOM image, apply fixed‑threshold binarization at 127 to highlight bone structures, and then downscale it for inclusion in a PDF report.
 * 3. When a healthcare data‑analysis tool requires batch processing of DICOM files into PNG format with uniform size and binary contrast to feed a machine‑learning model.
 * 4. When a hospital’s PACS integration script must generate standardized PNG icons from DICOM studies for display on mobile devices, ensuring consistent resolution and binary image quality.
 * 5. When a developer is building a C# utility that sanitizes patient imaging data by converting DICOM images to binarized PNGs of 500×500 pixels before archiving them in a secure file system.
 */