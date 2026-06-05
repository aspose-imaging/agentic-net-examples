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
            string outputDirectory = "output";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (will be called before each save as well)
            Directory.CreateDirectory(outputDirectory);

            // Perform conversion asynchronously to avoid blocking the UI thread
            await ConvertDicomToPngAsync(inputPath, outputDirectory);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Task ConvertDicomToPngAsync(string dicomPath, string outputDir)
    {
        // Wrap the CPU‑bound conversion work in Task.Run
        return Task.Run(() =>
        {
            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(dicomPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build output file name
                        string outputPath = Path.Combine(outputDir, $"page_{dicomPage.Index}.png");

                        // Ensure the directory for this file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG using Aspose.Imaging's PngOptions
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        });
    }
}