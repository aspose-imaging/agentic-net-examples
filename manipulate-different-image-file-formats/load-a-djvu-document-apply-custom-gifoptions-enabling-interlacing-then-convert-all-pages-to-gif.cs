using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"C:\Temp\sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for GIF files
        string outputDir = @"C:\Temp\GifOutput";

        // Ensure the output directory exists (creates parent directories as needed)
        Directory.CreateDirectory(outputDir);

        // Load the DjVu document from a file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
        {
            // Prepare GIF save options with interlacing enabled
            GifOptions gifOptions = new GifOptions
            {
                Interlaced = true
            };

            // Iterate through each page and save as an interlaced GIF
            foreach (DjvuPage page in djvuImage.Pages)
            {
                string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.gif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as GIF using the specified options
                page.Save(outputPath, gifOptions);
            }
        }
    }
}