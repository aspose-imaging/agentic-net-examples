using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MergeJpgToPdfViaSvgz
{
    static void Main()
    {
        // Paths for source JPG, intermediate SVGZ and final PDF
        string jpgPath = @"C:\Temp\input.jpg";
        string svgzPath = @"C:\Temp\intermediate.svgz";
        string pdfPath = @"C:\Temp\output.pdf";

        // Step 1: Load the JPG image
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Define rasterization options matching the source image size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = jpgImage.Size
            };

            // Set SVG options to enable compression (produces .svgz)
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Compress = true
            };

            // Save the JPG as a compressed SVG (SVGZ)
            jpgImage.Save(svgzPath, svgOptions);
        }

        // Step 2: Load the generated SVGZ file
        using (Image svgzImage = Image.Load(svgzPath))
        {
            // Create PDF export options (default settings are sufficient for a single page)
            var pdfOptions = new PdfOptions();

            // Save the SVGZ content as a PDF document
            svgzImage.Save(pdfPath, pdfOptions);
        }

        Console.WriteLine("JPG has been merged into PDF via SVGZ successfully.");
    }
}