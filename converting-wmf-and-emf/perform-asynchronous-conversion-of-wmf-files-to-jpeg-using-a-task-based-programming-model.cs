using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous conversion of a WMF file to JPEG.
    static async Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        // Verify input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Perform the load and save on a background thread.
        await Task.Run(() =>
        {
            // Load the WMF image.
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options (default settings are sufficient for basic conversion).
                var jpegOptions = new JpegOptions();

                // Save the image as JPEG.
                image.Save(outputPath, jpegOptions);
            }
        });
    }

    // Entry point with hard‑coded paths.
    static async Task Main()
    {
        // Hard‑coded input and output file paths.
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.jpg";

        // Start the asynchronous conversion.
        await ConvertWmfToJpegAsync(inputPath, outputPath);
    }
}