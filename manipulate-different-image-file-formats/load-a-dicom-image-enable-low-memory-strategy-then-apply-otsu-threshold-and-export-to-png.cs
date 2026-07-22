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
                // Configure low‑memory load options (e.g., 256 KB buffer)
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024
                };

                // Load the DICOM image with the low‑memory strategy
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
 * 1. When a medical imaging application needs to convert large DICOM scans to lightweight PNG files on a low‑memory device, this code loads the DICOM image with a small buffer, applies Otsu binarization, and saves the result.
 * 2. When a radiology workflow requires automated thresholding of CT or MRI images for quick visual inspection, developers can use this C# snippet to binarize the DICOM data using Otsu’s method and export it as a PNG thumbnail.
 * 3. When a cloud‑based service processes patient DICOM files in a memory‑constrained container, the example demonstrates how to enable a low‑memory load strategy, perform Otsu binarization, and store the output in a web‑friendly PNG format.
 * 4. When a research project needs to generate binary masks from DICOM images for machine‑learning preprocessing, the code shows how to load the image with Aspose.Imaging, apply the BinarizeOtsu function, and save the mask as a PNG file.
 * 5. When a desktop utility must batch‑convert DICOM files to PNG while minimizing RAM usage and preserving diagnostic contrast via Otsu thresholding, this example provides the necessary C# steps.
 */