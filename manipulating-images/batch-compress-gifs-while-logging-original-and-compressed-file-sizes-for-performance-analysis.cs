using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all GIF files from the input folder
            string[] gifFiles = Directory.GetFiles(inputFolder, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Log original file size
                long originalSize = new FileInfo(inputPath).Length;

                // Load the GIF, apply lossy compression, and save
                using (Image image = Image.Load(inputPath))
                {
                    GifOptions saveOptions = new GifOptions
                    {
                        // Recommended lossy compression level
                        MaxDiff = 80
                    };

                    image.Save(outputPath, saveOptions);
                }

                // Log compressed file size
                long compressedSize = new FileInfo(outputPath).Length;

                Console.WriteLine($"Processed: {fileName}");
                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Compressed size: {compressedSize} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to reduce the bandwidth of animated GIFs for a website’s image gallery, they can batch compress the files with Aspose.Imaging and record original versus compressed sizes to verify savings.
 * 2. When a marketing team prepares email newsletters containing multiple GIFs, a C# script can automatically shrink each GIF and log size differences to ensure the email stays under size limits.
 * 3. When a mobile app developer wants to bundle optimized GIF assets for faster app startup, they can use this code to compress all GIFs in a folder and track size reductions for performance reporting.
 * 4. When a DevOps engineer is setting up a CI/CD pipeline that optimizes static assets before deployment, they can integrate this batch compression routine to compress GIFs and output size metrics for monitoring.
 * 5. When an archivist needs to store large collections of animated GIFs more efficiently, they can run this program to apply lossy compression and log the before‑and‑after file sizes to assess storage savings.
 */