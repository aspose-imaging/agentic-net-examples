using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of WMF files to convert.
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.wmf",
                @"C:\Images\sample2.wmf",
                @"C:\Images\sample3.wmf"
            };

            // Process each file in parallel.
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output JPEG path.
                string outputPath = Path.ChangeExtension(inputPath, ".jpg");

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WMF image and save it as JPEG.
                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        // Optional: set quality (0‑100). Default is 90.
                        Quality = 90
                    };

                    image.Save(outputPath, jpegOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a large collection of legacy WMF vector drawings into web‑friendly JPEG thumbnails quickly, they can use this parallel conversion code.
 * 2. When an automated build or CI pipeline must generate JPEG previews of WMF assets for documentation or UI mockups, the Parallel.ForEach loop speeds up processing.
 * 3. When a desktop application imports user‑provided WMF files and must store them as compressed JPEGs for faster loading and reduced disk usage, this code handles the conversion in parallel.
 * 4. When a server‑side service processes incoming WMF uploads and needs to deliver JPEG versions to browsers or mobile clients, the parallel approach minimizes response time.
 * 5. When a migration script moves legacy WMF graphics from an old file system to a new media library that only supports JPEG, the code provides a thread‑safe, high‑performance conversion method.
 */