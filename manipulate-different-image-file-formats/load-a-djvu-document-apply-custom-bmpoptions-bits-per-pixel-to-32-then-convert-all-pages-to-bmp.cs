using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageIndex = 0;
                    // Iterate through each page in the document
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Define output BMP file name for the current page
                        string outputPath = $"page_{pageIndex}.bmp";

                        // Ensure the output directory exists (handles null or empty directory)
                        string outputDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrWhiteSpace(outputDir))
                        {
                            Directory.CreateDirectory(outputDir);
                        }

                        // Configure BMP options with 32 bits per pixel
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 32
                        };

                        // Save the page as a BMP file using the specified options
                        page.Save(outputPath, bmpOptions);

                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}