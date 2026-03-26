using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Define input and output directories (relative to current directory)
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Get all DICOM files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the DICOM image
            using (var dicomImage = (DicomImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                // Iterate through each page of the DICOM image
                foreach (var page in dicomImage.DicomPages)
                {
                    // Build output file name for the current page
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + $"_page{pageIndex}.png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());

                    pageIndex++;
                }
            }
        }
    }
}