using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

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
            // Configure memory strategy with a buffer size hint (e.g., 256 KB)
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BufferSizeHint = 256 * 1024;

            // Load DICOM image from file stream using the memory strategy
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Adjust brightness (range -255 to 255)
                dicomImage.AdjustBrightness(30);

                // Adjust contrast (range -100 to 100)
                dicomImage.AdjustContrast(20f);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the processed image as TIFF
                dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to convert DICOM scans to high‑resolution TIFF files for archival while applying brightness and contrast corrections to improve visual quality, developers can use this code.
 * 2. When a radiology workflow must process large DICOM images on a server with limited RAM, the memory‑buffer strategy in the example enables efficient loading before exporting the adjusted image as TIFF.
 * 3. When a research project requires extracting DICOM data, enhancing the image for publication, and storing it in a widely supported TIFF format for downstream analysis, this C# snippet provides the necessary steps.
 * 4. When a PACS integration needs to generate TIFF thumbnails with adjusted brightness and contrast for quick preview in a web portal, developers can employ the shown load‑adjust‑save pattern.
 * 5. When a healthcare software vendor wants to implement a feature that reads DICOM files, applies standardized brightness/contrast settings, and outputs TIFF files compatible with third‑party reporting tools, the code demonstrates the required workflow.
 */