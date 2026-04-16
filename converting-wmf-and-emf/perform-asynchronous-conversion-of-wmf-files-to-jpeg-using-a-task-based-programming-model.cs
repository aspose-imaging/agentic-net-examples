using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous conversion of a single WMF file to JPEG.
    private static async Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        // Verify input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        string? outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? string.Empty);

        // Perform the load and save on a background thread to avoid blocking.
        await Task.Run(() =>
        {
            // Load the WMF image.
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options (default quality).
                var jpegOptions = new JpegOptions();

                // Save as JPEG to the specified path.
                image.Save(outputPath, jpegOptions);
            }
        });
    }

    // Entry point.
    static async Task Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\Output\sample.jpg";

        // Start the asynchronous conversion.
        await ConvertWmfToJpegAsync(inputPath, outputPath);
    }
}