using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    // Progress callback used for both load and save operations
    private static void ProgressCallback(ProgressEventHandlerInfo info)
    {
        // Calculate percentage progress
        double percent = info.MaxValue == 0 ? 0 : (double)info.Value / info.MaxValue * 100;
        // Write progress on the same console line
        Console.Write($"\r{info.EventType}: {percent:0.0}%   ");
    }

    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\InputCdr";
            string outputDir = @"C:\OutputJpg";

            // Get all CDR files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.cdr");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path (same name with .jpg extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR with progress reporting
                var loadOptions = new CdrLoadOptions
                {
                    ProgressEventHandler = ProgressCallback
                };

                using (var cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath, loadOptions))
                {
                    // Prepare JPEG save options with progress reporting
                    var jpegOptions = new JpegOptions
                    {
                        ProgressEventHandler = ProgressCallback
                    };

                    // Save as JPEG
                    cdrImage.Save(outputPath, jpegOptions);
                }

                // Move to next line after each file conversion
                Console.WriteLine();
                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}