using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect at least one JPG input and one PDF output path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <jpg1> <jpg2> ... <output.pdf>");
            return;
        }

        string outputPdf = args[args.Length - 1];
        string[] jpgFiles = new string[args.Length - 1];
        Array.Copy(args, jpgFiles, args.Length - 1);

        // Determine canvas size (vertical stacking)
        int maxWidth = 0;
        int totalHeight = 0;
        foreach (string jpgPath in jpgFiles)
        {
            using (Image img = Image.Load(jpgPath))
            {
                if (img.Width > maxWidth) maxWidth = img.Width;
                totalHeight += img.Height;
            }
        }

        // Create PDF canvas
        Source pdfSource = new FileCreateSource(outputPdf, false);
        PdfOptions pdfOptions = new PdfOptions() { Source = pdfSource };
        using (RasterImage pdfCanvas = (RasterImage)Image.Create(pdfOptions, maxWidth, totalHeight))
        {
            Graphics graphics = new Graphics(pdfCanvas);
            int offsetY = 0;

            foreach (string jpgPath in jpgFiles)
            {
                // Convert JPG to compressed SVGZ (temporary file)
                string tempSvgz = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".svgz");
                using (Image jpgImg = Image.Load(jpgPath))
                {
                    var vectorOptions = new SvgRasterizationOptions() { PageSize = jpgImg.Size };
                    var svgOptions = new SvgOptions()
                    {
                        VectorRasterizationOptions = vectorOptions,
                        Compress = true
                    };
                    jpgImg.Save(tempSvgz, svgOptions);
                }

                // Load the SVGZ and draw onto PDF canvas
                using (Image svgImg = Image.Load(tempSvgz))
                {
                    graphics.DrawImage(svgImg, new Rectangle(0, offsetY, svgImg.Width, svgImg.Height));
                    offsetY += svgImg.Height;
                }

                // Clean up temporary file
                File.Delete(tempSvgz);
            }

            // Save the PDF
            pdfCanvas.Save();
        }
    }
}