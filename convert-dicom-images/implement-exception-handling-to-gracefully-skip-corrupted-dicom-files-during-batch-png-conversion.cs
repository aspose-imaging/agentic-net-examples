using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\InputDicom";
        string outputDir = @"C:\OutputPng";

        try
        {
            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDir, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    // Load DICOM image and save as PNG
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PngOptions());
                    }
                }
                catch (DicomImageException)
                {
                    // Skip corrupted DICOM files
                    Console.Error.WriteLine($"Skipping corrupted DICOM file: {inputPath}");
                    continue;
                }
                catch (Exception ex)
                {
                    // Log other errors and continue with next file
                    Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
                    continue;
                }
            }
        }
        catch (Exception ex)
        {
            // Global error handling
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital IT team needs to batch‑convert thousands of patient DICOM scans to PNG thumbnails for an electronic health record portal while automatically skipping any corrupted files.
 * 2. When a research laboratory automates the preprocessing of radiology images for a machine‑learning pipeline, converting DICOM to PNG and ensuring that unreadable scans do not stop the workflow.
 * 3. When a medical‑imaging startup creates a C# desktop utility that generates PNG previews of DICOM studies using Aspose.Imaging and must handle DicomImageException to keep the conversion running.
 * 4. When a radiology PACS migration script exports legacy DICOM archives to PNG for cloud storage, requiring exception handling to continue processing despite damaged files.
 * 5. When a quality‑control engineer runs a batch conversion job that logs and skips corrupted DICOM files, guaranteeing a complete conversion report without manual intervention.
 */