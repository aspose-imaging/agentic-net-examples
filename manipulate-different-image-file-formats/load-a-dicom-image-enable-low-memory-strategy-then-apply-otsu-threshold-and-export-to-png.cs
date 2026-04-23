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
            string inputPath = "c:\\temp\\sample.dicom";
            string outputPath = "c:\\temp\\sample.BinarizeOtsu.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the DICOM file with a low‑memory load option
            using (FileStream stream = File.OpenRead(inputPath))
            {
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB buffer size hint
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}