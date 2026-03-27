using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input EMF file path
        string inputPath = "input.emf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the EMF document
        using (Image image = Image.Load(inputPath))
        {
            // Base output directory for PNG files
            string outputDir = "output";
            Directory.CreateDirectory(outputDir); // Unconditional directory creation

            // Common PNG save options with vector rasterization settings
            PngOptions pngOptions = new PngOptions();
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };
            pngOptions.VectorRasterizationOptions = vectorOptions;

            // Check if the image supports multiple pages
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage != null && multipage.PageCount > 0)
            {
                // Export each page to a separate PNG file
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Export only the current page
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, pngOptions);
                }
            }
            else
            {
                // Single-page EMF: save as a single PNG
                string outputPath = Path.Combine(outputDir, "page_1.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                image.Save(outputPath, pngOptions);
            }
        }
    }
}