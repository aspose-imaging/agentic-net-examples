using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

namespace DicomToPngConverter
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output locations
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

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Load the DICOM image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to DicomImage to access pages
                    DicomImage dicomImage = (DicomImage)image;

                    // Iterate through each page and save as PNG
                    foreach (DicomPage page in dicomImage.DicomPages)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");

                        // Ensure the directory for the output file exists
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
}