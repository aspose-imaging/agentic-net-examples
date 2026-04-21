using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR vector image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Define the rectangular area for selective background removal
                // (example rectangle: X=100, Y=100, Width=400, Height=300)
                Rectangle selectionRect = new Rectangle(100, 100, 400, 300);

                // Crop the image to the selected rectangle
                cdrImage.Crop(selectionRect);

                // Remove background from the cropped vector image
                cdrImage.RemoveBackground(new RemoveBackgroundSettings());

                // Prepare PNG options with transparent background for rasterization
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = cdrImage.Size
                    }
                };

                // Save the rasterized image as PNG
                cdrImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}