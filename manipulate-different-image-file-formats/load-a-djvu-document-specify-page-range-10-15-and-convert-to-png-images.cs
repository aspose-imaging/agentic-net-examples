using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputDir = @"C:\Temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load DjVu image
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through pages and process pages 10‑15
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    int pageNumber = page.PageNumber;
                    if (pageNumber < 10 || pageNumber > 15)
                        continue;

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"page_{pageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}