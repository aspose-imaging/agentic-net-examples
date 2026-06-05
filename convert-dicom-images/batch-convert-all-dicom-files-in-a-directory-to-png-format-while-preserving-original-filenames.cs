using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputDicom";
        string outputDirectory = @"C:\OutputPng";

        try
        {
            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare base name for output files
                string baseFileName = Path.GetFileNameWithoutExtension(inputPath);

                // Open the DICOM file as a stream and load it
                using (Stream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page of the DICOM image
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file name (preserve original name, add page index if multi‑page)
                        string outputFileName = $"{baseFileName}_{dicomPage.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}