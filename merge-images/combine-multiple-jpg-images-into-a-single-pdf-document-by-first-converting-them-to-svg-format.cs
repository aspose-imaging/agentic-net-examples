using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] jpgInputs = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded output PDF file
        string outputPdfPath = @"C:\Images\CombinedOutput.pdf";

        // Verify each JPG exists
        foreach (var inputPath in jpgInputs)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Temporary folder for SVG files
        string tempSvgFolder = Path.Combine(Path.GetTempPath(), "AsposeSvgTemp");
        Directory.CreateDirectory(tempSvgFolder);

        // Convert each JPG to SVG
        string[] svgPaths = new string[jpgInputs.Length];
        for (int i = 0; i < jpgInputs.Length; i++)
        {
            string jpgPath = jpgInputs[i];
            string svgPath = Path.Combine(tempSvgFolder, $"page{i + 1}.svg");
            svgPaths[i] = svgPath;

            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Prepare rasterization options matching the source image size
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Save as SVG using the rasterization options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Ensure the directory for the SVG exists (already created above)
                jpgImage.Save(svgPath, svgOptions);
            }
        }

        // Create a multipage image from the generated SVG files
        using (Image multipageImage = Image.Create(svgPaths))
        {
            // Prepare PDF options (default settings are sufficient)
            var pdfOptions = new PdfOptions();

            // Save the multipage image as a single PDF document
            multipageImage.Save(outputPdfPath, pdfOptions);
        }

        // Cleanup temporary SVG files (optional)
        try
        {
            Directory.Delete(tempSvgFolder, true);
        }
        catch
        {
            // Ignored – cleanup failure should not affect the main result
        }
    }
}