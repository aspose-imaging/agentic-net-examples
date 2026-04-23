using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Define the batch of BMP files and the desired PSD compression for each.
            // Input and output paths are hard‑coded string literals.
            var jobs = new[]
            {
                new { Input = @"C:\Images\sample1.bmp", Output = @"C:\Output\sample1_Raw.psd", Compression = CompressionMethod.Raw },
                new { Input = @"C:\Images\sample2.bmp", Output = @"C:\Output\sample2_RLE.psd", Compression = CompressionMethod.RLE },
                new { Input = @"C:\Images\sample3.bmp", Output = @"C:\Output\sample3_Raw.psd", Compression = CompressionMethod.Raw }
            };

            foreach (var job in jobs)
            {
                // Verify that the input file exists.
                if (!File.Exists(job.Input))
                {
                    Console.Error.WriteLine($"File not found: {job.Input}");
                    return;
                }

                // Ensure the output directory exists (creates it if necessary).
                Directory.CreateDirectory(Path.GetDirectoryName(job.Output));

                // Load the BMP image.
                using (Image image = Image.Load(job.Input))
                {
                    // Configure PSD save options with the specified compression method.
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = job.Compression,
                        // Optional: keep other defaults (e.g., ColorMode, Version).
                    };

                    // Save the image as PSD using the configured options.
                    image.Save(job.Output, psdOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}