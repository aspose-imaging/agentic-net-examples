// HOW-TO: Shear an SVG and Export as High-Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Svg;

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

            using (Image image = Image.Load(inputPath))
            {
                if (image is VectorImage)
                {
                    Graphics graphics = new Graphics(image);
                    Matrix matrix = new Matrix(1, 0, 0.2f, 1, 0, 0); // shear X axis
                    graphics.Transform = matrix;

                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                    tiffOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };

                    image.Save(outputPath, tiffOptions);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a vector image.");
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
 * 1. When you need to tilt or skew a logo stored as SVG before printing it on high‑resolution TIFF paper.
 * 2. When a web application must convert user‑uploaded SVG diagrams into 300 DPI TIFF files with a horizontal shear for archival quality.
 * 3. When generating engineering drawings that require a shear distortion and must be saved as a TIFF for compatibility with legacy CAD systems.
 * 4. When creating batch scripts that preprocess vector graphics by applying a shear matrix and outputting print‑ready TIFFs for a publishing workflow.
 * 5. When integrating Aspose.Imaging into a C# service to transform scalable icons into raster TIFFs with precise DPI settings for high‑quality marketing materials.
 */
