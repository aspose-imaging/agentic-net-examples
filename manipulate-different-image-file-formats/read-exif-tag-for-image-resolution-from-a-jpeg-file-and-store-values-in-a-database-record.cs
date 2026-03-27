using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG file path
        string inputPath = "Input/sample.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output file path (simulating a database record)
        string outputPath = "Output/resolution.txt";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image and access its EXIF resolution tags
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            double horizontalResolution = image.HorizontalResolution;
            double verticalResolution = image.VerticalResolution;

            // Create a simple record string
            string record = $"HorizontalResolution={horizontalResolution},VerticalResolution={verticalResolution}";

            // Write the record to the output file
            File.WriteAllText(outputPath, record);
        }
    }
}