using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] jpgPaths = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (string jpgPath in jpgPaths)
        {
            if (!File.Exists(jpgPath))
            {
                Console.Error.WriteLine($"File not found: {jpgPath}");
                return;
            }
        }

        // Folder for intermediate SVGZ files
        string tempSvgzFolder = @"C:\Temp\Svgz";
        Directory.CreateDirectory(tempSvgzFolder);

        // Convert each JPG to SVGZ
        string[] svgzPaths = new string[jpgPaths.Length];
        for (int i = 0; i < jpgPaths.Length; i++)
        {
            string jpgPath = jpgPaths[i];
            string svgzPath = Path.Combine(tempSvgzFolder,
                Path.GetFileNameWithoutExtension(jpgPath) + ".svgz");
            svgzPaths[i] = svgzPath;

            using (Image image = Image.Load(jpgPath))
            {
                // Prepare vector rasterization options matching the source size
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save as compressed SVGZ
                var svgOptions = new SvgOptions
                {
                    Compress = true,
                    VectorRasterizationOptions = vectorOptions
                };

                // Ensure the output directory exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(svgzPath));
                image.Save(svgzPath, svgOptions);
            }
        }

        // Create a multipage image from the SVGZ files
        using (Image multipage = Image.Create(svgzPaths))
        {
            // Output PDF path
            string outputPdfPath = @"C:\Output\Combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // PDF export options
            var pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF
            multipage.Save(outputPdfPath, pdfOptions);
        }
    }
}