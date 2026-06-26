using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.svg";
            string outputPath = "C:\\temp\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open SVG file as an async stream and load it
            using (FileStream svgStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true))
            using (SvgImage svgImage = await LoadSvgAsync(svgStream))
            {
                // Configure rasterization options for PNG output
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized PNG asynchronously
                await SavePngAsync(svgImage, outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Wrap synchronous SvgImage constructor in a Task to avoid blocking
    private static Task<SvgImage> LoadSvgAsync(Stream stream)
    {
        return Task.Run(() => new SvgImage(stream));
    }

    // Wrap synchronous Save method in a Task to avoid blocking
    private static Task SavePngAsync(SvgImage image, string path, PngOptions options)
    {
        return Task.Run(() => image.Save(path, options));
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web service needs to convert user‑uploaded SVG icons to PNG thumbnails without blocking the request thread, developers can use this async loading and saving pattern.
 * 2. When a desktop application processes large batches of vector graphics overnight and wants to keep the UI responsive, the asynchronous SVG‑to‑PNG conversion helps avoid UI freezes.
 * 3. When a cloud function generates PNG previews of SVG diagrams on demand and must scale under high concurrency, the async/await approach ensures non‑blocking I/O.
 * 4. When an automated build pipeline includes image assets conversion and needs to run in parallel with other tasks, the async SVG loading and PNG saving reduces overall build time.
 * 5. When a mobile backend service streams SVG files from storage, rasterizes them to PNG, and writes the result back to a CDN, using asynchronous streams prevents thread starvation.
 */