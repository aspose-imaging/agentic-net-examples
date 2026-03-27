using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Define input and output directories (relative to the current directory)
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Get all DjVu files in the input directory
        string[] djvuFiles = Directory.GetFiles(inputDirectory, "*.djvu");

        foreach (string inputPath in djvuFiles)
        {
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

            // Load DjVu with memory strategy (buffer size hint)
            using (FileStream stream = File.OpenRead(inputPath))
            {
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer
                };

                using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
                {
                    // Set GIF options with interlacing and export all pages
                    using (GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true,
                        MultiPageOptions = new DjvuMultiPageOptions()
                    })
                    {
                        // Save DjVu as GIF
                        djvuImage.Save(outputPath, gifOptions);
                    }
                }
            }
        }
    }
}