using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/animation.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure GIF options with page range 1‑3 (inclusive)
                GifOptions gifOptions = new GifOptions();
                // DjvuMultiPageOptions uses zero‑based indexing; pages 1‑3 correspond to indexes 0‑2
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(0, 2));

                // Save selected pages as an animated GIF
                djvuImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}