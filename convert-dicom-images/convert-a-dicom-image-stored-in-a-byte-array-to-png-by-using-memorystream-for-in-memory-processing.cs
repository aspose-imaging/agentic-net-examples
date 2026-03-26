using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM file into a byte array
        byte[] dicomBytes = File.ReadAllBytes(inputPath);

        // Use a MemoryStream for in‑memory processing
        using (var inputStream = new MemoryStream(dicomBytes))
        {
            // Create a DicomImage from the stream
            using (var dicomImage = new DicomImage(inputStream))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the first page (or only page) as PNG
                // If the DICOM contains multiple pages, iterate over dicomImage.DicomPages
                var firstPage = dicomImage.DicomPages[0];
                firstPage.Save(outputPath, pngOptions);
            }
        }
    }
}