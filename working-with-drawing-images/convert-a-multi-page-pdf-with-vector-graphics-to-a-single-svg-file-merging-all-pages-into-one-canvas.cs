using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pdf";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image pdfImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input file is not a multipage vector image.");
                    return;
                }

                List<Size> pageSizes = new List<Size>();
                foreach (Image page in multipage.Pages)
                {
                    pageSizes.Add(page.Size);
                }

                int canvasWidth = pageSizes.Max(s => s.Width);
                int canvasHeight = pageSizes.Sum(s => s.Height);

                Source src = new FileCreateSource(outputPath, false);
                SvgOptions svgOptions = new SvgOptions() { Source = src };

                using (SvgImage canvas = new SvgImage(svgOptions, canvasWidth, canvasHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    int offsetY = 0;

                    foreach (Image page in multipage.Pages)
                    {
                        graphics.DrawImage(page, new Point(0, offsetY));
                        offsetY += page.Height;
                    }

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