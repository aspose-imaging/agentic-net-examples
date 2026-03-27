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
        string inputPath = @"C:\Images\sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for BMP files
        string outputDir = @"C:\Images\BmpOutput";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file as a stream
        using (FileStream stream = File.OpenRead(inputPath))
        {
            // Load DjVu document
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Prepare BMP save options with 32 bits per pixel
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 32
                    };

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.bmp");

                    // Ensure the directory for the output file exists (redundant if outputDir already created)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as BMP using the specified options
                    page.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}