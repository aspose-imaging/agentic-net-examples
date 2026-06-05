using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputDirectory = @"c:\temp\";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDirectory);

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the multi‑page DICOM image
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page (frame) in the DICOM image
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output file name based on the page index
                        string outputPath = Path.Combine(outputDirectory, $"sample.{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the current page as a PNG file
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}