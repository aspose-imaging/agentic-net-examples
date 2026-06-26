using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Simple progress reporter that writes percentage to console
    class ConsoleProgress : IProgress<double>
    {
        public void Report(double value)
        {
            Console.WriteLine($"Progress: {value:0.##}%");
        }
    }

    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\DicomInput";
        string outputDirectory = @"C:\PngOutput";

        // Create progress reporter
        var progress = new ConsoleProgress();

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

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DICOM image from file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Process each page of the DICOM image
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output PNG file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.{page.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as PNG
                        page.Save(outputPath, new PngOptions());
                    }
                }

                // Report progress after each file
                double percent = ((i + 1) / (double)totalFiles) * 100.0;
                progress.Report(percent);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology department needs to convert a large batch of DICOM scans into PNG thumbnails for quick web preview, the code can process each file and report conversion progress.
 * 2. When a medical research project must archive thousands of DICOM images as lossless PNG files while monitoring the operation’s status in the console, this example provides a ready‑to‑use solution.
 * 3. When a healthcare IT team wants to automate nightly conversion of DICOM files from a PACS folder to PNG for downstream analytics and needs real‑time percentage feedback, the IProgress implementation handles it.
 * 4. When a developer builds a desktop utility that lets users select an input folder of DICOM images and outputs PNGs with page numbers, the progress reporter keeps users informed about the batch processing.
 * 5. When integrating Aspose.Imaging into a C# workflow that extracts each DICOM page and saves it as a separate PNG file, the code’s progress reporting helps detect stalls or errors during large‑scale image conversion.
 */