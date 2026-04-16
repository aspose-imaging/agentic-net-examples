using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.webp";
        string outputPath = "C:\\temp\\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Read the WebP image into a byte array
        byte[] imageData = File.ReadAllBytes(inputPath);

        // Load the image from the byte array using a MemoryStream
        using (MemoryStream ms = new MemoryStream(imageData))
        using (Image image = Image.Load(ms))
        {
            // Prepare PDF saving options
            var pdfOptions = new PdfOptions();

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}