using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the DjVu document
        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            // Iterate through each page
            foreach (DjvuPage page in djvuImage.Pages)
            {
                // Rotate the page 90 degrees clockwise, resize proportionally, white background
                page.Rotate(90f, true, Color.White);

                // Prepare output file path for the current page
                string outputPath = Path.Combine("Output", $"page_{page.PageNumber}.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the rotated page as PNG
                page.Save(outputPath, new PngOptions());
            }
        }
    }
}