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
            string inputPath = @"C:\Temp\multiframe.dcm";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for PNG files
            string outputDir = @"C:\Temp\DICOM_Frames";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Load the DICOM image from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page (frame) and save as PNG
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{dicomPage.Index}.png");

                        // Ensure the directory for this file exists (covers cases where outputDir may include subfolders)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the current page as PNG
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