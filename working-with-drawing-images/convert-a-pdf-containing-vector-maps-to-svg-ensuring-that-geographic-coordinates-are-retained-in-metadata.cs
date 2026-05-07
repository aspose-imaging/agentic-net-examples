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
            // Hardcoded relative input and output paths
            string inputPath = "Input\\map.pdf";
            string outputPath = "Output\\map.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    KeepMetadata = true // Preserve original metadata
                };

                // Set up vector rasterization options
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = new SizeF(image.Width, image.Height)
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}