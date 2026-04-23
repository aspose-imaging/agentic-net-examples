using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

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

            // Output directory for BMP files
            string outputDir = "output";
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Define cropping rectangle (example values)
            var cropRect = new Rectangle(50, 50, 200, 200);

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageIndex = 0;
                    foreach (var page in djvuImage.Pages)
                    {
                        // Apply cropping to the current page
                        page.Crop(cropRect);

                        // Build output BMP file path
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.bmp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the cropped page as BMP
                        page.Save(outputPath, new BmpOptions());

                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}