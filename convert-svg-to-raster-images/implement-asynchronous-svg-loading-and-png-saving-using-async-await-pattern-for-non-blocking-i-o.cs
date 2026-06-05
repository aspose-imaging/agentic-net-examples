using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Asynchronously read SVG data
            byte[] svgData = await File.ReadAllBytesAsync(inputPath);

            // Load SVG from memory stream
            using var stream = new MemoryStream(svgData);
            using var svgImage = new SvgImage(stream);

            // Prepare rasterization and PNG save options
            var rasterOptions = new SvgRasterizationOptions();
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save PNG asynchronously (offload to background thread)
            await Task.Run(() => svgImage.Save(outputPath, pngOptions));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}