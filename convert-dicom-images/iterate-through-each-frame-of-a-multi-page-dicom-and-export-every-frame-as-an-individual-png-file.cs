using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directory
        string inputPath = @"c:\temp\sample.dicom";
        string outputDir = @"c:\temp\";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (DirectoryName may be null if outputPath is root, guard against that)
            Directory.CreateDirectory(outputDir);

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page (frame) in the multi‑page DICOM
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file name based on page index
                        string outputPath = Path.Combine(outputDir, $"sample.{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the current page as a PNG image
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