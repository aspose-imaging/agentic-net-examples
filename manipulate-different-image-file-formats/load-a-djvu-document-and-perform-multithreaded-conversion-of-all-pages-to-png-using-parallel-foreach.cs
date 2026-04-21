using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu file and output folder
        string inputPath = "sample.djvu";
        string outputFolder = "Output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Load DjVu document
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Get all pages as DjvuPage objects
            var pages = djvuImage.Pages.Cast<DjvuPage>().ToArray();

            // Convert each page to PNG in parallel
            Parallel.ForEach(pages, page =>
            {
                string outputPath = Path.Combine(outputFolder, $"page_{page.PageNumber}.png");
                // Ensure directory for each output file (safety)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                page.Save(outputPath, new PngOptions());
            });
        }
    }
}