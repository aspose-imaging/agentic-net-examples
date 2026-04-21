using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputDirectory = "Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load DjVu document from file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Iterate through each page
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Retrieve original dimensions
                int originalWidth = page.Width;
                int originalHeight = page.Height;
                Console.WriteLine($"Page {page.PageNumber}: {originalWidth}x{originalHeight}");

                // Define target width for scaling (example: 1000 pixels)
                const int targetWidth = 1000;
                // Calculate scaling factor while preserving aspect ratio
                double scale = (double)targetWidth / originalWidth;
                int newWidth = targetWidth;
                int newHeight = (int)(originalHeight * scale);

                // Resize the page
                page.Resize(newWidth, newHeight);

                // Prepare output file path
                string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the resized page as PNG
                page.Save(outputPath, new PngOptions());
            }
        }
    }
}