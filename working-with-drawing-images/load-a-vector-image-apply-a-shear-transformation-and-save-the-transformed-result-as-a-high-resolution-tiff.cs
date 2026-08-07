using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                using (Image rasterImage = Image.Create(tiffOptions, vectorImage.Width, vectorImage.Height))
                {
                    Graphics graphics = new Graphics(rasterImage);
                    graphics.DrawImage(vectorImage, new Point(0, 0));
                    rasterImage.Save(outputPath, tiffOptions);
                }
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
 * 1. When a developer needs to convert an SVG logo into a 300 dpi TIFF file for high‑quality print production, they can use this code to rasterize the vector and preserve detail.
 * 2. When a web application must generate a print‑ready TIFF from user‑uploaded SVG diagrams for inclusion in PDF reports, the snippet provides a straightforward C# solution.
 * 3. When an archival system requires storing vector artwork as lossless TIFF images to ensure compatibility with legacy imaging software, this code performs the conversion with proper resolution settings.
 * 4. When a document‑processing pipeline needs to transform scalable SVG icons into high‑resolution TIFF thumbnails for OCR preprocessing, the example shows how to load, rasterize, and save the images in .NET.
 * 5. When a batch job has to automate the conversion of multiple SVG files to 300 dpi TIFFs for a publishing workflow, the code demonstrates the necessary file handling, graphics drawing, and format options in Aspose.Imaging for .NET.
 */