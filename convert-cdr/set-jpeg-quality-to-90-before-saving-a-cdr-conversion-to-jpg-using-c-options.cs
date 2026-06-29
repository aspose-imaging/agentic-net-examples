using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                cdr.Save(outputPath, jpegOptions);
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
 * 1. When a graphic design studio needs to batch‑convert CorelDRAW (CDR) files to high‑quality JPEGs for web galleries while controlling file size, they can use this code to set the JPEG quality to 90.
 * 2. When an e‑commerce platform must generate product thumbnails from CDR source files and ensure the images retain crisp colors without excessive compression, the developer can apply the 90‑quality JPEG option during conversion.
 * 3. When a document management system archives vector artwork as JPEG previews and wants consistent visual fidelity across different pages, the code lets the developer rasterize the CDR image with a 90‑percent quality setting.
 * 4. When a marketing automation tool creates email campaign assets from CDR designs and needs JPEGs that meet email client size limits yet look professional, the developer can use this snippet to balance quality and compression.
 * 5. When a mobile app downloads CDR‑based icons from a server and converts them to JPEG on the fly, setting the quality to 90 ensures the images load quickly while preserving enough detail for high‑resolution screens.
 */