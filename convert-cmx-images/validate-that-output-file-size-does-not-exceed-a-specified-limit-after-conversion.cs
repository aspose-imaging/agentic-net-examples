using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.jpg");
        string outputPath = Path.Combine("Output", "sample.tif");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define maximum allowed output file size (e.g., 5 MB)
        long maxSizeBytes = 5L * 1024 * 1024;

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
            }

            // Verify the output file size
            FileInfo outputInfo = new FileInfo(outputPath);
            if (outputInfo.Length > maxSizeBytes)
            {
                Console.Error.WriteLine($"Output file exceeds size limit: {outputInfo.Length} bytes (limit: {maxSizeBytes} bytes)");
            }
            else
            {
                Console.WriteLine($"Conversion successful. Output size: {outputInfo.Length} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}