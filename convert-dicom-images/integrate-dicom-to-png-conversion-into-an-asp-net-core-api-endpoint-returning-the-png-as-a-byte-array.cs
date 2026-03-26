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
        // Hardcoded input DICOM file path
        string inputPath = @"C:\temp\sample.dcm";
        // Hardcoded output PNG file path
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Get the first page (or you could iterate all pages)
            DicomPage page = dicomImage.DicomPages[0];

            // Convert page to PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                page.Save(ms, pngOptions);
                byte[] pngBytes = ms.ToArray();

                // Write PNG bytes to output file
                File.WriteAllBytes(outputPath, pngBytes);

                // Output length of byte array
                Console.WriteLine($"PNG byte array length: {pngBytes.Length}");
            }
        }
    }
}