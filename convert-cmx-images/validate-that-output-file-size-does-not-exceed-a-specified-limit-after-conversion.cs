using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        const string inputPath = @"C:\temp\input.jpg";
        const string outputPath = @"C:\temp\output.png";

        // Maximum allowed output file size (bytes)
        const long maxOutputSizeBytes = 5 * 1024 * 1024; // 5 MB

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Define save options (PNG in this example)
            PngOptions saveOptions = new PngOptions();

            // Save the image to the output path
            image.Save(outputPath, saveOptions);
        }

        // Validate output file size
        FileInfo outInfo = new FileInfo(outputPath);
        if (outInfo.Length > maxOutputSizeBytes)
        {
            Console.Error.WriteLine($"Output file size exceeds limit: {outInfo.Length} bytes (limit: {maxOutputSizeBytes} bytes)");
        }
        else
        {
            Console.WriteLine($"Conversion successful. Output size: {outInfo.Length} bytes");
        }
    }
}