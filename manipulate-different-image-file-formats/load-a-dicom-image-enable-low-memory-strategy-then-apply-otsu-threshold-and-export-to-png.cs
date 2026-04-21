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
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.BinarizeOtsu.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Open the DICOM file as a stream
        using (FileStream stream = File.OpenRead(inputPath))
        {
            // Configure low‑memory load options (e.g., 256 KB buffer)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 256 * 1024
            };

            // Load the DICOM image with the low‑memory strategy
            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

                // Save the processed image as PNG
                dicomImage.Save(outputPath, new PngOptions());
            }
        }
    }
}