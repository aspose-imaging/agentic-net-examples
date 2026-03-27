using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point – async Main is supported in C# 7.1+
    static async Task Main()
    {
        // Hard‑coded list of OTG files to process
        string[] inputFiles = new[]
        {
            @"C:\Images\Input1.otg",
            @"C:\Images\Input2.otg",
            @"C:\Images\Input3.otg"
        };

        // Process each file sequentially (can be changed to parallel if needed)
        foreach (string inputPath in inputFiles)
        {
            // Build output path with .bmp extension in the same folder
            string outputPath = Path.ChangeExtension(inputPath, ".bmp");

            // Perform conversion
            await ConvertOtgToBmpAsync(inputPath, outputPath);
        }
    }

    // Asynchronous conversion of a single OTG file to BMP
    private static async Task ConvertOtgToBmpAsync(string inputPath, string outputPath)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (creates even if null – safe for root paths)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image on a background thread (Aspose.Imaging API is synchronous)
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Prepare rasterization options for vector to raster conversion
            var otgRasterOptions = new OtgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size
            };

            // Configure BMP save options and attach rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save the image as BMP on a background thread
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }

        Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
    }
}