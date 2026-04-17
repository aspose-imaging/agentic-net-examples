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
            // Hardcoded input DICOM file path
            string inputPath = @"C:\temp\sample.dicom";

            // Hardcoded output directory
            string outputDirectory = @"C:\temp\output\";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DICOM file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DICOM image from the stream
                using (DicomImage dicomImage = new DicomImage(stream))
                {
                    // Iterate through each page in the DICOM image
                    foreach (DicomPage dicomPage in dicomImage.DicomPages)
                    {
                        // Build the output PNG file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{dicomPage.Index}.png");

                        // Ensure the output directory exists (creates it unconditionally)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a PNG image
                        dicomPage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
    }
}