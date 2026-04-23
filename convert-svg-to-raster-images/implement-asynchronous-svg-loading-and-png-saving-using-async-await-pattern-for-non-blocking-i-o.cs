using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Entry point
    static void Main()
    {
        // Run the async workflow synchronously
        MainAsync().GetAwaiter().GetResult();
    }

    // Asynchronous workflow
    private static async Task MainAsync()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG asynchronously
        using (SvgImage svgImage = await LoadSvgAsync(inputPath))
        {
            // Prepare rasterization and PNG save options
            var rasterizationOptions = new SvgRasterizationOptions();
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save PNG asynchronously
            await SavePngAsync(svgImage, outputPath, pngOptions);
        }
    }

    // Asynchronously reads the SVG file into a stream and creates an SvgImage
    private static async Task<SvgImage> LoadSvgAsync(string path)
    {
        // Open the file with asynchronous I/O enabled
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
        {
            // Read all bytes asynchronously
            byte[] buffer = new byte[fs.Length];
            int bytesRead = 0;
            while (bytesRead < buffer.Length)
            {
                int read = await fs.ReadAsync(buffer, bytesRead, buffer.Length - bytesRead);
                if (read == 0) break;
                bytesRead += read;
            }

            // Create a memory stream from the read bytes
            MemoryStream ms = new MemoryStream(buffer, writable: false);
            // SvgImage constructor expects a Stream; wrap in using later by caller
            return new SvgImage(ms);
        }
    }

    // Asynchronously saves the SvgImage as PNG using the provided options
    private static async Task SavePngAsync(SvgImage svgImage, string outputPath, PngOptions options)
    {
        // The Save method is synchronous; offload to a background thread to avoid blocking
        await Task.Run(() => svgImage.Save(outputPath, options));
    }
}