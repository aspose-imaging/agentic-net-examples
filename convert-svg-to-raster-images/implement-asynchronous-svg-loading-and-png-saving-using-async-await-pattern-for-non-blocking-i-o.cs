using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point
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

            // Open the SVG file as an asynchronous stream
            await using (FileStream inputStream = new FileStream(
                inputPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 4096,
                useAsync: true))
            {
                // Load SVG image from the stream (constructor is synchronous)
                using (SvgImage svgImage = new SvgImage(inputStream))
                {
                    // Prepare rasterization and PNG save options
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        // Set desired dimensions; using original size if needed
                        PageSize = svgImage.Size
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Open the output file as an asynchronous stream
                    await using (FileStream outputStream = new FileStream(
                        outputPath,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None,
                        bufferSize: 4096,
                        useAsync: true))
                    {
                        // Perform the save operation on a background thread to avoid blocking
                        await Task.Run(() => svgImage.Save(outputStream, pngOptions));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}