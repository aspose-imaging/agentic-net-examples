using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Input DjVu file path (first argument) or default.
        string inputPath = args.Length > 0 ? args[0] : "sample.djvu";

        // Output directory (second argument) or default.
        string outputDir = args.Length > 1 ? args[1] : "output";

        // Ensure the output directory exists.
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the DjVu image.
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            int pageCount = djvuImage.PageCount;

            // Process each page in parallel.
            System.Threading.Tasks.Parallel.For(0, pageCount, i =>
            {
                // Access the page.
                var page = djvuImage.Pages[i];

                // Build output file name.
                string outPath = Path.Combine(outputDir, $"page_{i + 1}.png");

                // Save the page as PNG.
                page.Save(outPath, new PngOptions());
            });
        }
    }
}