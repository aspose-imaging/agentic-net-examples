using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu files
            string[] inputPaths = {
                @"C:\Images\sample1.djvu",
                @"C:\Images\sample2.djvu"
            };

            // Define the page range to convert (inclusive)
            int startPage = 1; // first page index (0‑based)
            int endPage = 3;   // last page index (0‑based)

            // Create an IntRange instance (required by the task)
            IntRange range = new IntRange(startPage, endPage);

            foreach (string inputPath in inputPaths)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output directory (same folder as input)
                string outputDirectory = Path.GetDirectoryName(inputPath);
                Directory.CreateDirectory(outputDirectory);

                // Open the DjVu file as a stream
                using (FileStream stream = File.OpenRead(inputPath))
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Ensure the requested range does not exceed page count
                    int maxPage = Math.Min(endPage, djvuImage.PageCount - 1);
                    for (int pageIndex = startPage; pageIndex <= maxPage; pageIndex++)
                    {
                        // Build output BMP file path
                        string outputPath = Path.Combine(
                            outputDirectory,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}.bmp");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set BMP save options (MultiPageOptions not needed for BMP,
                        // but we demonstrate usage with DjvuMultiPageOptions)
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            MultiPageOptions = new DjvuMultiPageOptions(range)
                        };

                        // Save the specific page as BMP
                        djvuImage.Pages[pageIndex].Save(outputPath, bmpOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}