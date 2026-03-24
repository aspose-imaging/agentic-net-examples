using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] jpgPaths = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in jpgPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Temporary folder for intermediate SVGZ files
        string tempSvgzFolder = @"C:\Temp\Svgz";
        Directory.CreateDirectory(tempSvgzFolder); // unconditional as required

        // List to hold generated SVGZ file paths
        List<string> svgzPaths = new List<string>();

        // Convert each JPG to compressed SVGZ
        foreach (string jpgPath in jpgPaths)
        {
            using (Image image = Image.Load(jpgPath))
            {
                // Prepare vector rasterization options based on the source image size
                var vectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Define SVG options with compression enabled
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = vectorRasterizationOptions,
                    Compress = true
                };

                // Determine output SVGZ path
                string svgzPath = Path.Combine(
                    tempSvgzFolder,
                    Path.GetFileNameWithoutExtension(jpgPath) + ".svgz");

                // Save as SVGZ
                image.Save(svgzPath, svgOptions);

                // Record the path for later PDF assembly
                svgzPaths.Add(svgzPath);
            }
        }

        // Create a multipage image from the SVGZ files
        using (Image multipageImage = Image.Create(svgzPaths.ToArray()))
        {
            // Output PDF path
            string outputPdf = @"C:\Output\combined.pdf";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

            // Save the multipage image as a PDF
            multipageImage.Save(outputPdf, new PdfOptions());
        }
    }
}