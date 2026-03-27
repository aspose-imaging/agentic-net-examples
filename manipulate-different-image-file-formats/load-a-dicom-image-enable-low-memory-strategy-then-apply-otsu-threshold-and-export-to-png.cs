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

        // Load the DICOM image using a low‑memory strategy (small buffer size)
        using (FileStream stream = File.OpenRead(inputPath))
        {
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 256 * 1024 // 256 KB buffer
            };

            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

                // Save the result as PNG
                dicomImage.Save(outputPath, new PngOptions());
            }
        }
    }
}