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
        string outputPath = @"C:\Temp\output_pages_3_7.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu with memory optimization (buffer size hint)
        using (Stream stream = File.OpenRead(inputPath))
        {
            var loadOptions = new LoadOptions
            {
                // Example: limit internal buffers to 1 MB
                BufferSizeHint = 1 * 1024 * 1024
            };

            using (var djvuImage = new DjvuImage(stream, loadOptions))
            {
                // Prepare GIF save options and specify page range 3‑7
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 3, 4, 5, 6, 7 })
                };

                // Save selected pages as a single GIF file
                djvuImage.Save(outputPath, gifOptions);
            }
        }
    }
}