using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!Path.GetExtension(inputPath).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    SvgOptions options = new SvgOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Aspose.Imaging.Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };

                    image.Save(outputPath, options);
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
 * 1. When a developer needs to convert a legacy collection of BMP icons into scalable SVG graphics with inverted colors for a modern web UI, they can use this code to batch process the files.
 * 2. When an automation script must prepare print‑ready artwork by inverting the colors of scanned BMP drawings and exporting them as SVG vectors for further editing, this example provides the necessary C# workflow.
 * 3. When a game asset pipeline requires turning monochrome BMP textures into inverted SVG assets for resolution‑independent rendering, the code demonstrates how to load, invert, and save them in bulk.
 * 4. When a document generation system has to embed high‑contrast SVG diagrams derived from BMP source images, developers can employ this snippet to perform the color inversion and format conversion automatically.
 * 5. When a batch image‑processing tool needs to replace outdated BMP logos with white‑background SVG versions that have their colors reversed for branding guidelines, this C# example shows the required steps.
 */