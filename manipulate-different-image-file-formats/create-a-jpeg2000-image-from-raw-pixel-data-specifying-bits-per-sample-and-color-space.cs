using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "C:\\temp\\output.jp2";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 200;
            int height = 100;
            int bitsPerSample = 8;

            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height, bitsPerSample))
            {
                Graphics graphics = new Graphics(jpeg2000Image);
                graphics.Clear(Color.Red);

                jpeg2000Image.Save(outputPath, new Jpeg2000Options());
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
 * 1. When a developer needs to generate a JPEG2000 file from programmatically created pixel data, such as rendering a solid‑color rectangle for a thumbnail in a C# web service, they can use this code to set width, height, bits per sample and save the image.
 * 2. When an application must export medical imaging data to the lossless JPEG2000 format with a specific bits‑per‑sample depth for compliance with DICOM standards, this snippet shows how to create the image and define the color space in .NET.
 * 3. When a game engine requires pre‑rendered background textures stored as JPEG2000 to reduce file size while preserving 8‑bit color fidelity, developers can employ this example to programmatically generate the textures from raw pixel buffers.
 * 4. When an automated reporting tool needs to embed a red warning banner into a PDF by first creating a JPEG2000 image with defined dimensions and color depth, the code demonstrates the necessary C# operations with Aspose.Imaging.
 * 5. When a batch‑processing script must convert raw sensor output into a standardized JPEG2000 image for archival, specifying bits per sample and using the Aspose.Imaging library ensures consistent image creation across different platforms.
 */