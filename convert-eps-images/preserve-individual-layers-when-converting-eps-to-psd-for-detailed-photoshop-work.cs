using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PSD save options
                var psdOptions = new PsdOptions();

                // Set vector rasterization options to preserve vector data as layers
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                psdOptions.VectorRasterizationOptions = vectorOptions;

                // If the EPS contains multiple pages, export each page as a separate PSD layer
                if (image is IMultipageImage multipage && multipage.PageCount > 1)
                {
                    psdOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
                }

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}