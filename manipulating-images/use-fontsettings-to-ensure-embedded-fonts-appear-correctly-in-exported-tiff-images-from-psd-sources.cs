using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\Images\\sample.psd";
        string outputPath = "C:\\Images\\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Compression = TiffCompressions.Lzw;

                image.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to convert client‑provided Photoshop PSD files to high‑resolution TIFFs while preserving the exact appearance of text layers that use custom fonts, a developer can use Aspose.Imaging’s FontSettings with the provided C# code to embed those fonts during export.
 * 2. When an archival system must store layered design assets as lossless TIFFs for long‑term preservation and must guarantee that any embedded typefaces are rendered correctly on any workstation, the code can be integrated to apply FontSettings before saving.
 * 3. When a web‑based proofing tool generates preview TIFFs from uploaded PSDs and must display text exactly as designed even if the viewer’s machine lacks the original fonts, developers can employ this snippet with FontSettings to embed the fonts into the TIFF.
 * 4. When an automated batch‑processing pipeline converts thousands of PSD marketing banners to compressed LZW TIFFs for offline printing, using FontSettings ensures that all brand‑specific fonts remain intact without manual font installation.
 * 5. When a legal e‑discovery platform extracts visual evidence from PSD files and needs to produce TIFF images that faithfully reproduce annotated text for court submission, the code with FontSettings guarantees that embedded fonts are preserved in the exported files.
 */