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
            // Directory setup
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

            foreach (string inputPath in files)
            {
                // Process only DjVu files
                if (!inputPath.EndsWith(".djvu", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DjVu with memory buffer hint
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    var loadOptions = new LoadOptions { BufferSizeHint = 1 * 1024 * 1024 };
                    using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
                    {
                        int pageIndex = 0;
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(inputPath);
                            string outputPath = Path.Combine(outputDirectory, $"{baseName}_page{pageIndex}.gif");

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            var gifOptions = new GifOptions { Interlaced = true };
                            page.Save(outputPath, gifOptions);
                            pageIndex++;
                        }
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