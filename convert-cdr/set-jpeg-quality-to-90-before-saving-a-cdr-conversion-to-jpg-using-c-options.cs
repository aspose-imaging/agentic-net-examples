using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.jpg";

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
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        BackgroundColor = Color.White
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
 * 1. When a graphic designer needs to export a CorelDRAW (CDR) file to a high‑quality JPEG for web publishing, they can set the JPEG quality to 90 using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform automatically generates product thumbnails from CDR source files and wants consistent image quality, the code can rasterize the vector page and save it as a JPEG with 90 % quality.
 * 3. When a document management system converts archived CDR drawings to JPEG for preview in browsers, developers use this snippet to ensure the saved JPEG retains visual fidelity with a quality setting of 90.
 * 4. When a batch‑processing tool processes a folder of CDR logos and outputs JPEG images for print‑ready proofs, the code provides controlled compression by specifying Quality = 90.
 * 5. When a mobile app backend receives user‑uploaded CDR artwork and needs to deliver a compressed JPEG version with minimal loss, the developer applies this Aspose.Imaging C# example to set the JPEG quality to 90 before saving.
 */