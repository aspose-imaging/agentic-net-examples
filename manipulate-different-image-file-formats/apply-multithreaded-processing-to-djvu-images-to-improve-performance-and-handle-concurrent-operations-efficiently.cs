using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load DjVu image from the stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Get pages collection
                var pages = djvuImage.Pages;

                // Process each page in parallel
                Parallel.ForEach(pages, djvuPageObj =>
                {
                    // Cast to DjvuPage to access PageNumber
                    var djvuPage = (DjvuPage)djvuPageObj;

                    // Build output file path for this page
                    string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                    // Ensure directory for this file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());
                });
            }
        }
    }
}