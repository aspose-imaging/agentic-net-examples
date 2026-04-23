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
            // Hardcoded input path
            string inputPath = "input.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through all pages
                    for (int i = 0; i < djvuImage.PageCount; i++)
                    {
                        var page = djvuImage.Pages[i];

                        // Construct output file name for each page
                        string outputPath = $"output_page_{i + 1}.bmp";

                        // Ensure the output directory exists (handles null for current directory)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                        // Prepare BMP save options with 24 bits per pixel
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 24
                        };

                        // Save the page as BMP
                        page.Save(outputPath, bmpOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}