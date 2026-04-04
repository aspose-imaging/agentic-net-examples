using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "multipage.svg");
        string outputDirectory = "Output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Determine number of pages (SVG is typically single-page, but handle multipage if supported)
            int pageCount = 1;
            if (image is IMultipageImage multipageImage)
            {
                pageCount = multipageImage.PageCount;
            }

            // Iterate through each page and save as PNG with 300 DPI
            for (int i = 0; i < pageCount; i++)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    // Set resolution to 300 DPI
                    ResolutionSettings = new ResolutionSetting(300, 300),

                    // Configure vector rasterization options
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    },

                    // Export only the current page
                    MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                };

                // Save the current page as PNG
                image.Save(outputPath, pngOptions);
            }
        }
    }
}