using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access adjustment methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust brightness, contrast, and gamma sequentially
                dicomImage.AdjustBrightness(30);      // Increase brightness
                dicomImage.AdjustContrast(20f);       // Increase contrast
                dicomImage.AdjustGamma(1.2f);         // Apply gamma correction

                // Save the processed image as PDF
                dicomImage.Save(outputPath, new PdfOptions());
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
 * 1. When a radiology application needs to convert a DICOM X‑ray image to a PDF report while enhancing visibility by increasing brightness, contrast, and applying gamma correction using Aspose.Imaging for .NET.
 * 2. When a healthcare IT system must automatically preprocess CT scan slices—adjusting brightness, contrast, and gamma—to improve diagnostic clarity before embedding them in a PDF document for patient records.
 * 3. When a medical imaging workflow requires batch conversion of DICOM ultrasound images to searchable PDF files with standardized visual adjustments for consistent presentation across devices.
 * 4. When a telemedicine platform wants to generate PDF summaries of DICOM MRI images with optimized visual settings so clinicians can view them easily in web browsers without specialized DICOM viewers.
 * 5. When a hospital’s archival solution needs to store DICOM images as PDF files with enhanced contrast and gamma correction to ensure long‑term readability and compliance with electronic health record standards.
 */