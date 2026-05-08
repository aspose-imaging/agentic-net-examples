using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output_gifs";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional call as per safety rule)
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page
                    for (int i = 0; i < djvuImage.PageCount; i++)
                    {
                        // Prepare output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");

                        // Ensure the directory for the output file exists (unconditional)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure GIF options with interlacing enabled
                        GifOptions gifOptions = new GifOptions
                        {
                            Interlaced = true
                        };

                        // Save the current page as a GIF using the specified options
                        djvuImage.Pages[i].Save(outputPath, gifOptions);
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