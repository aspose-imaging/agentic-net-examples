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
        string inputPath = @"C:\Temp\input.dcm";
        string outputDirectory = @"C:\Temp\Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        const int maxAttempts = 3;
        int attempt = 0;
        bool success = false;

        while (attempt < maxAttempts && !success)
        {
            try
            {
                // Open the DICOM file as a stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Load the DICOM image from the stream
                    using (DicomImage dicomImage = new DicomImage(stream))
                    {
                        // Iterate through each page and save as PNG
                        foreach (DicomPage dicomPage in dicomImage.DicomPages)
                        {
                            // Build output file name for the current page
                            string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the page as PNG
                            dicomPage.Save(outputPath, new PngOptions());
                        }
                    }
                }

                // If we reach this point, conversion succeeded
                success = true;
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex) // Catch transient errors
            {
                attempt++;
                if (attempt >= maxAttempts)
                {
                    Console.Error.WriteLine($"Conversion failed after {maxAttempts} attempts: {ex.Message}");
                    return;
                }
                // Optionally, you could add a short delay before retrying
            }
        }
    }
}