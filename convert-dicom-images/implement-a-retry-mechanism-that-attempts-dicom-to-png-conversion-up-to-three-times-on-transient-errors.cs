using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        const int maxAttempts = 3;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                // Load DICOM image
                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    int pageIndex = 0;
                    foreach (var page in dicom.DicomPages)
                    {
                        // Build per-page output file name
                        string pageOutput = Path.Combine(
                            Path.GetDirectoryName(outputPath) ?? string.Empty,
                            $"output_page_{pageIndex}.png");

                        // Ensure directory for each page exists
                        Directory.CreateDirectory(Path.GetDirectoryName(pageOutput));

                        // Save page as PNG
                        page.Save(pageOutput, new PngOptions());
                        pageIndex++;
                    }
                }

                // Conversion succeeded; exit retry loop
                break;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Attempt {attempt} failed: {ex.Message}");
                if (attempt == maxAttempts)
                {
                    Console.Error.WriteLine("All attempts failed.");
                }
            }
        }
    }
}