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

        // Read DICOM data into a byte array
        byte[] dicomData = File.ReadAllBytes(inputPath);

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Process the DICOM image using a MemoryStream
        using (var memoryStream = new MemoryStream(dicomData))
        using (var dicomImage = new DicomImage(memoryStream))
        {
            // Prepare PNG save options
            var pngOptions = new PngOptions();

            // Define bounds covering the whole image
            var bounds = new Rectangle(0, 0, dicomImage.Width, dicomImage.Height);

            // Save the image to a PNG file stream
            using (var outputStream = File.OpenWrite(outputPath))
            {
                dicomImage.Save(outputStream, pngOptions, bounds);
            }
        }
    }
}