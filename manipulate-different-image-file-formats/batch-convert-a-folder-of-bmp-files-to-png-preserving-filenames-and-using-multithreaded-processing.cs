using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all BMP files in the input folder (non-recursive)
            var bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            // Process files in parallel
            Parallel.ForEach(bmpFiles, bmpPath =>
            {
                // Verify input file exists
                if (!File.Exists(bmpPath))
                {
                    Console.Error.WriteLine($"File not found: {bmpPath}");
                    return;
                }

                // Determine output file path with .png extension
                string fileName = Path.GetFileNameWithoutExtension(bmpPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(bmpPath))
                {
                    // Save as PNG using default options
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
 * 1. When a developer needs to migrate a legacy collection of BMP assets to web‑friendly PNG files while keeping the original filenames, this multithreaded Aspose.Imaging C# code can perform the batch conversion quickly.
 * 2. When an automated build pipeline must generate optimized PNG thumbnails from BMP source images for a mobile app, the parallel processing in the example speeds up the conversion step.
 * 3. When a Windows service processes scanned BMP documents nightly and saves them as lossless PNGs for archival, the code ensures each file is converted and stored in the correct output folder.
 * 4. When a content management system imports bulk BMP graphics and requires them to be stored as PNG to reduce storage costs, the sample demonstrates how to handle the conversion concurrently.
 * 5. When a developer creates a command‑line utility that converts user‑selected BMP folders to PNG for cross‑platform compatibility, this snippet shows the necessary file‑system checks and thread‑safe image handling.
 */