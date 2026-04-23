using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Save as PNG file
                var pngOptions = new PngOptions();
                dicomImage.Save(outputPath, pngOptions);

                // Also obtain PNG as a byte array
                using (var memoryStream = new MemoryStream())
                {
                    dicomImage.Save(memoryStream, pngOptions);
                    byte[] pngBytes = memoryStream.ToArray();
                    Console.WriteLine($"PNG byte array length: {pngBytes.Length}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}