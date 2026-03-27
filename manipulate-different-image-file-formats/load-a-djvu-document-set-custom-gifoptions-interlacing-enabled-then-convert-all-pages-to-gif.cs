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
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu document
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Prepare GIF save options with interlacing enabled
                GifOptions gifOptions = new GifOptions
                {
                    Interlaced = true
                };

                // Iterate through each page and save as GIF
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.gif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a GIF using the specified options
                    page.Save(outputPath, gifOptions);
                }
            }
        }
    }
}