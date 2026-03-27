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
        string inputPath = @"input\sample.djvu";
        string outputDirectory = @"output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (DirectoryName may be null for root paths, handle safely)
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
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

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as GIF using the custom options
                page.Save(outputPath, gifOptions);
            }
        }
    }
}