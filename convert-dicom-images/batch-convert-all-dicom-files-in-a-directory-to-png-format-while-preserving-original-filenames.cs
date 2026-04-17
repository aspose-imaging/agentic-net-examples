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
        string inputDirectory = @"C:\InputDicom";
        string outputDirectory = @"C:\OutputPng";

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

            // Load the DICOM image from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Process each page of the DICOM image
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    // Build output file name: original name + optional page index + .png
                    string baseName = Path.GetFileNameWithoutExtension(inputPath);
                    string fileName = dicomImage.DicomPages.Count > 1
                        ? $"{baseName}_{page.Index}.png"
                        : $"{baseName}.png";

                    string outputPath = Path.Combine(outputDirectory, fileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}