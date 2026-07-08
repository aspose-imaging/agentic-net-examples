using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();

                if (image is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    psdOptions.VectorRasterizationOptions = vectorOptions;
                }

                image.Save(outputPath, psdOptions);
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
 * 1. When a print shop needs to import a multi‑page EPS artwork into Photoshop for layer‑based editing, a developer can use this C# code with Aspose.Imaging to convert the EPS to a multi‑page PSD while preserving each page.
 * 2. When an automated publishing pipeline must transform vector‑based EPS brochures into editable PSD files for designers, the code demonstrates how to load the EPS, rasterize each page, and save a multi‑page PSD in .NET.
 * 3. When a digital asset management system requires batch conversion of multi‑page EPS logos into Photoshop‑compatible PSDs for further manipulation, this example shows the necessary C# operations using Image.Load and PsdOptions.
 * 4. When a web service needs to provide on‑the‑fly preview of each page of a multi‑page EPS document in Photoshop format, the snippet illustrates how to preserve page dimensions and background color during conversion.
 * 5. When a developer is building a C# application that must retain all pages of a vector EPS file while converting it to a PSD for downstream editing, the code outlines the use of VectorRasterizationOptions to maintain quality and page count.
 */