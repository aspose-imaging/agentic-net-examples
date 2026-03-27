using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu file and output directory
        string inputPath = "input.djvu";
        string outputDir = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional per requirement)
        Directory.CreateDirectory(outputDir);

        // Load DjVu document from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Process each page in parallel
                System.Threading.Tasks.Parallel.ForEach(djvuImage.Pages, page =>
                {
                    // Cast to DjvuPage to access PageNumber
                    var djvuPage = (Aspose.Imaging.FileFormats.Djvu.DjvuPage)page;

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{djvuPage.PageNumber}.png");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());
                });
            }
        }
    }
}