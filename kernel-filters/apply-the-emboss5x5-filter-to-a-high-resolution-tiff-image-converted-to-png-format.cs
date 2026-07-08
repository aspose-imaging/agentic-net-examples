using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5);

                tiffImage.Filter(tiffImage.Bounds, filterOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                tiffImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to add a 3‑D embossed effect to a high‑resolution TIFF scan of architectural drawings before publishing them as lightweight PNG files for web viewers.
 * 2. When a developer wants to preprocess large medical TIFF images with an emboss filter to enhance edge details and then convert them to PNG for integration into a diagnostic reporting system.
 * 3. When a developer must transform archival TIFF photographs into PNG format while applying the Emboss5x5 convolution to create stylized thumbnails for a digital museum catalog.
 * 4. When a developer is building an automated pipeline that receives high‑resolution TIFF satellite imagery, applies an emboss filter to highlight terrain features, and outputs PNG tiles for a GIS web application.
 * 5. When a developer needs to generate PNG assets with an embossed look from TIFF source files for a game’s texture atlas, ensuring the filter is applied during the format conversion step.
 */