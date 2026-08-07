using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputDicom";
        string outputDirectory = @"C:\OutputPng";

        try
        {
            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each DICOM file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.dcm"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    // Load the DICOM image
                    using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                    {
                        int pageIndex = 0;
                        // Convert each page to PNG
                        foreach (DicomPage dicomPage in dicomImage.DicomPages)
                        {
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            dicomPage.Save(outputPath, new PngOptions());

                            pageIndex++;
                        }
                    }
                }
                catch (DicomImageException ex)
                {
                    // Skip corrupted DICOM files gracefully
                    Console.Error.WriteLine($"Skipping corrupted DICOM file: {inputPath}. Reason: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Log any other errors for this file and continue
                    Console.Error.WriteLine($"Error processing file {inputPath}: {ex.Message}");
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
 * 1. When a hospital IT team needs to batch‑convert thousands of DICOM scans to PNG for a web‑based viewer while automatically skipping any corrupted DICOM files that would otherwise halt the process.
 * 2. When a research lab processes multi‑frame DICOM series from MRI studies and wants each frame saved as a separate PNG image, gracefully ignoring unreadable files to keep the analysis pipeline running.
 * 3. When a medical imaging startup runs an automated nightly job that extracts thumbnail PNGs from a directory of DICOM files for a PACS dashboard, and must handle occasional file corruption without manual intervention.
 * 4. When a radiology department creates a backup script that converts archived DICOM files to lossless PNGs for long‑term storage, while logging and skipping any files that raise a DicomImageException.
 * 5. When a cloud‑based image‑processing service ingests user‑uploaded DICOM files, converts each page to PNG for downstream AI analysis, and needs to continue processing the batch even if some uploads are corrupted.
 */