using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded collection of JPEG2000 source files
            List<string> inputFiles = new List<string>
            {
                @"C:\Images\input1.jp2",
                @"C:\Images\input2.jp2",
                @"C:\Images\input3.jp2"
                // Add more paths as needed
            };

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output path (same folder, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure load options with a memory buffer limit (e.g., 50 MB)
                var loadOptions = new Jpeg2000LoadOptions
                {
                    BufferSizeHint = 50 // limit internal buffers to 50 MB
                };

                // Load the JPEG2000 image and save as PNG
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to batch‑convert a large set of JPEG2000 (.jp2) medical images to PNG for web preview while keeping memory usage low.
 * 2. When an imaging pipeline must process thousands of high‑resolution satellite JPEG2000 files in parallel on a server and avoid out‑of‑memory crashes.
 * 3. When a desktop application has to generate thumbnail PNGs from user‑uploaded JPEG2000 photos without loading the entire image into RAM.
 * 4. When an automated archival system has to migrate legacy JPEG2000 assets to a more widely supported PNG format while running on limited‑memory virtual machines.
 * 5. When a cloud‑based image service needs to handle concurrent JPEG2000 to PNG conversions with a configurable buffer size to stay within container memory limits.
 */