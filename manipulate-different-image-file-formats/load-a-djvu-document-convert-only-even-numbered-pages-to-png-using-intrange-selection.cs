using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageCount = djvuImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        // Process only even-numbered pages (1-based indexing)
                        if ((i + 1) % 2 != 0)
                            continue;

                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Select the current page using IntRange
                        IntRange range = new IntRange(i, i);
                        DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(range);

                        // Configure PNG save options with the page selection
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.MultiPageOptions = multiPageOptions;

                        // Save the selected page as PNG
                        djvuImage.Save(outputPath, pngOptions);
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