using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"C:\temp\sample.djvu";

        // Hardcoded output directory for PNG files
        string outputDir = @"C:\temp\output\";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu image from the stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Log the total number of pages
                Console.WriteLine($"Total pages: {djvuImage.PageCount}");

                // Iterate through each page and save it as a PNG
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Build the output file name based on the page number
                    string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as a PNG image
                    djvuPage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}