using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"C:\temp\sample.djvu";
        // Hardcoded output directory for converted PNG pages
        string outputDir = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates if missing)
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            // Load the DjVu document
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Iterate through each page in the document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Retrieve original page dimensions
                    var originalSize = page.Size;
                    Console.WriteLine($"Page {page.PageNumber}: {originalSize.Width}x{originalSize.Height}");

                    // Define a target width for scaling (example: 1000 pixels)
                    int targetWidth = 1000;
                    // Compute scaling factor based on width
                    double scale = (double)targetWidth / originalSize.Width;
                    // Calculate new dimensions while preserving aspect ratio
                    int newWidth = (int)(originalSize.Width * scale);
                    int newHeight = (int)(originalSize.Height * scale);

                    // Resize the page to the new dimensions
                    page.Resize(newWidth, newHeight);

                    // Build the output file path for this page
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resized page as PNG
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}