using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (var file in files)
            {
                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath);
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
 * 1. When a developer needs to copy a large collection of PNG assets from an input folder to an output folder while ensuring each image is correctly parsed and saved using Aspose.Imaging to prevent file corruption.
 * 2. When an application must batch‑process user‑uploaded PNG files by loading them with the Aspose.Imaging .NET library and re‑saving them to a standardized output directory for downstream processing.
 * 3. When a CI/CD pipeline includes a validation step that loads every PNG in a repository with Image.Load and writes it back with Image.Save to confirm the files are readable by Aspose.Imaging before release.
 * 4. When a desktop utility has to import multiple PNG screenshots, normalize their file paths, and store the images in a dedicated output folder as a preparation stage for further analysis.
 * 5. When a server‑side service iterates through an Input directory, loads each PNG using Aspose.Imaging, and writes unchanged copies to an Output directory to create a staging area for subsequent image filtering operations.
 */