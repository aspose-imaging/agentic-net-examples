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
        string outputDirectory = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates if missing)
        Directory.CreateDirectory(outputDirectory);

        // Load the DjVu document from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Retrieve and log the total number of pages
            int pageCount = djvuImage.PageCount;
            Console.WriteLine($"Total number of pages: {pageCount}");

            // Convert each page to PNG and save
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                // Build the output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"sample.{djvuPage.PageNumber}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                djvuPage.Save(outputPath, new PngOptions());
            }
        }
    }
}