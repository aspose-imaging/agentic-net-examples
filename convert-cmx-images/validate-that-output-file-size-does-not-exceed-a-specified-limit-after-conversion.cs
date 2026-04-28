using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    // Hardcoded paths
    private const string InputPath = @"C:\input\sample.jpg";
    private const string OutputPath = @"C:\output\sample_converted.png";

    // Maximum allowed output file size (bytes)
    private const long MaxOutputSizeBytes = 5 * 1024 * 1024; // 5 MB

    static void Main()
    {
        try
        {
            // Verify input file exists
            if (!File.Exists(InputPath))
            {
                Console.Error.WriteLine($"File not found: {InputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

            // Load the image with an optional memory buffer hint
            using (Image image = Image.Load(InputPath, new LoadOptions { BufferSizeHint = 50 }))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Save the image to the output path
                image.Save(OutputPath, pngOptions);
            }

            // Validate output file size
            var outputInfo = new FileInfo(OutputPath);
            if (outputInfo.Length > MaxOutputSizeBytes)
            {
                Console.Error.WriteLine($"Output file size {outputInfo.Length} exceeds limit of {MaxOutputSizeBytes} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}