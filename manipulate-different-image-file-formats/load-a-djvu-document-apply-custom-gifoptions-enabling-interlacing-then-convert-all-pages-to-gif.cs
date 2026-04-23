using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input DjVu file
            string inputPath = "Input/sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Iterate through all pages
                for (int i = 0; i < djvu.PageCount; i++)
                {
                    // Current page as an Image
                    Image page = djvu.Pages[i];

                    // Output GIF path for this page
                    string outputPath = $"Output/page_{i + 1}.gif";

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure GIF options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Save the page as GIF
                    page.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}