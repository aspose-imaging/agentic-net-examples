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
            string inputPath = "input.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define cropping rectangle (example values)
            var cropRect = new Rectangle(100, 100, 500, 500);

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (var pageObj in djvu.Pages)
                {
                    var page = (DjvuPage)pageObj;

                    // Apply cropping
                    page.Crop(cropRect);

                    // Prepare output BMP path for the current page
                    string outputPath = $"page_{pageIndex}.bmp";

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save cropped page as BMP
                    page.Save(outputPath, new BmpOptions());

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}