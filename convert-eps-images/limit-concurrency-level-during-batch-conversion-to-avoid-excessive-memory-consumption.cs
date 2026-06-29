using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directories (relative to current working directory)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Retrieve all files from the input directory
            string[] files = Directory.GetFiles(inputDirectory);

            // Limit concurrency to avoid high memory usage
            var parallelOptions = new System.Threading.Tasks.ParallelOptions { MaxDegreeOfParallelism = 4 };

            System.Threading.Tasks.Parallel.ForEach(files, parallelOptions, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (convert to PNG)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image and save it as PNG
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert thousands of JPEG or TIFF files to PNG in a C# backend service without running out of memory, they can use this parallel batch conversion with a limited MaxDegreeOfParallelism.
 * 2. When an automated image‑processing pipeline must resize and re‑encode a large photo archive on a limited‑resource VM, the code ensures only a safe number of images are loaded simultaneously.
 * 3. When a desktop utility has to generate PNG previews for a folder of mixed‑format graphics while keeping the UI responsive, limiting concurrency prevents excessive RAM usage.
 * 4. When a cloud function processes user‑uploaded images in batches and must stay within the allocated memory quota, the parallel options control how many images are handled at once.
 * 5. When a scheduled job migrates legacy BMP assets to modern PNG format on a shared server, the constrained parallel loop avoids overloading other applications running on the same machine.
 */