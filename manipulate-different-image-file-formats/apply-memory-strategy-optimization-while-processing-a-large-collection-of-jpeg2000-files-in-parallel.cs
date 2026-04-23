using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\temp\input";
            string outputDir = @"C:\temp\output";

            // Get all JPEG2000 files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.jp2");

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (convert to PNG)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set load options with a memory buffer size hint (e.g., 50 MB)
                var loadOptions = new Jpeg2000LoadOptions
                {
                    BufferSizeHint = 50
                };

                // Load the JPEG2000 image using Aspose.Imaging
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save as PNG with default options (could also set BufferSizeHint here if needed)
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}