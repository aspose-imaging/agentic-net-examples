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
            string inputPath = "input.dcm";
            string outputPath = "output.png";

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
                DicomImage dicomImage = (DicomImage)image;

                // Apply window level adjustment (example using brightness and contrast)
                dicomImage.AdjustBrightness(40);      // Adjust brightness as needed
                dicomImage.AdjustContrast(30f);       // Adjust contrast as needed

                // Set PNG options for 16‑bit output
                var pngOptions = new PngOptions
                {
                    BitDepth = 16
                };

                // Save as 16‑bit PNG
                dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a radiology application must convert DICOM CT scans to high‑precision 16‑bit PNG files for visual inspection after applying custom window‑level adjustments.
 * 2. When a medical research pipeline needs to extract pixel data from DICOM MR images, tweak brightness and contrast, and save the result as a lossless 16‑bit PNG for quantitative analysis.
 * 3. When a healthcare integration service has to transform DICOM X‑ray images into web‑friendly 16‑bit PNGs while preserving diagnostic detail through window level correction.
 * 4. When a machine‑learning preprocessing step requires standardizing DICOM ultrasound frames by adjusting brightness/contrast and exporting them as 16‑bit PNGs for model training.
 * 5. When a hospital’s PACS archiving tool automates the creation of 16‑bit PNG thumbnails from DICOM studies, using window level adjustment to highlight relevant anatomy.
 */