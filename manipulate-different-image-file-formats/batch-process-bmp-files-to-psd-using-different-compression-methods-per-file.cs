using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd; // for CompressionMethod

class Program
{
    static void Main()
    {
        // Batch definition: each entry specifies input BMP, output PSD and the desired PSD compression method.
        var batch = new[]
        {
            new { InputPath = @"C:\temp\image1.bmp", OutputPath = @"C:\temp\output1.psd", Compression = CompressionMethod.RLE },
            new { InputPath = @"C:\temp\image2.bmp", OutputPath = @"C:\temp\output2.psd", Compression = CompressionMethod.Raw }
            // Add more entries as needed.
        };

        foreach (var item in batch)
        {
            // Verify input file exists.
            if (!File.Exists(item.InputPath))
            {
                Console.Error.WriteLine($"File not found: {item.InputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing).
            Directory.CreateDirectory(Path.GetDirectoryName(item.OutputPath));

            // Load the BMP image.
            using (Image image = Image.Load(item.InputPath))
            {
                // Configure PSD save options with the specified compression method.
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = item.Compression
                };

                // Save the image as PSD using the configured options.
                image.Save(item.OutputPath, psdOptions);
            }
        }
    }
}