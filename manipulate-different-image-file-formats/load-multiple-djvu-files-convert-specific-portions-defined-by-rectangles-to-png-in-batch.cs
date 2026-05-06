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
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            // Define the rectangle region to extract (example values)
            var exportRect = new Rectangle(0, 0, 200, 200); // Adjust as needed

            foreach (var inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the DjVu image
                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    // Iterate through each page of the DjVu document
                    foreach (DjvuPage page in djvu.Pages)
                    {
                        // Construct the output file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.PageNumber}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the specified rectangle region as a PNG image
                        page.Save(outputPath, new PngOptions(), exportRect);
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