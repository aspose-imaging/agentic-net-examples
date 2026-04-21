using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string baseDir = Directory.GetCurrentDirectory();
        string inputPath = Path.Combine(baseDir, "Input", "multipage.svg");
        string outputDir = Path.Combine(baseDir, "Output");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Determine if the image supports multiple pages
            IMultipageImage multipage = image as IMultipageImage;
            int pageCount = multipage != null ? multipage.PageCount : 1;

            for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                // Prepare output file path for each page
                string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure PNG export options with 300 DPI resolution
                using (PngOptions pngOptions = new PngOptions())
                {
                    // Set resolution to 300 DPI
                    pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                    // Set vector rasterization options (page size based on original image)
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Export only the current page
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, 1));

                    // Save the page as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
    }
}