// HOW-TO: Log Timestamps While Converting DICOM Pages to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Logs the start and end timestamps of a conversion operation.
    static void LogConversion(int pageIndex, Action conversionAction)
    {
        Console.WriteLine($"[Start] Converting page {pageIndex} at {DateTime.UtcNow:O}");
        conversionAction();
        Console.WriteLine($"[End]   Converting page {pageIndex} at {DateTime.UtcNow:O}");
    }

    static void ConvertDicomToPng(string inputPath, string outputDirectory)
    {
        // Ensure the output directory exists.
        Directory.CreateDirectory(outputDirectory);

        // Load the DICOM image from file.
        using (FileStream stream = File.OpenRead(inputPath))
        using (DicomImage dicomImage = new DicomImage(stream))
        {
            // Iterate through each page in the DICOM file.
            foreach (DicomPage dicomPage in dicomImage.DicomPages)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                // Log timestamps around the save operation.
                LogConversion(dicomPage.Index, () =>
                {
                    // Save the page as PNG.
                    dicomPage.Save(outputPath, new PngOptions());
                });
            }
        }
    }

    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Perform the conversion.
            ConvertDicomToPng(inputPath, outputDirectory);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application must convert multi‑page DICOM files to PNG for web display while keeping an audit log of each page’s conversion time.
 * 2. When a hospital’s data pipeline needs to track the duration of each DICOM‑to‑PNG conversion to identify performance bottlenecks.
 * 3. When a developer is building a batch processing tool that extracts every frame from a DICOM study and saves them as PNG files with start‑and‑end timestamps for compliance reporting.
 * 4. When integrating Aspose.Imaging into a C# service that must verify that each DICOM page is successfully rendered to PNG and record the exact time of the operation for debugging.
 * 5. When creating a diagnostic utility that converts DICOM images to PNG and logs timestamps to synchronize conversion events with other system logs.
 */
