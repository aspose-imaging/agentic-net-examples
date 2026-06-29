using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Asynchronous conversion of a single ODG file to BMP
    private static async Task ConvertOdgToBmpAsync(string inputPath, string outputPath)
    {
        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image asynchronously
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Prepare BMP save options
            var bmpOptions = new BmpOptions();

            // Save the image as BMP asynchronously
            await Task.Run(() => image.Save(outputPath, bmpOptions));
        }
    }

    // Entry point
    static async Task Main()
    {
        try
        {
            // Hard‑coded list of ODG files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\Input\sample1.odg",
                @"C:\Images\Input\sample2.odg",
                @"C:\Images\Input\sample3.odg"
            };

            // Process each file concurrently
            var tasks = new Task[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = Path.ChangeExtension(inputPath, ".bmp");
                tasks[i] = ConvertOdgToBmpAsync(inputPath, outputPath);
            }

            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application must convert a large collection of OpenDocument Graphics (ODG) drawings to BMP thumbnails without freezing the UI, developers can use this async batch conversion code.
 * 2. When a server‑side image‑processing service needs to ingest user‑uploaded ODG files and store them as BMPs for downstream raster‑based analysis, the asynchronous pattern keeps I/O non‑blocking.
 * 3. When an automated build pipeline generates documentation assets and must transform ODG diagrams into BMP images for inclusion in PDF reports, the code enables parallel conversion to speed up the pipeline.
 * 4. When a cloud‑based microservice processes batch jobs that convert ODG charts to BMP format for legacy systems that only accept BMP, the async/await approach maximizes throughput while conserving threads.
 * 5. When a Windows service monitors a folder for new ODG files and needs to export them as BMP files for a printing workflow, the asynchronous batch conversion ensures continuous processing without blocking other file‑system operations.
 */