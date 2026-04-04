using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all SVG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (var filePath in files)
        {
            // Verify the input file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Prepare output file path with .png extension
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".png");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image, remove background, and rasterize to PNG
            using (Image image = Image.Load(filePath))
            {
                if (image is VectorImage vectorImage)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }

                using (PngOptions pngOptions = new PngOptions())
                {
                    VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.Transparent,
                        PageSize = image.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(outputPath, pngOptions);
                }
            }

            Console.WriteLine($"Processed: {Path.GetFileName(filePath)} -> {Path.GetFileName(outputPath)}");
        }
    }
}