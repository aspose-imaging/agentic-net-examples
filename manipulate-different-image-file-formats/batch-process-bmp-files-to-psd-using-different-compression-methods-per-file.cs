// HOW-TO: Batch Convert BMP to PSD with Specific Compression in C# (Aspose.Imaging for .NET)
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
            // Define batch conversion tasks (input BMP, output PSD, compression method)
            var tasks = new[]
            {
                new
                {
                    InputPath = @"C:\Images\sample1.bmp",
                    OutputPath = @"C:\Converted\sample1_RLE.psd",
                    Compression = CompressionMethod.RLE
                },
                new
                {
                    InputPath = @"C:\Images\sample2.bmp",
                    OutputPath = @"C:\Converted\sample2_RAW.psd",
                    Compression = CompressionMethod.Raw
                },
                // Add more tasks as needed
            };

            foreach (var task in tasks)
            {
                // Verify input file exists
                if (!File.Exists(task.InputPath))
                {
                    Console.Error.WriteLine($"File not found: {task.InputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(task.OutputPath));

                // Load BMP image
                using (Image image = Image.Load(task.InputPath))
                {
                    // Prepare PSD save options with the specified compression method
                    var psdOptions = new PsdOptions
                    {
                        CompressionMethod = task.Compression,
                        // Optional: set other options such as color mode if desired
                        ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb
                    };

                    // Save as PSD
                    image.Save(task.OutputPath, psdOptions);
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
 * 1. When you need to automate conversion of multiple BMP assets to Photoshop PSD files while applying different compression methods for each file.
 * 2. When a graphics pipeline requires preserving image quality by saving BMPs as PSDs with RLE compression for smaller file size.
 * 3. When integrating a batch image processing tool that must generate PSDs with RAW compression for loss‑less editing later.
 * 4. When preparing assets for a design team that expects PSD files organized in specific folders and using the RGB color mode.
 * 5. When building a C# utility that validates input BMP files, creates output directories, and saves them as PSDs with custom compression settings.
 */
