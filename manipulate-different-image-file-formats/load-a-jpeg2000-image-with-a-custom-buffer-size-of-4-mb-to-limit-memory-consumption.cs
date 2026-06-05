using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch any unexpected exceptions
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.jp2";
            string outputPath = @"C:\Images\sample.output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set a memory limit of 4 MB for internal buffers while loading
            var loadOptions = new LoadOptions { BufferSizeHint = 4 };

            // Load the JPEG2000 image with the specified load options
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Save the loaded image as PNG
                image.Save(outputPath, new PngOptions());
            }
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
 * 1. When processing large JPEG2000 satellite imagery on a server with limited RAM, a developer can use this code to load the image with a 4 MB buffer to prevent out‑of‑memory errors while converting it to PNG.
 * 2. When building a desktop application that batch‑converts high‑resolution medical scans from JPEG2000 to PNG on low‑end workstations, the custom buffer size helps keep the app responsive.
 * 3. When integrating an image‑upload service that must validate and re‑encode user‑submitted JPEG2000 files in a cloud function with strict memory quotas, this approach limits the memory footprint during loading.
 * 4. When creating an automated archival workflow that extracts thumbnails from JPEG2000 photographs on a legacy system with 2 GB RAM, setting BufferSizeHint to 4 MB ensures the process stays within available memory.
 * 5. When developing a C# microservice that streams JPEG2000 images from a network share and saves them as PNG without loading the entire file into memory, the custom buffer size reduces peak memory usage.
 */