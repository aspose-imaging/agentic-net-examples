using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file from a stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Log total number of pages
            Console.WriteLine($"Total pages: {djvuImage.PageCount}");

            // Iterate through each page and save as PNG
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                // Build output file name based on page number
                string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                djvuPage.Save(outputPath, new PngOptions());
            }
        }
    }
}