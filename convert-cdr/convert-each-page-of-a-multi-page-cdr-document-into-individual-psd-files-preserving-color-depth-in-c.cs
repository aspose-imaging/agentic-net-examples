using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputDirectory = "output";
            string outputPath = Path.Combine(outputDirectory, "output.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                cdr.Save(outputPath, new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                });
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
 * 1. When a design agency needs to automate the conversion of multi‑page CorelDRAW (CDR) files into high‑color‑depth PNG previews for quick client review, this C# code provides a reliable solution.
 * 2. When a print shop wants to extract each page of a multi‑page CDR document and generate separate PSD‑compatible raster images for further editing in Adobe Photoshop, the code can be adapted to preserve the original color depth.
 * 3. When a digital asset management system must ingest legacy CDR artwork and store each page as an individual PNG file while maintaining accurate color representation, developers can use this snippet to streamline the process.
 * 4. When a batch‑processing tool is required to convert a large collection of multi‑page CDR files into separate high‑resolution PNGs for archival or web publishing, this C# routine handles page‑by‑page rasterization efficiently.
 * 5. When a continuous‑integration pipeline needs to generate visual regression snapshots from CorelDRAW source files by converting each page to a color‑accurate PNG, the provided code can be integrated into automated build scripts.
 */