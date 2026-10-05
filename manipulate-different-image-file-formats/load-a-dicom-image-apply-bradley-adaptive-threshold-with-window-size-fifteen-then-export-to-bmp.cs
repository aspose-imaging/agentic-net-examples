// HOW-TO: Apply Bradley Adaptive Threshold to DICOM and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "result.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                if (!dicom.IsCached)
                {
                    dicom.CacheData();
                }

                // Apply Bradley Adaptive Threshold with window size 15 (using typical threshold 0.15)
                dicom.BinarizeBradley(0.15, 15);

                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    dicom.Save(outputPath, bmpOptions);
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
 * 1. When a radiology application needs to convert DICOM scans to high‑contrast BMP files for legacy PACS systems.
 * 2. When developers want to preprocess medical images with Bradley adaptive binarization before performing OCR on scanned reports.
 * 3. When a diagnostic tool requires thresholded bitmap output to highlight bone structures for visual inspection.
 * 4. When integrating Aspose.Imaging in a C# workflow to batch‑process DICOM files and store them as BMP for use in non‑medical software.
 * 5. When a research project needs to apply a 15‑pixel window adaptive threshold to DICOM images to reduce noise before image analysis.
 */
