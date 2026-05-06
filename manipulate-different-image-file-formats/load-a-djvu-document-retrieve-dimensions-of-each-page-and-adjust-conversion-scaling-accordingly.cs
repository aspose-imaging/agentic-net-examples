using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Retrieve original dimensions
                        int originalWidth = page.Width;
                        int originalHeight = page.Height;

                        // Define target width for scaling (example: 1024 pixels)
                        const int targetWidth = 1024;
                        // Calculate scaling factor while preserving aspect ratio
                        double scale = (double)targetWidth / originalWidth;
                        int targetHeight = (int)(originalHeight * scale);

                        // Resize the page
                        page.Resize(targetWidth, targetHeight);

                        // Prepare output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the resized page as PNG
                        page.Save(outputPath, new PngOptions());
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