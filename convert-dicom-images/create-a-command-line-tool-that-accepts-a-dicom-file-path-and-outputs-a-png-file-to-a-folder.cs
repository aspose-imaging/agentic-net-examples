using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file and output folder
        string inputPath = @"C:\temp\sample.dicom";
        string outputFolder = @"C:\temp\output\";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (unconditional)
            Directory.CreateDirectory(outputFolder);

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputFolder, $"sample.{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists (unconditional)
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