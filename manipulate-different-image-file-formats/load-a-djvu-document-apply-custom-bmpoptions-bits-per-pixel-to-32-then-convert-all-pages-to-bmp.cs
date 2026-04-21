using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Configure BMP options with 32 bits per pixel
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 32;

            // Export each page to a separate BMP file
            foreach (DjvuPage page in djvuImage.Pages)
            {
                string outputPath = Path.Combine("Output", $"page_{page.PageNumber}.bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page using the custom BMP options
                page.Save(outputPath, bmpOptions);
            }
        }
    }
}