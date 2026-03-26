using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all DICOM files in the input directory
        string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

        // Progress reporter using IProgress
        IProgress<ProgressEventHandlerInfo> progress = new Progress<ProgressEventHandlerInfo>(info =>
        {
            Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}");
        });

        foreach (var inputPath in dicomFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DICOM file stream
            using (var stream = File.OpenRead(inputPath))
            {
                // Load DICOM image with progress handling
                using (var dicomImage = new DicomImage(stream, new LoadOptions { ProgressEventHandler = info => progress.Report(info) }))
                {
                    int pageIndex = 0;
                    foreach (var page in dicomImage.DicomPages)
                    {
                        // Construct output PNG path
                        string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputDirectory, $"{baseFileName}_{pageIndex}.png");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG with progress handling
                        var pngOptions = new PngOptions { ProgressEventHandler = info => progress.Report(info) };
                        page.Save(outputPath, pngOptions);

                        pageIndex++;
                    }
                }
            }
        }
    }
}