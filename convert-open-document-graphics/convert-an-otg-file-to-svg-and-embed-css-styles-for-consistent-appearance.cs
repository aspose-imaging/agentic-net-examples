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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG to SVG conversion
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set SVG options and embed CSS-like consistency by rendering text as shapes
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = otgOptions,
                    TextAsShapes = true
                };

                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}