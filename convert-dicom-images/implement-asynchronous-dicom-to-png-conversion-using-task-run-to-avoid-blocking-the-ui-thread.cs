// HOW-TO: Asynchronously Convert DICOM Files To PNG Using Task.Run In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input DICOM file and output directory
            string inputPath = @"c:\temp\sample.dicom";
            string outputDir = @"c:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Perform conversion asynchronously
            await ConvertDicomToPngAsync(inputPath, outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static Task ConvertDicomToPngAsync(string inputPath, string outputDir)
    {
        return Task.Run(() =>
        {
            // Load DICOM image from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{page.Index}.png");
                        page.Save(outputPath, new PngOptions());
                    }
                }
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to display DICOM scans as PNG thumbnails without freezing the UI.
 * 2. When a radiology web service must batch‑process DICOM studies into PNG images on a background thread.
 * 3. When a desktop tool converts patient DICOM files to PNG for inclusion in reports while keeping the UI responsive.
 * 4. When an automated pipeline extracts each frame of a multi‑page DICOM and saves them as separate PNG files without blocking other operations.
 * 5. When a C# WinForms or WPF application loads large DICOM images and wants to offload the conversion to PNG to a worker thread to improve user experience.
 */
