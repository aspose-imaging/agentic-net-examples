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
            // Hardcoded input DICOM file and output directory
            string inputPath = "sample.dicom";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the DICOM image from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page in the DICOM image
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build output PNG file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{dicomPage.Index}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Log start timestamp
                    DateTime start = DateTime.UtcNow;
                    Console.WriteLine($"[{start:O}] Starting conversion of page {dicomPage.Index}");

                    // Save the page as a PNG image
                    dicomPage.Save(outputPath, new PngOptions());

                    // Log end timestamp
                    DateTime end = DateTime.UtcNow;
                    Console.WriteLine($"[{end:O}] Finished conversion of page {dicomPage.Index}");
                }
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}