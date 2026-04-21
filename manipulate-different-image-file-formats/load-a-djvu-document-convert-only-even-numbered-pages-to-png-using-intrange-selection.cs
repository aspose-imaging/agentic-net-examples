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

        // Ensure the output directory exists (creates parent directories if needed)
        Directory.CreateDirectory(outputDirectory);

        // Open the DjVu file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu image
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through all pages
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Process only even‑numbered pages
                    if (page.PageNumber % 2 == 0)
                    {
                        // Build the output file path
                        string outputPath = Path.Combine(outputDirectory, $"sample.{page.PageNumber}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
    }
}