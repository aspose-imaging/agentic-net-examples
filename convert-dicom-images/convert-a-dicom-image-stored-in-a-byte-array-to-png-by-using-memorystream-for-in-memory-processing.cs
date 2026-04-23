using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM data into a byte array
            byte[] dicomData = File.ReadAllBytes(inputPath);

            // Use MemoryStream for in‑memory processing
            using (MemoryStream inputStream = new MemoryStream(dicomData))
            using (DicomImage dicomImage = new DicomImage(inputStream))
            using (FileStream outputStream = File.OpenWrite(outputPath))
            {
                // Define PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the entire image as PNG
                dicomImage.Save(outputStream, pngOptions, new Rectangle(0, 0, dicomImage.Width, dicomImage.Height));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}