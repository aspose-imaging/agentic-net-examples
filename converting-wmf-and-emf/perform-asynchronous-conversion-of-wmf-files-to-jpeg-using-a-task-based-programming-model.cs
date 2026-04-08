using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Hardcoded input and output file paths
    private const string InputPath = @"C:\Images\sample.wmf";
    private const string OutputPath = @"C:\Images\Converted\sample.jpg";

    static void Main()
    {
        // Verify input file existence
        if (!File.Exists(InputPath))
        {
            Console.Error.WriteLine($"File not found: {InputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

        // Run the conversion asynchronously and wait for completion
        Task conversionTask = ConvertWmfToJpegAsync(InputPath, OutputPath);
        conversionTask.Wait();
    }

    // Asynchronous conversion using Task-based pattern
    private static async Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        await Task.Run(() =>
        {
            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options (default settings)
                var jpegOptions = new JpegOptions();

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}