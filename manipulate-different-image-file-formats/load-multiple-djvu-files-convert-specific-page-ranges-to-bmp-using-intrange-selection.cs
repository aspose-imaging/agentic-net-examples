using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string[] inputPaths = {
            @"C:\Images\sample1.djvu",
            @"C:\Images\sample2.djvu"
        };

        string[] outputPaths = {
            @"C:\Output\sample1.bmp",
            @"C:\Output\sample2.bmp"
        };

        try
        {
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu file from a stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Define the page range to export (e.g., pages 1‑3)
                    IntRange pageRange = new IntRange(1, 3);

                    // Set up BMP save options with the page range
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        MultiPageOptions = new DjvuMultiPageOptions(pageRange)
                    };

                    // Save the selected pages as a single BMP file
                    djvuImage.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}