using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure input and output directories exist
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (string svgPath in svgFiles)
        {
            if (!File.Exists(svgPath))
            {
                Console.Error.WriteLine($"File not found: {svgPath}");
                return;
            }

            // Load the SVG once; we'll reload for each size to avoid mutating the original
            foreach (int size in new int[] { 16, 32, 48, 256 })
            {
                // Reload SVG for each size to keep original dimensions
                using (Image svgImage = Image.Load(svgPath))
                {
                    // Resize to the desired icon size
                    svgImage.Resize(size, size);

                    // Prepare output ICO path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                    string outputPath = Path.Combine(outputDirectory, $"{fileNameWithoutExt}_{size}.ico");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create ICO options (default PNG frames, 32bpp)
                    IcoOptions icoOptions = new IcoOptions();

                    // Create ICO image from the resized raster image
                    using (Aspose.Imaging.FileFormats.Ico.IcoImage icoImage = new Aspose.Imaging.FileFormats.Ico.IcoImage((RasterImage)svgImage, icoOptions))
                    {
                        icoImage.Save(outputPath);
                    }
                }
            }
        }
    }
}