using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.dcm";
        string outputPath = @"C:\Temp\sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Convert the first (or only) page to PNG
                dicomImage.Save(outputPath, new PngOptions());
            }

            // Compare file sizes
            long dicomSize = new FileInfo(inputPath).Length;
            long pngSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"DICOM size: {dicomSize} bytes");
            Console.WriteLine($"PNG size:   {pngSize} bytes");

            // Simple verification: PNG should have a non‑zero size
            if (pngSize == 0)
            {
                Console.Error.WriteLine("Conversion failed: PNG file is empty.");
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
 * 1. When a medical imaging application needs to preview DICOM scans in a web browser, a developer can use this code to convert the DICOM file to a PNG thumbnail and verify that the PNG size is non‑zero.
 * 2. When integrating a PACS system with a reporting tool, a developer can load patient DICOM images, convert them to PNG for inclusion in PDF reports, and compare file sizes to ensure the conversion succeeded.
 * 3. When building an automated quality‑control pipeline for radiology data, a developer can run this unit test to confirm that each DICOM file produces a valid PNG output and that the PNG file size meets expected thresholds.
 * 4. When migrating legacy DICOM archives to a cloud storage solution that only supports common image formats, a developer can use this code to batch‑convert DICOM files to PNG and log size differences for storage cost analysis.
 * 5. When creating a diagnostic mobile app that displays scans on low‑resolution devices, a developer can convert DICOM images to PNG and compare the resulting file size to decide if further compression is required.
 */