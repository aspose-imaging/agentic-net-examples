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
            string inputPath = @"c:\temp\sample.dicom";
            string outputPath = @"c:\temp\sample.BinarizeOtsu.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DICOM file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure low‑memory loading options
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB buffer
                };

                // Load the DICOM image with the specified options
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Apply Otsu threshold binarization
                    dicomImage.BinarizeOtsu();

                    // Save the result as PNG
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
 * 1. When a radiology application must convert large DICOM scans to high‑contrast binary PNGs for quick visual review on devices with limited RAM.
 * 2. When a medical research workflow processes thousands of DICOM files on a low‑memory server and needs Otsu thresholding before statistical analysis.
 * 3. When a telemedicine platform needs to load a DICOM image using a small buffer, apply automatic binarization, and serve the result as a PNG for web browsers.
 * 4. When a healthcare data‑migration tool extracts DICOM images, applies Otsu binarization to highlight regions of interest, and saves them in a portable PNG format.
 * 5. When an AI diagnostic model requires pre‑processed binary PNG inputs, and developers must efficiently load DICOM files, apply Otsu thresholding, and export the images for model consumption.
 */