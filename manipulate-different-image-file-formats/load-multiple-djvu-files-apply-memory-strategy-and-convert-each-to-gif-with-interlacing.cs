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
            // Set up input and output directories
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

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path and ensure its directory exists
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu with memory buffer hint
                using (var stream = File.OpenRead(inputPath))
                {
                    var loadOptions = new LoadOptions
                    {
                        BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer
                    };

                    using (var djvu = new DjvuImage(stream, loadOptions))
                    {
                        // Configure GIF options with interlacing and export all pages
                        var gifOptions = new GifOptions
                        {
                            Interlaced = true,
                            MultiPageOptions = new DjvuMultiPageOptions()
                        };

                        // Save as GIF
                        djvu.Save(outputPath, gifOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}