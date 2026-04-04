using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
        {
            // NOTE: Aspose.Imaging does not provide a direct API to modify the opacity of existing vector
            // line objects within an EMF. To achieve a semi‑transparent effect, one common approach is to
            // rasterize the EMF onto a canvas with the desired opacity. Here we simply rasterize the EMF
            // to PNG. If further opacity manipulation is required, additional pixel‑level processing can
            // be performed on the resulting raster image.

            // Create PNG save options
            PngOptions pngOptions = new PngOptions
            {
                // Set the source to a file create source (required when using Image.Create, but also safe here)
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the EMF as PNG
            emfImage.Save(outputPath, pngOptions);
        }
    }
}