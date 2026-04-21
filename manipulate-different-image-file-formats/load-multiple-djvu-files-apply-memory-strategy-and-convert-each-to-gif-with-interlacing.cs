using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu files
        string[] inputFiles = new string[]
        {
            @"C:\Input\doc1.djvu",
            @"C:\Input\doc2.djvu"
        };

        // Hardcoded output base directory
        string outputBaseDir = @"C:\Output";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create a subdirectory for each source file's pages
            string sourceName = Path.GetFileNameWithoutExtension(inputPath);
            string outputDir = Path.Combine(outputBaseDir, sourceName);
            Directory.CreateDirectory(outputDir); // Ensure directory exists

            // Load DjVu with a memory buffer hint (e.g., 1 MB)
            using (FileStream stream = File.OpenRead(inputPath))
            {
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1 * 1024 * 1024 // 1 MB
                };

                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                {
                    int pageIndex = 0;
                    foreach (var page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.gif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as an interlaced GIF
                        GifOptions gifOptions = new GifOptions
                        {
                            Interlaced = true
                        };
                        page.Save(outputPath, gifOptions);

                        pageIndex++;
                    }
                }
            }
        }
    }
}