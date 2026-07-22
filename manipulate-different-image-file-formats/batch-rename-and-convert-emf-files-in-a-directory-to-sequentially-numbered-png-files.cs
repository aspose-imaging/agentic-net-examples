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
            int counter = 1;

            foreach (string inputPath in files)
            {
                if (!Path.GetExtension(inputPath).Equals(".emf", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, $"{counter}.png");
                counter++;

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to migrate a legacy collection of vector EMF diagrams into web‑friendly PNG images with sequential filenames for easy indexing.
 * 2. When an automated build process must generate thumbnail PNG previews from EMF assets stored in a source folder for inclusion in documentation portals.
 * 3. When a data‑import routine has to standardize incoming EMF files from multiple vendors by renaming them to numeric order and converting them to a common raster format for downstream analytics.
 * 4. When a Windows desktop application must batch process user‑uploaded EMF charts, renaming each file sequentially and saving them as PNGs for display in a gallery view.
 * 5. When a CI/CD pipeline requires converting EMF icons to PNG sprites and assigning them incremental names to simplify asset management in a cross‑platform UI project.
 */