using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

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

            foreach (string inputPath in files.Where(f => Path.GetExtension(f).Equals(".cdr", StringComparison.OrdinalIgnoreCase)))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(outputPath, pngOptions);
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
 * 1. When a design studio must batch‑convert legacy CorelDRAW (.cdr) projects into Photoshop (.psd) files while preserving the original layer hierarchy for seamless hand‑off to Photoshop editors.
 * 2. When an automated publishing workflow needs to generate high‑resolution PSD assets from a folder of CDR illustrations to apply additional effects or compositing in Adobe Photoshop.
 * 3. When a cloud‑based image‑processing service offers an API that transforms uploaded CDR files into editable PSD files, enabling users to edit vector layers directly in Photoshop.
 * 4. When a migration tool is required to move a large library of CorelDRAW assets to a Photoshop‑centric asset management system without flattening the artwork.
 * 5. When a quality‑control script must render each CDR file as a layered PSD and then export a PNG preview for visual verification before final production.
 */