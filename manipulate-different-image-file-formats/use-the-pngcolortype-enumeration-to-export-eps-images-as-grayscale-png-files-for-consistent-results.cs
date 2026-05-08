using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample_grayscale.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image and export as grayscale PNG
            using (Image image = Image.Load(inputPath))
            {
                var epsImage = (EpsImage)image;

                var options = new PngOptions
                {
                    ColorType = PngColorType.Grayscale,
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = epsImage.Width,
                        PageHeight = epsImage.Height
                    }
                };

                epsImage.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}