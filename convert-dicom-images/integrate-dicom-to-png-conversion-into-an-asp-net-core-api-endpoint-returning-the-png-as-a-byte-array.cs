using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
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

        byte[] pngBytes;

        // Load DICOM image and convert to PNG in memory
        using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
        {
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions();
                dicom.Save(memoryStream, pngOptions);
                pngBytes = memoryStream.ToArray();
            }

            // Optionally save the PNG to a file
            using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(pngBytes, 0, pngBytes.Length);
            }
        }

        // Output the size of the resulting PNG byte array
        Console.WriteLine($"Converted PNG byte array length: {pngBytes.Length}");
    }
}