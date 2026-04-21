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
        string inputPath = "sample.djvu";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory for GIF files
        string outputDir = "output";

        // Ensure the output directory exists (unconditional as required)
        Directory.CreateDirectory(outputDir);

        // Open the DjVu file stream
        using (FileStream inputStream = File.OpenRead(inputPath))
        {
            // Load the DjVu document
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(inputStream))
            {
                // Iterate through each page in the DjVu document
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build the output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page{page.PageNumber}.gif");

                    // Ensure the directory for the output file exists (unconditional)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure GIF options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Save the current page as a GIF using the specified options
                    page.Save(outputPath, gifOptions);
                }
            }
        }
    }
}