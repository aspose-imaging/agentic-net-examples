using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                // Iterate through each page in the DjVu document
                for (int i = 0; i < djvu.PageCount; i++)
                {
                    // Get the current page
                    Image page = djvu.Pages[i];

                    // Prepare output file path for the GIF page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure GIF options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Save the page as a GIF using the specified options
                    page.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}