using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Maximum allowed output file size in bytes (e.g., 5 MB)
        const long maxOutputSizeBytes = 5 * 1024 * 1024;

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
            // Prepare PNG save options (default options are sufficient for this example)
            PngOptions saveOptions = new PngOptions();

            // Save the image to the output path
            image.Save(outputPath, saveOptions);
        }

        // Validate output file size does not exceed the limit
        FileInfo outInfo = new FileInfo(outputPath);
        if (outInfo.Length > maxOutputSizeBytes)
        {
            Console.Error.WriteLine($"Output file exceeds size limit: {outputPath} ({outInfo.Length} > {maxOutputSizeBytes} bytes)");
        }
        else
        {
            Console.WriteLine($"Conversion successful. Output size: {outInfo.Length} bytes");
        }
    }
}