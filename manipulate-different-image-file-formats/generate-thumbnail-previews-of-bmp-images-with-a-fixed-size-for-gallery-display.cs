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
            // Define base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Process only BMP files
                if (!string.Equals(Path.GetExtension(inputPath), ".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Prepare output path for the thumbnail
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + "_thumb.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, and save the thumbnail
                using (Image image = Image.Load(inputPath))
                {
                    const int thumbWidth = 150;
                    const int thumbHeight = 150;
                    image.Resize(thumbWidth, thumbHeight);
                    BmpOptions options = new BmpOptions();
                    image.Save(outputPath, options);
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
 * 1. When building a desktop photo management app that shows a grid of BMP pictures, a developer can use this code to create uniform thumbnail previews for fast loading in the gallery view.
 * 2. When an e‑commerce platform stores product schematics as BMP files and needs to display small preview icons on category pages, this snippet generates consistent thumbnail images on the server side using Aspose.Imaging for .NET.
 * 3. When automating a batch process that converts scanned BMP documents into thumbnail versions for a web‑based document library, the code resizes each file and saves it with a “_thumb” suffix for easy retrieval.
 * 4. When integrating a Windows Forms application with a file‑explorer style UI, developers can call this routine to pre‑generate BMP thumbnails so the UI can render them instantly without loading the full‑size images.
 * 5. When creating a content‑management workflow that archives BMP assets and needs low‑resolution previews for editorial review, the example produces fixed‑size thumbnail files that can be embedded in HTML or email summaries.
 */