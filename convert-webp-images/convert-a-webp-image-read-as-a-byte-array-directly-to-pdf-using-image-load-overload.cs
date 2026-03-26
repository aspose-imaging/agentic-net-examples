using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Read the WebP image into a byte array
        byte[] imageData = File.ReadAllBytes(inputPath);

        // Load the image from the byte array using a memory stream
        using (var memoryStream = new MemoryStream(imageData))
        using (var image = Image.Load(memoryStream))
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the image as PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}