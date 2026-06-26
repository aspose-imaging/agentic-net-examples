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
        // Run the blocking I/O in a background thread to keep UI responsive
        await Task.Run(() =>
        {
            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Prepare JPEG save options (default settings)
                var jpegOptions = new JpegOptions();

                // Ensure the output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as JPEG
                cmxImage.Save(outputPath, jpegOptions);
            }
        });
    }

    // Entry point
    static async Task Main()
    {
        // Hard‑coded input and output paths
        const string inputPath = @"c:\temp\sample.cmx";
        const string outputPath = @"c:\temp\output.jpg";

        try
        {
            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists before any save operation
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform the conversion asynchronously
            await ConvertCmxToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Windows Forms or WPF application needs to display a preview of a CorelDRAW CMX file without freezing the UI, a developer can use this async conversion to JPEG.
 * 2. When a web service processes user‑uploaded CMX drawings and must generate JPEG thumbnails while keeping the request thread responsive, this code provides a non‑blocking solution.
 * 3. When a batch‑processing tool runs on a background worker thread to convert large numbers of CMX files to JPEG for archival, the async pattern prevents the main thread from being blocked.
 * 4. When an automated report generator embeds CMX artwork as JPEG images in PDF or HTML output, developers can call the async method to convert on‑the‑fly without slowing down the UI.
 * 5. When a mobile or tablet .NET MAUI app allows users to open CMX files and share them as JPEGs, the asynchronous conversion ensures smooth interaction on low‑power devices.
 */