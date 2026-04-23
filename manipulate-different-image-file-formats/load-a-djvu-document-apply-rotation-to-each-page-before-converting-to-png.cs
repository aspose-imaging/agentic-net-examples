using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = "sample.djvu";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Rotate the page 90 degrees clockwise, resize proportionally, white background
                        page.Rotate(90f, true, Color.White);

                        // Prepare output PNG file path for the current page
                        string outputPath = $"page_{page.PageNumber}.png";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                        // Save the rotated page as PNG
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