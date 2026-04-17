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
        string inputPath = @"C:\temp\multiframe.dcm";

        // Hardcoded output directory for PNG files
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional as per rules)
        Directory.CreateDirectory(outputDir);

        // Open the DICOM file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the multi‑page DICOM image
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page (frame) in the DICOM image
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the output PNG file path for the current page
                    string outputPath = Path.Combine(outputDir, $"frame_{dicomPage.Index}.png");

                    // Ensure the directory for this file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as a PNG image
                    dicomPage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}