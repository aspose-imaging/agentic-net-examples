using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DICOM file path
            string inputPath = @"C:\Temp\input.dcm";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output folder for PNG files
            string outputFolder = @"C:\Temp\OutputPng";

            // Load the DICOM image
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Iterate through each DICOM page and save as PNG
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputFolder, $"page{dicomPage.Index}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    dicomPage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}