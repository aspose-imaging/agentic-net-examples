// HOW-TO: Load DICOM Image with High Performance Memory, Adjust Contrast, Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open input DICOM file with a high-performance memory strategy
            using (FileStream stream = File.OpenRead(inputPath))
            {
                var loadOptions = new LoadOptions
                {
                    // Example buffer size hint (256 KB)
                    BufferSizeHint = 256 * 1024
                };

                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Adjust contrast (value range: -100 to 100)
                    dicomImage.AdjustContrast(50f);

                    // Save as TIFF
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a medical imaging application needs to quickly load large DICOM files, modify their contrast for better visualization, and export the result as a TIFF for archiving or further analysis.
 * 2. When a radiology workflow requires converting DICOM scans to a universally viewable format while applying contrast enhancement to highlight details, using a memory‑efficient loading strategy in C#.
 * 3. When a research project processes thousands of DICOM images on limited hardware and must adjust brightness levels before saving them as high‑resolution TIFFs for publication.
 * 4. When a healthcare software integrates Aspose.Imaging to read DICOM streams, apply contrast adjustments on the fly, and generate TIFF files for compatibility with legacy PACS systems.
 * 5. When a developer wants to implement a batch job that reads DICOM files, uses a custom buffer size for performance, enhances image contrast, and stores the output as TIFF for downstream image‑processing pipelines.
 */
