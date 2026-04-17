using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\InputDicom";
        string outputDir = @"C:\OutputPng";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

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

            try
            {
                // Open the DICOM file as a stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Load the DICOM image
                    using (DicomImage dicomImage = new DicomImage(stream))
                    {
                        // Iterate through each page and save as PNG
                        foreach (DicomPage dicomPage in dicomImage.DicomPages)
                        {
                            // Build output file name: originalname_page{index}.png
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{dicomPage.Index}.png";
                            string outputPath = Path.Combine(outputDir, outputFileName);

                            // Ensure the output directory exists (unconditional as per rules)
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            dicomPage.Save(outputPath, new PngOptions());
                        }
                    }
                }
            }
            catch (DicomImageException ex)
            {
                // Gracefully skip corrupted DICOM files
                Console.Error.WriteLine($"Skipping corrupted file: {inputPath}. Reason: {ex.Message}");
                continue;
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors without stopping the batch
                Console.Error.WriteLine($"Error processing file: {inputPath}. Reason: {ex.Message}");
                continue;
            }
        }
    }
}