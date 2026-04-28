using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputDicom";
        string outputDirectory = @"C:\OutputPng";

        // Overall progress reporter
        IProgress<double> overallProgress = new Progress<double>(p =>
            Console.WriteLine($"Overall progress: {p:F2}%"));

        try
        {
            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            int totalFiles = dicomFiles.Length;
            int processedFiles = 0;

            foreach (string inputPath in dicomFiles)
            {
                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Progress handler for loading the DICOM image
                LoadOptions loadOptions = new LoadOptions
                {
                    ProgressEventHandler = info =>
                    {
                        // Report load progress as a percentage of the current file
                        double percent = (double)info.Value / info.MaxValue * 100.0;
                        Console.WriteLine($"Loading {Path.GetFileName(inputPath)}: {percent:F2}%");
                    }
                };

                // Load the DICOM image
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Cast to DicomImage to access pages
                    DicomImage dicomImage = (DicomImage)image;

                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output file name
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Progress handler for saving the PNG page
                        PngOptions pngOptions = new PngOptions
                        {
                            ProgressEventHandler = info =>
                            {
                                double percent = (double)info.Value / info.MaxValue * 100.0;
                                Console.WriteLine($"Saving {outputFileName}: {percent:F2}%");
                            }
                        };

                        // Save the page as PNG
                        page.Save(outputPath, pngOptions);
                    }
                }

                // Update overall progress after each file
                processedFiles++;
                overallProgress.Report((double)processedFiles / totalFiles * 100.0);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}