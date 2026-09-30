// HOW-TO: Batch Convert DICOM to PNG in C# Skipping Corrupted Files (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace DicomBatchConverter
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

                // Ensure the output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all DICOM files in the input directory
                string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

                foreach (string inputPath in dicomFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Prepare output path with .png extension
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + ".png");

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    try
                    {
                        // Load DICOM image and save as PNG
                        using (Image image = Image.Load(inputPath))
                        {
                            var pngOptions = new PngOptions();
                            image.Save(outputPath, pngOptions);
                        }

                        Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                    }
                    catch (Exception ex)
                    {
                        // Skip corrupted files and continue processing
                        Console.Error.WriteLine($"Failed to convert {inputPath}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital needs to convert a folder of DICOM scans to PNG for quick viewing in web applications while ignoring any damaged files.
 * 2. When a research lab processes large sets of medical images and wants an automated C# script that safely skips unreadable DICOM files during batch conversion.
 * 3. When a PACS integration requires exporting images to PNG format for reporting tools without halting the workflow due to corrupted entries.
 * 4. When a developer builds a command‑line utility to prepare radiology images for machine‑learning pipelines and must handle occasional file corruption gracefully.
 * 5. When a medical imaging startup needs to generate thumbnail PNGs from incoming DICOM uploads and ensure the conversion continues even if some files are malformed.
 */
