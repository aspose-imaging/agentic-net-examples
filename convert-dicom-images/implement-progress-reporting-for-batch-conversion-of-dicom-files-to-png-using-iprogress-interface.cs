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
            IProgress<ProgressEventHandlerInfo> progress = new Progress<ProgressEventHandlerInfo>(info =>
                Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}")
            );

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path (one PNG per DICOM file; multi‑page handled later)
                string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, baseFileName + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load options with progress callback
                var loadOptions = new LoadOptions
                {
                    ProgressEventHandler = info => progress.Report(info)
                };

                // Load the DICOM image
                using (var dicomImage = (DicomImage)Image.Load(inputPath, loadOptions))
                {
                    // If the DICOM image has multiple pages, save each page separately
                    if (dicomImage.PageCount > 1)
                    {
                        int pageIndex = 0;
                        foreach (var page in dicomImage.DicomPages)
                        {
                            string pageOutputPath = Path.Combine(
                                outputDirectory,
                                $"{baseFileName}_page{pageIndex}.png"
                            );

                            // Ensure directory exists for each page file
                            Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));

                            var pngOptions = new PngOptions
                            {
                                ProgressEventHandler = info => progress.Report(info)
                            };

                            page.Save(pageOutputPath, pngOptions);
                            pageIndex++;
                        }
                    }
                    else
                    {
                        // Single‑page DICOM: save directly
                        var pngOptions = new PngOptions
                        {
                            ProgressEventHandler = info => progress.Report(info)
                        };

                        dicomImage.Save(outputPath, pngOptions);
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