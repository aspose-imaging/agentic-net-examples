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
            // Hardcoded input and output paths
            string inputPath = "sample.dicom";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the DICOM image from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    // Build output file path for each page
                    string outputPath = Path.Combine(outputDir, $"page_{page.Index}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Log start timestamp
                    DateTime start = DateTime.Now;
                    Console.WriteLine($"[{start:O}] Starting conversion of page {page.Index}");

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());

                    // Log end timestamp
                    DateTime end = DateTime.Now;
                    Console.WriteLine($"[{end:O}] Finished conversion of page {page.Index}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}