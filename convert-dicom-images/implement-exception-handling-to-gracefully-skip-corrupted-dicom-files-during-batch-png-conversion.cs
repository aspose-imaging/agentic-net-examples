// HOW-TO: Convert DICOM to PNG in Batch While Skipping Corrupted Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add DICOM files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                try
                {
                    using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                    {
                        int pageIndex = 0;
                        foreach (var dicomPage in dicomImage.DicomPages)
                        {
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure output directory exists for this file
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save page as PNG
                            dicomPage.Save(outputPath, new PngOptions());

                            pageIndex++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing file '{inputPath}': {ex.Message}");
                    // Continue with next file
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
 * 1. When a hospital needs to generate viewable PNG thumbnails from thousands of DICOM scans but some files are damaged, this code converts the valid images while automatically ignoring the corrupted ones.
 * 2. When a research lab processes a large dataset of medical images for machine‑learning and must ensure the pipeline continues even if a few DICOM files are unreadable, the example provides robust batch conversion with error handling.
 * 3. When a PACS integration project requires exporting patient studies to PNG for web display and wants to avoid runtime crashes caused by malformed DICOM files, this snippet safely skips those files.
 * 4. When a developer builds an automated nightly job that transforms incoming DICOM files into PNG assets for a reporting system and needs the job to complete despite occasional file corruption, the code handles exceptions and proceeds.
 * 5. When a software vendor creates a bulk image conversion tool that supports Aspose.Imaging and must gracefully handle unexpected DICOM errors while producing PNG outputs, this example demonstrates the required pattern.
 */
