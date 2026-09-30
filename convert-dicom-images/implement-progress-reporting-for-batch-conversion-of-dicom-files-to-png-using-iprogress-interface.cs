// HOW-TO: Report Progress While Converting DICOM Batch to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchDicomToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input";
                string outputDirectory = "output";

                // Progress reporter
                IProgress<int> progress = new Progress<int>(p =>
                    Console.WriteLine($"Progress: {p}%"));

                ConvertBatch(inputDirectory, outputDirectory, progress);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertBatch(string inputDir, string outputDir, IProgress<int> progress)
        {
            // Ensure the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Get all DICOM files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.dcm");
            int total = files.Length;

            for (int i = 0; i < total; i++)
            {
                string inputPath = files[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path
                string outputPath = Path.Combine(
                    outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }

                // Report progress
                int percent = (int)((i + 1) * 100.0 / total);
                progress?.Report(percent);
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert dozens of DICOM scans to PNG thumbnails while showing a percentage complete in the console.
 * 2. When a radiology workflow automates exporting patient study files to a web‑friendly format and wants real‑time progress feedback for monitoring.
 * 3. When a desktop tool processes large DICOM directories and must ensure the output folder exists before saving each PNG image.
 * 4. When a developer integrates Aspose.Imaging into a C# service that reports conversion status to a UI or logging system using the IProgress interface.
 * 5. When a batch script must handle missing files gracefully and provide error messages while converting DICOM images to PNG for further analysis.
 */
