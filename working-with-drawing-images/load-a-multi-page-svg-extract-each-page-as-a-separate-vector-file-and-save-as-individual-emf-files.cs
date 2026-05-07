using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\multpage.svg";
        string outputDirectory = @"C:\Temp\Output";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Load the SVG image (supports multipage)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multipageImage = image as IMultipageImage;
                if (multipageImage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
                    return;
                }

                // Iterate over each page
                for (int pageIndex = 0; pageIndex < multipageImage.PageCount; pageIndex++)
                {
                    // Build output path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex + 1}.emf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare EMF export options
                    EmfOptions exportOptions = new EmfOptions();

                    // Export only the current page
                    exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, pageIndex + 1));

                    // Set vector rasterization options (page size taken from the source image)
                    EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    exportOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the current page as EMF
                    image.Save(outputPath, exportOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}