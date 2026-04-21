using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu file path
        string inputPath = "sample.djvu";

        // Hardcoded output directory for BMP files
        string outputDir = "output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Open the DjVu file as a stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load DjVu image from the stream
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int pageIndex = 0;
                // Iterate through each page in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Define the cropping rectangle (example values)
                    Rectangle cropRect = new Rectangle(50, 50, 200, 200);
                    // Apply cropping to the current page
                    page.Crop(cropRect);

                    // Build output BMP file path for the current page
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
}