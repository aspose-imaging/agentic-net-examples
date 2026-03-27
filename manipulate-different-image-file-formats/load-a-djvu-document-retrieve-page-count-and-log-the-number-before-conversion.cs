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
        string inputPath = @"c:\temp\sample.djvu";
        string outputDirectory = @"c:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(outputDirectory);

        // Load the DjVu document from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Retrieve and log the total number of pages
            int pageCount = djvuImage.PageCount;
            Console.WriteLine($"Total number of pages: {pageCount}");

            // Convert each page to PNG
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                // Build output file name for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                djvuPage.Save(outputPath, new PngOptions());
            }
        }
    }
}