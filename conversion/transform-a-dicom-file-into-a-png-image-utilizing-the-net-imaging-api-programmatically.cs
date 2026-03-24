using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input DICOM file path
        string inputPath = "sample.dcm";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DICOM file as a read‑only stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DICOM image from the stream
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Process each page in the DICOM file
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Construct an output PNG file name based on the page index
                    string outputFileName = $"sample.{dicomPage.Index}.png";
                    string outputPath = Path.Combine("output", outputFileName);

                    // Ensure the output directory exists (creates it if necessary)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as a PNG image
                    dicomPage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}