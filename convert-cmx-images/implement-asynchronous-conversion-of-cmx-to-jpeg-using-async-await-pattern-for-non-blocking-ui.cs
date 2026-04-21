using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    // Async entry point
    static async Task Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.cmx";
        string outputPath = @"c:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Perform conversion asynchronously
        await ConvertCmxToJpegAsync(inputPath, outputPath);
    }

    // Asynchronous conversion method
    private static async Task ConvertCmxToJpegAsync(string inputPath, string outputPath)
    {
        // Load CMX image on a background thread
        using (CmxImage cmxImage = await Task.Run(() => (CmxImage)Image.Load(inputPath)))
        {
            // Prepare JPEG save options (default options are sufficient for basic conversion)
            var jpegOptions = new JpegOptions();

            // Save JPEG image on a background thread
            await Task.Run(() => cmxImage.Save(outputPath, jpegOptions));
        }
    }
}