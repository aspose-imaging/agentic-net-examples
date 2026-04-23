using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Wrap the entire processing in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\WebPInput\";
            string outputDir = @"C:\WebPOutput\";

            // Ensure the output directory exists (creates the folder if missing)
            Directory.CreateDirectory(outputDir);

            // Get all WebP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.webp");

            // Process each WebP file
            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the corresponding output path (convert to PNG)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set a memory usage limit (buffer size hint) for loading the image
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 100 // limit internal buffers to 100 MB
                };

                // Load the WebP image with the specified memory limit
                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save the image to PNG format
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime exception message without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}