using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output/output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image with memory strategy
            using (FileStream stream = File.OpenRead(inputPath))
            {
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB buffer size hint
                };

                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Adjust brightness and contrast
                    dicomImage.AdjustBrightness(50);      // Increase brightness
                    dicomImage.AdjustContrast(30f);      // Increase contrast

                    // Save as TIFF
                    var tiffOptions = new TiffOptions();
                    dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application must convert DICOM scans to TIFF files for archival while adjusting brightness and contrast to improve visual clarity, developers can use this code.
 * 2. When a radiology workflow requires batch processing of large DICOM images on limited‑memory machines, the memory‑strategy loading and pixel‑level adjustments demonstrated here are essential.
 * 3. When a healthcare integration service needs to expose DICOM data to non‑DICOM‑aware systems, converting the image to a standard TIFF format with enhanced contrast ensures compatibility.
 * 4. When a diagnostic software must preprocess DICOM images before applying machine‑learning models, adjusting brightness and contrast programmatically using Aspose.Imaging simplifies the pipeline.
 * 5. When a hospital’s PACS export tool has to generate high‑quality printable TIFF copies of DICOM studies on the fly, this C# snippet provides a reliable way to load, enhance, and save the images.
 */