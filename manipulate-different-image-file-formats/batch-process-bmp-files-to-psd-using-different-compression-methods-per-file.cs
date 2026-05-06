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
            // Define the batch of BMP files to convert.
            // Each entry specifies the input BMP path, the desired output PSD path,
            // and the PSD compression method to use for that file.
            var batch = new[]
            {
                new
                {
                    InputPath = @"C:\Images\sample1.bmp",
                    OutputPath = @"C:\Converted\sample1.psd",
                    Compression = CompressionMethod.RLE // RLE compression
                },
                new
                {
                    InputPath = @"C:\Images\sample2.bmp",
                    OutputPath = @"C:\Converted\sample2.psd",
                    Compression = CompressionMethod.Raw // No compression
                },
                // Add more entries as needed.
            };

            foreach (var item in batch)
            {
                // Verify that the input file exists.
                if (!File.Exists(item.InputPath))
                {
                    Console.Error.WriteLine($"File not found: {item.InputPath}");
                    return;
                }

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(item.OutputPath));

                // Load the BMP image.
                using (Image image = Image.Load(item.InputPath))
                {
                    // Configure PSD save options with the specified compression method.
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = item.Compression,
                        // Optional: set other PSD options such as ColorMode, ChannelBitsCount, etc.
                    };

                    // Save the image as PSD using the configured options.
                    image.Save(item.OutputPath, psdOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing the application.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}