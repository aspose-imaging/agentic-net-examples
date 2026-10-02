// HOW-TO: Batch Convert CDR Files to 256-Color GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

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
                if (!inputPath.EndsWith(".cdr", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.ChangeExtension(Path.GetFileName(inputPath), ".gif");
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    using (GifOptions gifOptions = new GifOptions())
                    {
                        gifOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        };
                        cdr.Save(outputPath, gifOptions);
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
 * 1. When you need to automate the conversion of multiple CorelDRAW (.cdr) drawings into web‑friendly 256‑color GIF images for a publishing workflow.
 * 2. When a legacy design archive stored as CDR files must be prepared for email newsletters that only support GIF format with limited palette.
 * 3. When an e‑learning platform requires batch processing of vector illustrations into small GIF files to reduce page load time.
 * 4. When a digital asset management system must regularly ingest CDR assets and store them as GIF thumbnails with a fixed color depth.
 * 5. When a Windows service has to generate static GIF previews of CDR drawings for a reporting dashboard.
 */
