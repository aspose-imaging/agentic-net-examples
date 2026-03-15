using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputVectorPath> <outputApngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector type
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            // Configure APNG options with transparent background and rasterization settings
            var apngOptions = new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                    new object[] { Color.Transparent, image.Width, image.Height })
            };
            apngOptions.VectorRasterizationOptions.BackgroundColor = Color.Transparent;

            // Save the processed image as APNG
            image.Save(outputPath, apngOptions);
        }
    }
}