using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file and output directory
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image and ensure it is disposed after use
            using (var dicomImage = (DicomImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the output PNG file path for each page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    dicomPage.Save(outputPath, new PngOptions());

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}