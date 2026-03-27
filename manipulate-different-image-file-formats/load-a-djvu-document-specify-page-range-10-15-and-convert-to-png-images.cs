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
        string inputPath = @"C:\temp\sample.djvu";
        string outputDirectory = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Open the DjVu file
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Iterate through pages and process pages 10‑15
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                int pageNumber = djvuPage.PageNumber;
                if (pageNumber < 10 || pageNumber > 15)
                    continue; // Skip pages outside the desired range

                // Build output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                djvuPage.Save(outputPath, new PngOptions());
            }
        }
    }
}