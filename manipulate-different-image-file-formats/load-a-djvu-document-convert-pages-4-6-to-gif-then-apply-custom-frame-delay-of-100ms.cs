using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\pages_4_6.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvu = new DjvuImage(stream))
                {
                    // Select pages 4‑6 (zero‑based indexes 3,4,5)
                    int[] pages = new int[] { 3, 4, 5 };
                    var djvuMulti = new DjvuMultiPageOptions(pages)
                    {
                        // Set custom frame delay of 100 ms
                        TimeInterval = new TimeInterval(0, 100)
                    };

                    // Configure GIF save options with the selected pages and frame delay
                    var gifOptions = new GifOptions
                    {
                        MultiPageOptions = djvuMulti
                    };

                    // Save selected pages as an animated GIF
                    djvu.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}