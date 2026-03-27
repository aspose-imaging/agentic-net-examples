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
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load DjVu image from stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare BMP save options with 32 bits per pixel
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 32
                };

                // Iterate through each page and save as BMP
                foreach (DjvuPage djvuPage in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP using the custom options
                    djvuPage.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}