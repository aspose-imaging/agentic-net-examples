using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input SVG path
            string inputPath = "input.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG pages
            string outputDir = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the SVG (could be multipage)
            using (Image image = Image.Load(inputPath))
            {
                // Try to treat the image as a multipage image
                if (image is IMultipageImage multipageImage && multipageImage.PageCount > 0)
                {
                    int pageIndex = 0;
                    foreach (Image page in multipageImage.Pages)
                    {
                        // Prepare PNG save options with 300 DPI
                        PngOptions pngOptions = new PngOptions
                        {
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

                        // Configure vector rasterization options for the current page
                        SvgRasterizationOptions vectorOptions = new SvgRasterizationOptions
                        {
                            PageWidth = page.Width,
                            PageHeight = page.Height,
                            BackgroundColor = Color.White
                        };
                        pngOptions.VectorRasterizationOptions = vectorOptions;

                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, pngOptions);

                        // Dispose the page image
                        page.Dispose();

                        pageIndex++;
                    }
                }
                else
                {
                    // Single-page SVG handling
                    PngOptions pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

                    SvgRasterizationOptions vectorOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    string outputPath = Path.Combine(outputDir, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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