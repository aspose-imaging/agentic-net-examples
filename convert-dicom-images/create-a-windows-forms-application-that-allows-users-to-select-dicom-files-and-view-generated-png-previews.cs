using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DICOM file and output directory
        string inputPath = "sample.dcm";
        string outputDir = "Previews";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load DICOM image from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    int pageIndex = 0;
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output PNG file path for each page
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());

                        pageIndex++;
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