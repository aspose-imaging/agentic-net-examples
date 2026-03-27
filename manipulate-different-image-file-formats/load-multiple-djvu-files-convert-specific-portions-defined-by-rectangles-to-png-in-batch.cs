using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure directories exist
        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(outputDirectory);

        // Get all DjVu files in the input directory
        string[] djvuFiles = Directory.GetFiles(inputDirectory, "*.djvu");

        foreach (string inputPath in djvuFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Define rectangles to export (example areas)
                    Rectangle[] exportAreas = new Rectangle[]
                    {
                        new Rectangle(0, 0, 200, 200),
                        new Rectangle(100, 100, 300, 300)
                    };

                    // Iterate over each page
                    for (int pageIndex = 0; pageIndex < djvuImage.PageCount; pageIndex++)
                    {
                        // Export each defined rectangle from the current page
                        for (int rectIndex = 0; rectIndex < exportAreas.Length; rectIndex++)
                        {
                            Rectangle area = exportAreas[rectIndex];

                            // Set up PNG save options with multi‑page export configuration
                            PngOptions pngOptions = new PngOptions();
                            pngOptions.MultiPageOptions = new DjvuMultiPageOptions(pageIndex, area);

                            // Build output file path
                            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{pageIndex}_rect{rectIndex}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            // Ensure output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the selected area as PNG
                            djvuImage.Save(outputPath, pngOptions);
                        }
                    }
                }
            }
        }
    }
}