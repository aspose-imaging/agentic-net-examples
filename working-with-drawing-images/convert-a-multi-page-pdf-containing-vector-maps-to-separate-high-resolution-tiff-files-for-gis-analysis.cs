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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists; if not, create and exit
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

            // Get all PDF files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.pdf");

            foreach (var inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the PDF (vector image)
                using (Image image = Image.Load(inputPath))
                {
                    // Determine output file path (same name with .png extension)
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                    // Ensure output directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    using (var pngOptions = new PngOptions())
                    {
                        image.Save(outputPath, pngOptions);
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

/*
 * Real-World Use Cases:
 * 1. When a GIS analyst needs to extract each page of a multi‑page PDF containing vector maps and convert them to high‑resolution PNG images for raster‑based analysis using C# and Aspose.Imaging.
 * 2. When an e‑learning platform must automatically batch‑convert uploaded PDF handouts into PNG files for web preview thumbnails and fast loading in .NET applications.
 * 3. When a printing service wants to transform vector PDF brochures into PNG assets to embed them in HTML email campaigns without losing visual fidelity.
 * 4. When a document management system requires server‑side conversion of PDF blueprints to PNG format for quick visual indexing and searchable previews.
 * 5. When a mobile app backend needs to generate PNG raster images from PDF maps on the fly to serve devices that cannot render PDF natively.
 */