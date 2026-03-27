using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/animation.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Prepare GIF save options with page range 1‑3 (zero‑based indexes 0,1,2)
            using (GifOptions gifOptions = new GifOptions())
            {
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 0, 1, 2 });
                // Save as animated GIF
                djvuImage.Save(outputPath, gifOptions);
            }
        }
    }
}