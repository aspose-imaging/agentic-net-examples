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
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Process ten DjVu files
            for (int i = 1; i <= 10; i++)
            {
                string inputPath = Path.Combine(inputDirectory, $"file{i}.djvu");
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, $"file{i}.gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu image
                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    // Configure GIF options with custom frame delay (200 ms)
                    var gifOptions = new GifOptions
                    {
                        MultiPageOptions = new MultiPageOptions
                        {
                            Mode = MultiPageMode.TimeInterval,
                            TimeInterval = new TimeInterval(0, 200) // delay in milliseconds
                        },
                        LoopsCount = 0 // infinite looping
                    };

                    // Save as GIF
                    djvu.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}