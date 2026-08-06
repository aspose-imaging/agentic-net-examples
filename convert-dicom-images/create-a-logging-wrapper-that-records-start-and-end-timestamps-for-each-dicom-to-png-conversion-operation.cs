using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dicom";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page in the DICOM image
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output PNG file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Log start timestamp
                        DateTime startTime = DateTime.Now;
                        Console.WriteLine($"Start converting page {dicomPage.Index} at {startTime:O}");

                        // Save the page as PNG
                        dicomPage.Save(outputPath, new PngOptions());

                        // Log end timestamp
                        DateTime endTime = DateTime.Now;
                        Console.WriteLine($"End converting page {dicomPage.Index} at {endTime:O}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital IT system needs to batch‑convert DICOM scans to PNG thumbnails for a web‑based patient portal while tracking how long each page conversion takes.
 * 2. When a research lab processes large sets of multi‑frame DICOM studies into PNG images for machine‑learning pipelines and requires timestamps to measure processing throughput.
 * 3. When a radiology software vendor implements an audit log for regulatory compliance, recording start and end times of every DICOM‑to‑PNG conversion performed by Aspose.Imaging in C#.
 * 4. When a cloud‑based imaging service scales out conversion jobs and wants to monitor per‑page performance to identify bottlenecks in the Aspose.Imaging conversion workflow.
 * 5. When a QA engineer validates the stability of a C# application that converts DICOM pages to PNG and needs precise timestamps to compare execution times across different hardware configurations.
 */