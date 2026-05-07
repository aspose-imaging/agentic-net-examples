using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.pdf";
            string outputPath = "output/output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PDF document
            using (Image pdfImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input file is not a multipage vector image.");
                    return;
                }

                // Select the first two pages (adjust as needed)
                int pagesToTake = Math.Min(2, multipage.PageCount);
                List<Image> selectedPages = new List<Image>();
                for (int i = 0; i < pagesToTake; i++)
                {
                    selectedPages.Add(multipage.Pages[i]);
                }

                // Calculate canvas size for vertical stacking
                int canvasWidth = selectedPages.Max(p => p.Width);
                int canvasHeight = selectedPages.Sum(p => p.Height);

                // Create SVG canvas
                SvgOptions svgOptions = new SvgOptions();
                using (SvgImage svgCanvas = new SvgImage(svgOptions, canvasWidth, canvasHeight))
                {
                    // Draw each selected page onto the SVG canvas
                    Graphics graphics = new Graphics(svgCanvas);
                    int offsetY = 0;
                    foreach (var page in selectedPages)
                    {
                        graphics.DrawImage(page, new Point(0, offsetY));
                        offsetY += page.Height;
                    }

                    // Save the combined SVG
                    svgCanvas.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}