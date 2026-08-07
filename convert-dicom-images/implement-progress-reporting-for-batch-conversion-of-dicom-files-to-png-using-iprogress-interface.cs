using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputDicom";
        string outputDirectory = @"C:\OutputPng";

        // Progress reporter that writes percentage to console
        IProgress<double> progress = new Progress<double>(p =>
        {
            Console.WriteLine($"Progress: {p:F2}%");
        });

        try
        {
            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            int totalFiles = dicomFiles.Length;
            if (totalFiles == 0)
            {
                Console.WriteLine("No DICOM files found.");
                return;
            }

            for (int i = 0; i < totalFiles; i++)
            {
                string inputPath = dicomFiles[i];

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image
                using (var dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    // Process each page of the DICOM image
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file name: originalname_pageIndex.png
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputFileName = $"{baseName}_{dicomPage.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }

                // Report progress after each file
                double percent = ((i + 1) * 100.0) / totalFiles;
                progress.Report(percent);
            }

            Console.WriteLine("Batch conversion completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application must batch‑convert DICOM scans to PNG thumbnails for web preview and display conversion progress to the user.
 * 2. When a radiology research pipeline needs to export multi‑frame DICOM series as individual PNG files for machine‑learning preprocessing while providing real‑time percentage feedback.
 * 3. When a hospital IT system automates nightly archiving of DICOM studies to PNG format for integration with electronic health record viewers and requires monitoring of the batch status.
 * 4. When a diagnostic device manufacturer builds a C# utility that extracts each DICOM page, saves it as a PNG with the page index, and reports progress to a console or UI logger.
 * 5. When a cloud‑based image processing service processes incoming DICOM files, converts them to PNG for downstream analysis, and uses IProgress<double> to update a progress bar in a monitoring dashboard.
 */