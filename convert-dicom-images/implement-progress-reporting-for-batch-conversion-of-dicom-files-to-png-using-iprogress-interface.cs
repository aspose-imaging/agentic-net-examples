// HOW-TO: Batch Convert DICOM Files to PNG with Progress Reporting in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputDicom";
            string outputDirectory = @"C:\OutputPng";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            // Progress reporter using IProgress
            IProgress<ProgressEventHandlerInfo> progressReporter = new Progress<ProgressEventHandlerInfo>(info =>
            {
                Console.WriteLine($"{info.EventType}: {info.Value}/{info.MaxValue}");
            });

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image with a load options progress handler
                var loadOptions = new LoadOptions
                {
                    ProgressEventHandler = info => progressReporter.Report(info)
                };

                using (var dicomImage = (DicomImage)Image.Load(inputPath, loadOptions))
                {
                    int pageIndex = 0;
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        // Build output PNG file path
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + $"_page{pageIndex}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save each page as PNG with its own progress handler
                        var pngOptions = new PngOptions
                        {
                            ProgressEventHandler = info => progressReporter.Report(info)
                        };

                        dicomPage.Save(outputPath, pngOptions);
                        pageIndex++;
                    }
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
 * 1. When a medical imaging application must export thousands of DICOM scans to PNG thumbnails while showing conversion progress to the user.
 * 2. When a radiology workflow needs to automate batch processing of DICOM files into web‑friendly PNG images and monitor the status in a C# service.
 * 3. When a research project requires converting multi‑page DICOM studies to separate PNG files and logging progress for long‑running jobs.
 * 4. When a hospital IT system integrates Aspose.Imaging to transform DICOM archives into PNG for electronic health record display with real‑time feedback.
 * 5. When a desktop utility must read DICOM files from a folder, save each page as a PNG, and report the percentage completed using the IProgress interface.
 */
