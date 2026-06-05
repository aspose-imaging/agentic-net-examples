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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of DICOM files to process
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "image1.dcm"),
                Path.Combine(inputDir, "image2.dcm"),
                Path.Combine(inputDir, "image3.dcm")
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;

                    // Increase brightness by 10 units
                    dicomImage.AdjustBrightness(10);

                    // Build the output PNG file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the adjusted image as PNG
                    dicomImage.Save(outputPath, new PngOptions());
                }
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
 * 1. When a radiology department needs to convert a series of DICOM scans to PNG for inclusion in a patient report while improving visibility by increasing brightness.
 * 2. When a medical research team wants to preprocess a batch of DICOM images for machine‑learning training, adjusting brightness uniformly before exporting to PNG format.
 * 3. When a healthcare IT developer automates nightly processing of newly acquired DICOM files, applying a brightness boost and storing the results as PNG thumbnails for a web‑based image viewer.
 * 4. When a telemedicine platform must prepare DICOM images for display on low‑resolution devices, increasing brightness by ten units and saving them as PNG to reduce file size and improve compatibility.
 * 5. When a quality‑control engineer needs to quickly verify image contrast across multiple DICOM studies by batch‑adjusting brightness and converting them to PNG for side‑by‑side visual inspection.
 */