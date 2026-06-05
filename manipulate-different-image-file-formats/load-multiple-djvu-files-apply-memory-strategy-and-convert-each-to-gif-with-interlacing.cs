using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input/Output directory setup (batch processing block)
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            // Process each DjVu file
            foreach (string inputPath in files)
            {
                // Process only .djvu files
                if (!string.Equals(Path.GetExtension(inputPath), ".djvu", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu with memory buffer hint (e.g., 1 MB)
                var loadOptions = new LoadOptions { BufferSizeHint = 1 * 1024 * 1024 };
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvu = new DjvuImage(stream, loadOptions))
                using (GifOptions gifOptions = new GifOptions { Interlaced = true })
                {
                    // Save as interlaced GIF
                    djvu.Save(outputPath, gifOptions);
                }
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
 * 1. When a digital archive needs to batch‑convert scanned DjVu documents into web‑friendly interlaced GIFs while controlling memory usage, a developer can use this code.
 * 2. When an e‑learning platform must generate animated GIF previews of multi‑page DjVu lecture notes on a server with limited RAM, the example shows how to load each file with a buffer hint and save it as an interlaced GIF.
 * 3. When a publishing workflow requires automated conversion of DjVu illustrations into GIFs for inclusion in HTML newsletters, the code provides a C# solution that processes all files in an input folder and applies a memory‑efficient load strategy.
 * 4. When a mobile‑backend service needs to transform user‑uploaded DjVu comics into interlaced GIFs for faster streaming on low‑bandwidth connections, this snippet demonstrates batch processing with explicit buffer sizing.
 * 5. When a legal‑document management system must archive DjVu case files as GIF images with interlacing to preserve visual fidelity while minimizing memory consumption during conversion, the sample code fulfills that requirement.
 */