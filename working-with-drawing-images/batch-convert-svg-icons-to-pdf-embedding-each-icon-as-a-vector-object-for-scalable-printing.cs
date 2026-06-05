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

            foreach (var filePath in files)
            {
                if (!Path.GetExtension(filePath).Equals(".svg", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(filePath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate print‑ready PDF catalogs of UI icons stored as SVG files, they can use this code to batch convert each icon into a vector PDF that scales without loss of quality.
 * 2. When an e‑learning platform requires downloadable PDF handouts that contain scalable SVG diagrams, the code enables automated conversion of all diagram files in a folder to vector PDFs.
 * 3. When a branding agency must deliver client logo assets as PDFs for high‑resolution printing, this script quickly processes a directory of SVG logos into vector PDFs with exact page dimensions.
 * 4. When a CI/CD pipeline must validate that all SVG assets in a repository can be rendered as PDFs for documentation builds, the code provides a simple C# step to batch convert and verify each file.
 * 5. When a desktop publishing workflow needs to embed SVG icons into PDF templates without rasterizing them, this example converts each icon to a vector PDF preserving editability and crispness.
 */