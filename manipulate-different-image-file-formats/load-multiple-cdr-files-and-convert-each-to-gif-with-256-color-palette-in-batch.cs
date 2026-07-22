using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            foreach (var inputPath in files)
            {
                if (!Path.GetExtension(inputPath).Equals(".cdr", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    var options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (Image raster = Image.Create(options, cdr.Width, cdr.Height))
                    {
                        Graphics graphics = new Graphics(raster);
                        graphics.Clear(Aspose.Imaging.Color.White);
                        graphics.DrawImage(cdr, 0, 0);
                        raster.Save();
                    }
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a designer needs to automate the conversion of a large collection of CorelDRAW (.cdr) artwork files into web‑friendly 256‑color GIF images for faster page loads.
 * 2. When a legacy archival system requires batch processing of CDR files to GIF format with a limited palette to meet old printer or display hardware constraints.
 * 3. When an e‑commerce platform must generate thumbnail previews of product vector graphics stored as CDR files, converting them to 256‑color GIFs for consistent thumbnail size and color depth.
 * 4. When a marketing team wants to create animated slideshows from multiple CDR source files and needs a script that converts each file to a GIF with a fixed 256‑color palette for compatibility with email clients.
 * 5. When a CI/CD pipeline includes a step that validates visual assets by converting all CDR source files to GIF with a 256‑color palette to ensure deterministic rendering across environments.
 */