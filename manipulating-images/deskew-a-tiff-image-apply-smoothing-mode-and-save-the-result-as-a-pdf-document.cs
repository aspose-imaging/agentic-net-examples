using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

public class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.tif";
        string outputPath = "Output\\result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Deskew the image
            tiffImage.NormalizeAngle(true, Color.White);

            // Save as PDF with smoothing mode applied
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = tiffImage.Width,
                    PageHeight = tiffImage.Height,
                    SmoothingMode = SmoothingMode.None
                }
            };

            tiffImage.Save(outputPath, pdfOptions);
        }
    }
}