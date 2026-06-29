using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    cdr.Save(outputPath, psdOptions);
                }
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
 * 1. When a graphic designer needs to convert a CorelDRAW (CDR) file into an Adobe Photoshop (PSD) file while keeping the original layer groups intact for further editing in Photoshop.
 * 2. When an automated build pipeline processes batch CDR assets and must preserve vector layers and groups during conversion to PSD for downstream compositing.
 * 3. When a web application allows users to upload CDR logos and returns a PSD version that retains editable layers for branding teams.
 * 4. When a digital asset management system migrates legacy CDR artwork to PSD format and requires layer preservation to maintain editability without manual recreation.
 * 5. When a C# desktop tool generates print‑ready PSD files from CDR source files, ensuring that each layer group remains separate for color‑separation workflows.
 */