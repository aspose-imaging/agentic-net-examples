using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputDicom";
            string outputDirectory = @"C:\OutputPng";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                try
                {
                    // Open the DICOM file as a stream
                    using (FileStream stream = File.OpenRead(inputPath))
                    using (DicomImage dicomImage = new DicomImage(stream))
                    {
                        // Process each page of the DICOM image
                        foreach (DicomPage page in dicomImage.DicomPages)
                        {
                            // Build output file name: originalName.pageIndex.png
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.{page.Index}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            page.Save(outputPath, new PngOptions());
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
                    // Log any other errors for this file and continue with next
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