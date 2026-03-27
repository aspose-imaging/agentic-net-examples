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

        // Hardcoded output directory for BMP files
        string outputDir = @"C:\Temp\DjvuToBmp";

        // Ensure the output directory exists (unconditional call as required)
        Directory.CreateDirectory(outputDir);

        // Open the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Iterate through each page in the DjVu document
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Build output file path for the current page
                string outputPath = Path.Combine(outputDir, $"page{page.PageNumber}.bmp");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure BMP save options with 24 bits per pixel
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                // Save the page as a BMP image using the specified options
                page.Save(outputPath, bmpOptions);
            }
        }
    }
}