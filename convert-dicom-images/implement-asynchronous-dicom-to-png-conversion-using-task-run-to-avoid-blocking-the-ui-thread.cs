using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Perform conversion asynchronously
            await ConvertDicomToPngAsync(inputPath, outputDir);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Asynchronous conversion using Task.Run
    static Task ConvertDicomToPngAsync(string inputPath, string outputDir)
    {
        return Task.Run(() =>
        {
            // Load DICOM image from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each DICOM page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{page.Index}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG using provided save rule
                    page.Save(outputPath, new PngOptions());
                }
            }
        });
    }
}