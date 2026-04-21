using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
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

            // Load JPEG2000 image using a 1 MB buffered stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream, 1024 * 1024))
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(bufferedStream))
            {
                // Simple pixel processing: invert colors
                for (int y = 0; y < jpeg2000Image.Height; y++)
                {
                    for (int x = 0; x < jpeg2000Image.Width; x++)
                    {
                        var original = jpeg2000Image.GetPixel(x, y);
                        var inverted = Color.FromArgb(
                            255 - original.R,
                            255 - original.G,
                            255 - original.B);
                        jpeg2000Image.SetPixel(x, y, inverted);
                    }
                }

                // Save as JPEG with quality 85
                var jpegOptions = new JpegOptions
                {
                    Quality = 85
                };
                jpeg2000Image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}