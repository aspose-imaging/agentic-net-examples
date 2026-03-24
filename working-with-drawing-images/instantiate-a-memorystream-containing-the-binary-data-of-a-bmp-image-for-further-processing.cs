using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP file into a byte array and wrap it in a MemoryStream
        byte[] bmpData = File.ReadAllBytes(inputPath);
        using (MemoryStream memoryStream = new MemoryStream(bmpData))
        {
            // Create a BmpImage from the MemoryStream
            using (BmpImage bmpImage = new BmpImage(memoryStream))
            {
                // Example processing (optional)
                // bmpImage.BinarizeOtsu();

                // Save the processed image to the output path
                bmpImage.Save(outputPath);
            }
        }
    }
}