using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Validate input directory
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all DjVu files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

        // Define the rectangles to export (example rectangle)
        Aspose.Imaging.Rectangle[] exportRectangles = new Aspose.Imaging.Rectangle[]
        {
            new Aspose.Imaging.Rectangle(0, 0, 500, 500)
        };

        foreach (string filePath in files)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                continue;
            }

            // Load DjVu image from file stream
            using (FileStream stream = File.OpenRead(filePath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Iterate through each page
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    var page = djvuImage.Pages[i];

                    // Export each defined rectangle
                    foreach (var rect in exportRectangles)
                    {
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(filePath)}_page{i + 1}_region.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the specified region as PNG
                        using (PngOptions options = new PngOptions())
                        {
                            page.Save(outputPath, options, rect);
                        }
                    }
                }
            }
        }
    }
}