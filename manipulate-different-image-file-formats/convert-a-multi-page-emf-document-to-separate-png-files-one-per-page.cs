using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input EMF file path
            string inputPath = "input.emf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options for PNG conversion
                var vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Determine page count (EMF is typically single-page, but handle multipage if present)
                var multipage = image as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                // Export each page to a separate PNG file
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = $"output_page_{i + 1}.png";

                    // Ensure output directory exists
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Configure PNG options with per-page MultiPageOptions
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions,
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    // Save the current page as PNG
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