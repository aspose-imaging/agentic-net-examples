using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    // Asynchronous conversion from CMX to JPEG
    private static async Task ConvertCmxToJpegAsync(string inputPath, string outputPath)
    {
        // Run the blocking I/O operations on a background thread
        await Task.Run(() =>
        {
            // Load the CMX image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Prepare JPEG save options (default settings)
                var jpegOptions = new JpegOptions();

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }

    // Entry point
    static async Task Main()
    {
        // Hard‑coded paths
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

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

            // Perform the asynchronous conversion
            await ConvertCmxToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Windows Forms or WPF application needs to let users open legacy CorelDRAW CMX files and display them as JPEG thumbnails without freezing the UI.
 * 2. When a web API receives batch uploads of CMX drawings and must convert them to JPEG for preview generation while keeping the request thread responsive using async/await.
 * 3. When an automated document management system imports CMX artwork and stores JPEG versions for quick indexing, employing asynchronous conversion to avoid blocking background workers.
 * 4. When a .NET MAUI mobile app allows users to select CMX files from device storage and convert them to JPEG for sharing, requiring non‑blocking conversion to keep the UI smooth.
 * 5. When a cloud‑based image processing pipeline needs to convert CMX to JPEG on demand and runs the conversion on a background thread to improve scalability and responsiveness.
 */