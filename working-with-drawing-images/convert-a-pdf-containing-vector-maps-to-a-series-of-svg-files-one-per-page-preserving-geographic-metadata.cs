using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input PDF path
        string inputPath = "input.pdf";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the PDF document
        using (Aspose.Imaging.Image pdfImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Output directory for SVG files
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Check if the PDF is multipage
            if (pdfImage is Aspose.Imaging.IMultipageImage multipage)
            {
                int pageCount = multipage.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    // Get the individual page image
                    using (Aspose.Imaging.Image pageImage = multipage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.svg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure SVG export options
                        SvgOptions svgOptions = new SvgOptions
                        {
                            KeepMetadata = true,
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = pageImage.Width,
                                PageHeight = pageImage.Height,
                                BackgroundColor = Aspose.Imaging.Color.White
                            }
                        };

                        // Save the page as an SVG file
                        pageImage.Save(outputPath, svgOptions);
                    }
                }
            }
            else
            {
                // Single-page PDF handling
                string outputPath = Path.Combine(outputDir, "page_1.svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                SvgOptions svgOptions = new SvgOptions
                {
                    KeepMetadata = true,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = pdfImage.Width,
                        PageHeight = pdfImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                pdfImage.Save(outputPath, svgOptions);
            }
        }
    }
}