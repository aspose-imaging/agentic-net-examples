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
            // Hardcoded input and output paths
            string inputPath = "input.emf";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the EMF document
            using (Image image = Image.Load(inputPath))
            {
                // Determine page count (EMF is typically single-page, but handle multipage if present)
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                // Prepare vector rasterization options once
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                for (int i = 0; i < pageCount; i++)
                {
                    // Construct output file path for each page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PNG options with per-page export
                    PngOptions pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1)),
                        VectorRasterizationOptions = vectorOptions
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