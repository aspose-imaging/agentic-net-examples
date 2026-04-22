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
        string inputDir = @"C:\InputDicom";
        string outputDir = @"C:\OutputPng";

        try
        {
            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each DICOM file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.dcm"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file name (base name without extension)
                string baseName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, baseName + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    // Load the DICOM image using the provided load rule
                    using (Image image = Image.Load(inputPath))
                    {
                        // If the loaded image is a multi‑page DICOM, save each page separately
                        DicomImage dicomImage = image as DicomImage;
                        if (dicomImage != null)
                        {
                            int pageIndex = 0;
                            foreach (DicomPage page in dicomImage.DicomPages)
                            {
                                string pageOutputPath = Path.Combine(outputDir, $"{baseName}_{pageIndex}.png");
                                Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));
                                page.Save(pageOutputPath, new PngOptions());
                                pageIndex++;
                            }
                        }
                        else
                        {
                            // Single‑page fallback: save directly as PNG
                            image.Save(outputPath, new PngOptions());
                        }
                    }
                }
                catch (DicomImageException ex)
                {
                    // Gracefully skip corrupted DICOM files
                    Console.Error.WriteLine($"Skipping corrupted DICOM file: {inputPath}. Reason: {ex.Message}");
                    continue;
                }
                catch (PngImageException ex)
                {
                    // Handle PNG saving issues without stopping the batch
                    Console.Error.WriteLine($"Error saving PNG for file: {inputPath}. Reason: {ex.Message}");
                    continue;
                }
                catch (Exception ex)
                {
                    // Catch any other unexpected errors for this file
                    Console.Error.WriteLine($"Unexpected error processing file {inputPath}: {ex.Message}");
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