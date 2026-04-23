using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories (relative paths)
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

            // Get all EMF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            // Process each file and convert to sequential PNG
            for (int i = 0; i < files.Length; i++)
            {
                string inputPath = files[i];

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with sequential numbering (1.png, 2.png, ...)
                string outputPath = Path.Combine(outputDirectory, $"{i + 1}.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure PNG options with vector rasterization
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = image.Size
                        }
                    };

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}