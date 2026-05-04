using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input OTG files
            string[] inputFiles = new[]
            {
                @"C:\Images\Input1.otg",
                @"C:\Images\Input2.otg"
            };

            // Process each file asynchronously
            Task[] tasks = new Task[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                tasks[i] = ProcessFileAsync(inputPath);
            }

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ProcessFileAsync(string inputPath)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Determine output BMP path
        string outputPath = Path.ChangeExtension(inputPath, ".bmp");

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image asynchronously
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Configure rasterization options
            var otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the image as BMP asynchronously
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }
    }
}