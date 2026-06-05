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
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputDicom";
        string outputDirectory = @"C:\OutputPng";

        // Progress reporter using IProgress<T>
        IProgress<ProgressEventHandlerInfo> progress = new Progress<ProgressEventHandlerInfo>(info =>
        {
            Console.WriteLine($"{info.EventType}: {info.Value}/{info.MaxValue}");
        });

        try
        {
            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DICOM image with progress reporting
                using (DicomImage dicomImage = (DicomImage)Image.Load(
                    inputPath,
                    new LoadOptions { ProgressEventHandler = progress.Report }))
                {
                    // Process each page of the DICOM image
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output PNG file path
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(
                            outputDirectory,
                            $"{baseName}_{page.Index}.png");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG with progress reporting
                        var pngOptions = new PngOptions
                        {
                            ProgressEventHandler = progress.Report
                        };
                        page.Save(outputPath, pngOptions);
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