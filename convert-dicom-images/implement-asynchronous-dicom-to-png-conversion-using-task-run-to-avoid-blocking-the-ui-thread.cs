using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous conversion of a DICOM file to PNG images (one per page)
    static async Task ConvertDicomToPngAsync(string inputPath, string outputDirectory)
    {
        await Task.Run(() =>
        {
            // Load the DICOM image from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                    // Ensure the directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG using the provided PngOptions
                    page.Save(outputPath, new PngOptions());
                }
            }
        });
    }

    static void Main()
    {
        // Hardcoded input and output paths
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

            // Ensure the output directory exists (covers the case where no pages are processed)
            Directory.CreateDirectory(outputDirectory);

            // Run the conversion asynchronously and wait for completion
            ConvertDicomToPngAsync(inputPath, outputDirectory).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}