// HOW-TO: Asynchronously Convert WMF Files to JPEG Using Task in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform asynchronous conversion
            await ConvertWmfToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        return Task.Run(() =>
        {
            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG options with vector rasterization
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert legacy WMF vector graphics to JPEG thumbnails in a desktop C# application without blocking the UI.
 * 2. When a server‑side service must process uploaded WMF diagrams and store them as JPEGs while handling multiple requests concurrently.
 * 3. When you want to generate JPEG previews of WMF files in a background task to keep a responsive ASP.NET Core web API.
 * 4. When automating a batch job that reads WMF assets from a folder and asynchronously saves them as JPEGs to improve throughput.
 * 5. When integrating Aspose.Imaging into a C# workflow that requires non‑blocking conversion of vector WMF images to raster JPEG format for further processing or display.
 */
