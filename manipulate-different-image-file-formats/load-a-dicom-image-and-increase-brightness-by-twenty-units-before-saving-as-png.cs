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
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample_brightness.png";

        try
        {
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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Increase brightness by 20 units
                dicomImage.AdjustBrightness(20);

                // Save the result as PNG
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
 * 1. When a radiology application needs to convert a DICOM X‑ray file to a PNG thumbnail with increased brightness for clearer display in a web portal.
 * 2. When a healthcare data pipeline must preprocess DICOM scans by brightening them before saving them as PNGs for machine‑learning model training.
 * 3. When a medical imaging viewer wants to enhance low‑contrast DICOM MR images by adding 20 brightness units and then store them as PNGs for fast rendering.
 * 4. When a hospital reporting tool generates printable PNG reports from DICOM ultrasound images and requires a brightness boost to meet diagnostic standards.
 * 5. When a research project extracts DICOM CT slices, adjusts their brightness for better visual analysis, and archives the results as PNG files using Aspose.Imaging in C#.
 */