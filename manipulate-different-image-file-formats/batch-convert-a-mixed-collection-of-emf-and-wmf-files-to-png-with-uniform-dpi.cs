using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");
            string[] wmfFiles = Directory.GetFiles(inputDirectory, "*.wmf");
            string[] allFiles = new string[emfFiles.Length + wmfFiles.Length];
            emfFiles.CopyTo(allFiles, 0);
            wmfFiles.CopyTo(allFiles, emfFiles.Length);

            foreach (string inputPath in allFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300) // uniform DPI
                    };

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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a batch of legacy vector graphics (EMF and WMF) into web‑friendly PNG images with a consistent DPI for display on a website.
 * 2. When an automation script must process user‑uploaded EMF/WMF files and generate high‑resolution PNG thumbnails for a document management system.
 * 3. When a reporting tool requires rasterizing mixed vector formats into PNGs to embed them in PDF reports with uniform scaling.
 * 4. When a migration project moves Windows Metafile assets to a cloud storage solution that only supports PNG, ensuring all images retain the same resolution.
 * 5. When a desktop application needs to pre‑render vector icons from EMF and WMF files into PNG sprites for faster UI loading on different screen densities.
 */