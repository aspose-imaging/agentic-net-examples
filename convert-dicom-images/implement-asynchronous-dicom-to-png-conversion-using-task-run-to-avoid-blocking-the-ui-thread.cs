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
        // Run the potentially blocking I/O operations on a background thread
        await Task.Run(() =>
        {
            // Load the DICOM image from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                    // Ensure the directory for the output file exists (covers cases where outputDirectory may include subfolders)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG using Aspose.Imaging's PngOptions
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

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Perform the conversion asynchronously and wait for completion
        Task conversionTask = ConvertDicomToPngAsync(inputPath, outputDirectory);
        conversionTask.Wait();
    }
}