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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add EMF files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    using (var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                        ColorType = PngColorType.TruecolorWithAlpha
                    })
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
 * 1. When a developer needs to batch‑convert a library of Windows Metafile (EMF) vector graphics into high‑resolution PNG images at 300 DPI with lossless compression for printing or publishing.
 * 2. When an automated build pipeline must generate web‑ready PNG thumbnails from EMF diagrams while preserving exact dimensions and a white background using Aspose.Imaging in C#.
 * 3. When a document management system has to process uploaded EMF files in bulk and store them as PNG files with consistent 300 DPI resolution for archival compliance.
 * 4. When a GIS or CAD application requires exporting vector map layers saved as EMF into raster PNG format for integration with raster‑based reporting tools.
 * 5. When a legacy Windows application outputs reports in EMF and a modern .NET service must transform those reports into PNG files with 300 DPI resolution for high‑quality PDF generation.
 */