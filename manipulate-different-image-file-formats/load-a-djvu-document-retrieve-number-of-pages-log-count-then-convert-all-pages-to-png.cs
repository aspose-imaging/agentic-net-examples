using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directory
            string inputPath = @"c:\temp\sample.djvu";
            string outputDir = @"c:\temp\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu document from a file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Log the total number of pages
                Console.WriteLine($"Page count: {djvuImage.PageCount}");

                // Iterate through each page and save as PNG
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Build output file name
                    string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as PNG
                    djvuPage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}