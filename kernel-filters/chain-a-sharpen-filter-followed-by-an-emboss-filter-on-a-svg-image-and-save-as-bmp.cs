// HOW-TO: Apply Sharpen Then Emboss Filters to SVG and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                int width = svgImage.Width;
                int height = svgImage.Height;

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(svgImage, new Point(0, 0));

                    canvas.Filter(canvas.Bounds, new SharpenFilterOptions());
                    canvas.Filter(canvas.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    canvas.Save();
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
 * 1. When you need to enhance the edges of a vector graphic and give it a 3‑D embossed look before converting it to a raster BMP for printing or legacy systems.
 * 2. When a web service must accept SVG logos, apply sharpening and embossing to match a brand’s visual style, and output BMP files for Windows desktop applications.
 * 3. When automating batch processing of SVG icons to create highlighted BMP thumbnails for a catalog that requires both edge sharpening and depth effect.
 * 4. When integrating image preprocessing in a C# workflow that converts scalable SVG diagrams into BMPs with improved contrast and texture for OCR or analysis tools.
 * 5. When preparing SVG artwork for embedding in a legacy reporting engine that only supports BMP, and you want to apply a sharpen‑then‑emboss pipeline to make the graphics stand out.
 */
