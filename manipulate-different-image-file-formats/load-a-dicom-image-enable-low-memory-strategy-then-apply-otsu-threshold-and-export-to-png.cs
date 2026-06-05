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

            // Open a file stream for the DICOM image
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure low‑memory loading (e.g., 256 KB buffer)
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024
                };

                // Load the DICOM image using the low‑memory strategy
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
 * 1. When a radiology workstation must convert large DICOM scans to lightweight PNG thumbnails on a memory‑constrained PC, this code loads the DICOM image with a low‑memory buffer, applies Otsu binarization, and saves the result as PNG.
 * 2. When a telemedicine platform needs to preprocess patient X‑ray files by automatically applying Otsu thresholding before transmitting them as PNG over the network, developers can use this snippet.
 * 3. When a research lab processes thousands of DICOM images on a server with limited RAM and wants to generate binary masks for image analysis, the low‑memory loading and BinarizeOtsu call provide an efficient solution.
 * 4. When a C# desktop application requires displaying a high‑contrast version of a DICOM image without loading the entire file into memory, this example demonstrates how to stream the file, binarize it, and export to PNG.
 * 5. When an automated QA tool validates DICOM files by converting them to binarized PNGs for visual comparison, the code shows how to safely read the DICOM, apply Otsu threshold, and save the output using Aspose.Imaging for .NET.
 */