using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Define input and output directories
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all DICOM files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            try
            {
                // Load the DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    DicomImage dicomImage = (DicomImage)image;

                    // Iterate through each page of the DICOM file
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        // Build output file path for the current page
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error and skip the corrupted file
                Console.Error.WriteLine($"Failed to process {inputPath}: {ex.Message}");
                continue;
            }
        }
    }
}