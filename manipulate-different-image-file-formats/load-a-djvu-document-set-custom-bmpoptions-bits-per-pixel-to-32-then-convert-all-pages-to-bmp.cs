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

        // Hardcoded output directory for BMP files
        string outputDirectory = @"C:\Temp\DjvuToBmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates parent directories if needed)
        Directory.CreateDirectory(outputDirectory);

        // Open the DjVu document from a file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Iterate through each page in the DjVu document
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Build the output BMP file path for the current page
                string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure BMP save options with 32 bits per pixel
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 32
                };

                // Save the current page as a BMP file using the specified options
                page.Save(outputPath, bmpOptions);
            }
        }
    }
}