using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.dcm";
        string outputDirectory = "Output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Load DICOM image
            using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Iterate through each DICOM page and save as PNG
                foreach (var dicomPage in dicomImage.DicomPages)
                {
                    string pageOutputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");
                    // Ensure directory for the page exists
                    Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));

                    // Save page as PNG
                    dicomPage.Save(pageOutputPath, new PngOptions());
                }
            }
        }
        catch (Aspose.Imaging.CoreExceptions.ImageFormats.DicomImageException ex)
        {
            // Log Aspose.Imaging specific exception
            Console.Error.WriteLine($"Aspose.Imaging DICOM error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Log any other exception
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}