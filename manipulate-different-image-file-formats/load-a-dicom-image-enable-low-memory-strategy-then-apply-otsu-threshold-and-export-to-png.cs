// HOW-TO: Load DICOM Image With Low Memory Apply Otsu Binarization And Save PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "c:\\temp\\sample.dicom";
            string outputPath = "c:\\temp\\sample.BinarizeOtsu.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure low‑memory load options (256 KB buffer)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 256 * 1024
            };

            // Load DICOM image using a stream and the low‑memory options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

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
 * 1. When a medical imaging application must process large DICOM files on a server with limited RAM, this code loads the image using a small buffer, binarizes it with Otsu’s method, and writes a lightweight PNG for downstream analysis.
 * 2. When a radiology workflow needs to convert DICOM scans to binary masks for machine‑learning preprocessing, the Otsu thresholding creates a clean black‑and‑white image that can be fed into algorithms.
 * 3. When a desktop tool has to display DICOM data as a PNG thumbnail without consuming much memory, the low‑memory load option and binarization produce a fast, compact representation.
 * 4. When an integration pipeline must archive diagnostic images in a lossless format while reducing file size, converting the DICOM to a binarized PNG helps meet storage constraints.
 * 5. When a developer is building a diagnostic report generator that includes highlighted regions of interest, using Otsu binarization on the DICOM and saving as PNG simplifies overlay creation.
 */
