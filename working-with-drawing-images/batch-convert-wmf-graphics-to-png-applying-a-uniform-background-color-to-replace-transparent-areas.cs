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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.wmf");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.FileFormats.Wmf.WmfImage wmfImage = (Aspose.Imaging.FileFormats.Wmf.WmfImage)Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = new WmfRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageSize = wmfImage.Size
                        }
                    };

                    wmfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to batch‑convert legacy WMF vector files into web‑ready PNG images and replace any transparent areas with a solid background color, this code provides a ready‑to‑use solution.
 * 2. When an application must generate thumbnail previews of WMF diagrams for a gallery or report and require consistent background shading, the code automates the conversion and background fill.
 * 3. When a migration project moves assets from a Windows Metafile library to a cross‑platform PNG format while preserving visual fidelity and eliminating transparency, this snippet handles the bulk processing.
 * 4. When a document‑generation system imports WMF icons and needs to embed them as PNGs with a uniform color backdrop for PDF or HTML output, the code performs the necessary rasterization.
 * 5. When a CI/CD pipeline needs to validate that all WMF assets in a repository are convertible to PNG with a predefined background for quality assurance, this script can be integrated to process the files automatically.
 */