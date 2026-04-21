using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Input and output paths (relative)
        string inputPath = "Input/sample.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "Output/animation.gif";
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document
        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            // Set up GIF options with page range 1‑3
            var gifOptions = new GifOptions
            {
                MultiPageOptions = new DjvuMultiPageOptions(new IntRange(1, 3))
            };

            // Save as animated GIF
            djvu.Save(outputPath, gifOptions);
        }
    }
}