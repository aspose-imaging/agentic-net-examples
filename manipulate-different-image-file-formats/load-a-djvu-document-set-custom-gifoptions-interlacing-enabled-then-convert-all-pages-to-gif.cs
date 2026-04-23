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
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvu = new DjvuImage(stream))
                {
                    // Iterate through each page
                    for (int i = 0; i < djvu.PageCount; i++)
                    {
                        // Get the current page
                        Image page = djvu.Pages[i];

                        // Build output path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure GIF options with interlacing enabled
                        GifOptions gifOptions = new GifOptions
                        {
                            Interlaced = true
                        };

                        // Save the page as a GIF file
                        page.Save(outputPath, gifOptions);
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