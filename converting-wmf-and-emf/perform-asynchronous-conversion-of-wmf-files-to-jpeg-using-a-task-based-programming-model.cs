using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous conversion of a single WMF file to JPEG
    private static Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        return Task.Run(() =>
        {
            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options (default settings)
                var jpegOptions = new JpegOptions();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        });
    }

    static async Task Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\sample.jpg";

        try
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Perform the conversion asynchronously
            await ConvertWmfToJpegAsync(inputPath, outputPath);
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
 * 1. When a desktop application needs to batch‑convert user‑uploaded WMF vector graphics to JPEG thumbnails without blocking the UI thread, developers can use this asynchronous Task‑based code.
 * 2. When a web service processes incoming WMF reports and must generate JPEG previews for email attachments while keeping the request thread responsive, this pattern applies.
 * 3. When an automated build pipeline converts legacy WMF icons to JPEG assets for mobile apps, the async conversion ensures the pipeline runs efficiently.
 * 4. When a Windows service monitors a folder of WMF files and saves them as JPEGs for archival storage, the code provides non‑blocking file I/O and image saving.
 * 5. When a cloud‑based image processing microservice receives WMF files via API and needs to return JPEG responses without tying up server threads, developers can employ this async conversion approach.
 */