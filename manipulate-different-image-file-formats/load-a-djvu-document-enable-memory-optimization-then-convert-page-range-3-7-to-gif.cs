using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Enable memory optimization via LoadOptions
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer
            };

            // Load DjVu document with memory optimization
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
            {
                // Convert pages 3‑7 to GIF
                for (int pageNum = 3; pageNum <= 7; pageNum++)
                {
                    DjvuPage targetPage = null;
                    foreach (DjvuPage page in djvuImage.DjvuPages)
                    {
                        if (page.PageNumber == pageNum)
                        {
                            targetPage = page;
                            break;
                        }
                    }

                    if (targetPage == null)
                    {
                        Console.Error.WriteLine($"Page {pageNum} not found.");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDir, $"page_{pageNum}.gif");
                    // Ensure directory exists for each output file
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as GIF
                    targetPage.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}