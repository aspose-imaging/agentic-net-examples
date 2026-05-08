using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and dummy output paths
            string inputPath = "c:\\temp\\sample.jpg";
            string outputPath = "c:\\temp\\output.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (required by the safety rules)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image using Aspose.Imaging
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Output image dimensions
                Console.WriteLine($"Width: {jpegImage.Width}");
                Console.WriteLine($"Height: {jpegImage.Height}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}