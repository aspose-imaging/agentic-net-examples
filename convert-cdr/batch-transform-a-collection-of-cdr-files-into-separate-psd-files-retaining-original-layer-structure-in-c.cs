// HOW-TO: Batch Convert CDR Files to PSD with Layers Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".psd");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    PsdOptions psdOptions = new PsdOptions
                    {
                        CompressionMethod = CompressionMethod.RLE,
                        ColorMode = ColorModes.Rgb,
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        },
                        MultiPageOptions = new MultiPageOptions(new IntRange(0, cdr.PageCount))
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
 * 1. When a design studio needs to migrate a library of CorelDRAW (.cdr) assets to Photoshop (.psd) files while keeping each object's layer intact.
 * 2. When an automated build pipeline must process multiple CDR drawings and generate PSD outputs for downstream editing in Adobe Photoshop.
 * 3. When a web service receives user‑uploaded CDR files and must store them as PSDs for preview or further manipulation.
 * 4. When a batch conversion tool is required to convert all CDR files in a folder to PSDs with RLE compression and RGB color mode.
 * 5. When a developer wants to programmatically preserve the original page dimensions and background color while converting CDR to PSD in a .NET application.
 */
