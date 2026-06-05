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
            string inputPath = "input.dcm";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DICOM image and ensure it is disposed after use
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Iterate through each page and save as PNG
                foreach (DicomPage page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                    // Ensure the directory for the output file exists (covers cases where outputPath includes subfolders)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}