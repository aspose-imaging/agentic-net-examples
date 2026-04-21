using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous conversion of a single OTG file to BMP
    private static async Task ConvertOtgToBmpAsync(string inputPath, string outputPath)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image without blocking the calling thread
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Prepare BMP save options with OTG rasterization settings
            var bmpOptions = new BmpOptions();

            var otgRaster = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = image.Size
            };
            bmpOptions.VectorRasterizationOptions = otgRaster;

            // Save the image as BMP without blocking the calling thread
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }
    }

    // Entry point
    static async Task Main()
    {
        // Hard‑coded input and output directories
        string inputDir = @"C:\InputOtg";
        string outputDir = @"C:\OutputBmp";

        // List of OTG files to process (hard‑coded)
        string[] otgFiles = { "sample1.otg", "sample2.otg", "sample3.otg" };

        foreach (var fileName in otgFiles)
        {
            string inputPath = Path.Combine(inputDir, fileName);
            string outputFileName = Path.ChangeExtension(fileName, ".bmp");
            string outputPath = Path.Combine(outputDir, outputFileName);

            await ConvertOtgToBmpAsync(inputPath, outputPath);
        }
    }
}