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

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output BMP path
                string outputPath = Path.ChangeExtension(inputPath, ".bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Asynchronously process conversion
                await ConvertOtgToBmpAsync(inputPath, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertOtgToBmpAsync(string inputPath, string outputPath)
    {
        await Task.Run(() =>
        {
            // Load OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options for OTG
                var otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure BMP save options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Save as BMP
                image.Save(outputPath, bmpOptions);
            }
        });
    }
}