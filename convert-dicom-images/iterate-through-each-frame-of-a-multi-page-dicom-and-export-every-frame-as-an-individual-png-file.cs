using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file path
        string inputPath = @"C:\temp\multiframe.dicom";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Directory where PNG files will be saved
        string outputDirectory = @"C:\temp\output";

        // Open the DICOM file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the multi‑page DICOM image
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page (frame) in the DICOM image
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the output file path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{dicomPage.Index}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as a PNG file
                    dicomPage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}