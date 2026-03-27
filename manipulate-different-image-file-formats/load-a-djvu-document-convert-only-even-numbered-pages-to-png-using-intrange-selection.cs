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

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the DjVu document from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Iterate through all pages
            foreach (DjvuPage djvuPage in djvuImage.Pages)
            {
                // Process only even‑numbered pages
                if (djvuPage.PageNumber % 2 != 0)
                    continue;

                // Build the output file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page.{djvuPage.PageNumber}.png");

                // Ensure the directory for the output file exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                djvuPage.Save(outputPath, new PngOptions());
            }
        }
    }
}