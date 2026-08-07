using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\input.jp2";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG2000 using a buffered stream with a 1 MB buffer
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream, 1024 * 1024))
            using (Jpeg2000Image jp2Image = new Jpeg2000Image(bufferedStream))
            {
                // Simple pixel processing: invert colors
                for (int y = 0; y < jp2Image.Height; y++)
                {
                    for (int x = 0; x < jp2Image.Width; x++)
                    {
                        var color = jp2Image.GetPixel(x, y);
                        var inverted = Aspose.Imaging.Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                        jp2Image.SetPixel(x, y, inverted);
                    }
                }

                // Save as JPEG with 85 % quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };
                jp2Image.Save(outputPath, jpegOptions);
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
 * 1. Convert high‑resolution JPEG2000 scans of archival documents to smaller JPEG files for web preview while applying a simple color inversion filter.
 * 2. Process satellite imagery stored as JPEG2000, invert pixel colors for analysis, then export to JPEG with 85 % quality for inclusion in a GIS report.
 * 3. Reduce the file size of medical imaging JPEG2000 files by converting them to JPEG with controlled quality after applying a pixel‑wise transformation.
 * 4. Automate batch conversion of JPEG2000 product photos to JPEG for e‑commerce platforms, using a 1 MB buffered stream to improve I/O performance.
 * 5. Integrate image preprocessing in a C# desktop app that loads JPEG2000 assets, inverts colors for visual effect, and saves them as JPEG with specific quality settings for printing.
 */