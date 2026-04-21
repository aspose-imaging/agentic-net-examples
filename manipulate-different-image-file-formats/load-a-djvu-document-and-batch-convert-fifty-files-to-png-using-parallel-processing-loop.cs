using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Get up to 50 DjVu files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.djvu")
                                  .Take(50)
                                  .ToArray();

        // Process files in parallel
        Parallel.ForEach(files, filePath =>
        {
            // Verify input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Open the DjVu file as a stream
            using (FileStream stream = File.OpenRead(filePath))
            {
                // Load DjVu image
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page and save as PNG
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(filePath)}_page{page.PageNumber}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
                    }
                }
            }
        });
    }
}