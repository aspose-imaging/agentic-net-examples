using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "Input.bmp";
        string outputPath = "Output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image bmpImage = Image.Load(inputPath))
        {
            int width = bmpImage.Width;
            int height = bmpImage.Height;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Draw the BMP onto the TIFF canvas
                Graphics graphics = new Graphics(tiffImage);
                graphics.DrawImage(bmpImage, 0, 0);

                // Apply grayscale conversion
                tiffImage.Grayscale();

                // Since the image is bound to a file source, save without specifying path
                tiffImage.Save();
            }
        }
    }
}