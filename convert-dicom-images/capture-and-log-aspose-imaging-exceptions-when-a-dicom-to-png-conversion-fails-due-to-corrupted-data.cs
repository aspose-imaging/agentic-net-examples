using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "input.dcm";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists before any save operation
            Directory.CreateDirectory(outputDirectory);

            // Open the DICOM file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page in the DICOM image
                    foreach (var dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output PNG file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                        // Ensure the directory for the output file exists (redundant but follows rule)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG using Aspose.Imaging's PngOptions
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log any exception, including Aspose.Imaging specific ones
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}