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
        string outputFolder = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Target width for scaling (example: 1024 pixels)
                const int targetWidth = 1024;

                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original dimensions
                    int originalWidth = page.Width;
                    int originalHeight = page.Height;

                    // Calculate scaling factor to maintain aspect ratio
                    double scale = (double)targetWidth / originalWidth;
                    int newWidth = targetWidth;
                    int newHeight = (int)(originalHeight * scale);

                    // Resize the page
                    page.Resize(newWidth, newHeight);

                    // Prepare output file path
                    string outputPath = Path.Combine(outputFolder, $"page_{page.PageNumber}.png");

                    // Ensure directory for this file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resized page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}