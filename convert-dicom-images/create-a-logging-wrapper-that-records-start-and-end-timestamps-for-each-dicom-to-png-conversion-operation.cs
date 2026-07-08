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
            // Hardcoded input DICOM file and output directory
            string inputPath = "sample.dicom";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Log start timestamp
            Console.WriteLine($"Conversion started at {DateTime.Now:O}");

            // Load the DICOM image from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDir, $"page{page.Index}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a PNG image
                    page.Save(outputPath, new PngOptions());
                }
            }

            // Log end timestamp
            Console.WriteLine($"Conversion finished at {DateTime.Now:O}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology software needs to batch‑convert DICOM scans to PNG thumbnails and record the start and end times for performance monitoring.
 * 2. When a medical research pipeline processes multi‑frame DICOM images, saves each frame as a PNG file, and logs timestamps to audit processing duration.
 * 3. When a hospital IT system automates the extraction of DICOM pages to PNG for integration with electronic health records while tracking conversion timestamps for compliance reporting.
 * 4. When a developer builds a command‑line utility that validates the existence of a DICOM file, creates an output folder, converts each DICOM page to PNG using Aspose.Imaging, and logs the operation timeline for debugging.
 * 5. When a QA engineer needs to verify that a C# application correctly loads DICOM images from a file stream, saves them as PNG images, and records precise start and finish times to detect performance regressions.
 */