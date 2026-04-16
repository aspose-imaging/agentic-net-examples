using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input EMF file and output directory
        string inputPath = "input.emf";
        string outputDirectory = "output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (will be used for all pages)
        Directory.CreateDirectory(outputDirectory);

        // Load the multi‑page EMF document
        using (Image image = Image.Load(inputPath))
        {
            // Verify the image supports multiple pages
            if (image is IMultipageImage multipageImage)
            {
                int pageCount = multipageImage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    // Retrieve the page as an Image
                    using (Image page = multipageImage.Pages[i])
                    {
                        // Prepare PNG save options with vector rasterization settings
                        PngOptions pngOptions = new PngOptions();

                        // Configure rasterization to match the page size
                        EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                        {
                            PageSize = page.Size
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, pngOptions);
                    }
                }
            }
            else
            {
                Console.Error.WriteLine("The loaded image does not support multiple pages.");
            }
        }
    }
}